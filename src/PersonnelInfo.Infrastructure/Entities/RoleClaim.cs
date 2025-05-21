namespace PersonnelInfo.Infrastructure.Entities;

public class RoleClaim<TKey> where TKey : IEquatable<TKey>
{
    /// <summary>
    /// Gets or sets the identifier for this role claim.
    /// </summary>
    public virtual int Id { get; set; } = default!;

    /// <summary>
    /// Gets or sets the of the primary key of the role associated with this claim.
    /// </summary>
    public virtual TKey RoleId { get; set; } = default!;

    /// <summary>
    /// Gets or sets the claim type for this claim.
    /// </summary>
    public virtual string? ClaimType { get; set; }

    /// <summary>
    /// Gets or sets the claim value for this claim.
    /// </summary>
    public virtual string? ClaimValue { get; set; }

    public Role<TKey> Role { get; set; } = default!;
}
