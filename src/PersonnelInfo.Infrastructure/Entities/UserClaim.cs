namespace PersonnelInfo.Infrastructure.Entities;

public class UserClaim<TKey> where TKey : IEquatable<TKey>
{
    /// <summary>
    /// Gets or sets the identifier for this user claim.
    /// </summary>
    public virtual int Id { get; set; } = default!;

    /// <summary>
    /// Gets or sets the primary key of the user associated with this claim.
    /// </summary>
    public virtual TKey UserId { get; set; } = default!;

    /// <summary>
    /// Gets or sets the claim type for this claim.
    /// </summary>
    public virtual string? ClaimType { get; set; }

    /// <summary>
    /// Gets or sets the claim value for this claim.
    /// </summary>
    public virtual string? ClaimValue { get; set; }

    //public User<TKey> User { get; set; } = default!;
}
