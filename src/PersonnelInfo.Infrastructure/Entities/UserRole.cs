namespace PersonnelInfo.Infrastructure.Entities;

public class UserRole<TKey> where TKey : IEquatable<TKey>
{
    /// <summary>
    /// Gets or sets the primary key of the user that is linked to a role.
    /// </summary>
    public virtual TKey UserId { get; set; } = default!;

    /// <summary>
    /// Gets or sets the primary key of the role that is linked to the user.
    /// </summary>
    public virtual TKey RoleId { get; set; } = default!;

    //public User<TKey> User { get; set; } = default!;
    public Role<TKey> Role { get; set; } = default!;
}
