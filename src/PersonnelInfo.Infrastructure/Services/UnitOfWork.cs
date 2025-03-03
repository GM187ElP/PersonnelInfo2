using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using PersonnelInfo.Application.Interfaces;
using PersonnelInfo.Infrastructure.Configuration;

namespace PersonnelInfo.Infrastructure.Services;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly DatabaseContext _dbContext;
    private IDbContextTransaction? _currentTransaction;

    public UnitOfWork(DatabaseContext dbContext) => _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default) => await _dbContext.SaveChangesAsync(cancellationToken);

    public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
    {
        if (_currentTransaction != null)
            throw new InvalidOperationException("A transaction is already in progress.");

        _currentTransaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken);
    }

    public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
    {
        if (_currentTransaction == null)
            throw new InvalidOperationException("No active transaction to commit.");

        await _currentTransaction.CommitAsync(cancellationToken);
        await _currentTransaction.DisposeAsync();
        _currentTransaction = null;
    }

    public async Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
    {
        if (_currentTransaction != null)
        {
            await _currentTransaction.RollbackAsync(cancellationToken);
            await _currentTransaction.DisposeAsync();
            _currentTransaction = null;
        }
    }

    public async Task ExecuteInTransactionAsync(Func<CancellationToken, Task> operation, CancellationToken cancellationToken = default)
    {
        await BeginTransactionAsync(cancellationToken);
        try
        {
            await operation(cancellationToken);
            await SaveChangesAsync(cancellationToken);
            await CommitTransactionAsync(cancellationToken);
        }
        catch (DbUpdateConcurrencyException ex)
        {
            await RollbackTransactionAsync(cancellationToken);
            throw new InvalidOperationException("A concurrency issue occurred.", ex);
        }
        catch (DbUpdateException ex)
        {
            await RollbackTransactionAsync(cancellationToken);
            throw new InvalidOperationException("A database update error occurred.", ex);
        }
        catch (Exception ex)
        {
            await RollbackTransactionAsync(cancellationToken);
            throw new InvalidOperationException("An unexpected error occurred during the transaction.", ex);
        }
    }

    public void Dispose()
    {
        _currentTransaction?.Dispose();
        _dbContext.Dispose();
    }
}
