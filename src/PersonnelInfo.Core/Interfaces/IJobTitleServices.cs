using PersonnelInfo.Core.DTOs.Entities.JobTitles;

namespace PersonnelInfo.Application.Services;

public interface IJobTitleServices
{
    Task AddAsync(AddJobTitleDto addDto, CancellationToken cancellationToken = default);
    Task DeleteByIdAsync(string id, CancellationToken cancellationToken = default);
    Task<List<JobTitleDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<JobTitleDto> GetByIdAsync(string id, CancellationToken cancellationToken = default);
    Task UpdateAsync(JobTitleDto updateDto, CancellationToken cancellationToken = default);
}