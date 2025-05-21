namespace PersonnelInfo.Infrastructure.Entities;

public class UserToken<TKey> 
{
    /// <summary>
    /// Gets or sets the primary key of the user that the token belongs to.
    /// </summary>
    public virtual TKey UserId { get; set; } = default!;

    /// <summary>
    /// Gets or sets the LoginProvider this token is from.
    /// </summary>
    public virtual string LoginProvider { get; set; } = default!;

    /// <summary>
    /// Gets or sets the name of the token.
    /// </summary>
    public virtual string Name { get; set; } = default!;

    /// <summary>
    /// Gets or sets the token value.
    /// </summary>
    //[ProtectedPersonalData]
    public virtual string? Value { get; set; }

    //public User<TKey> User { get; set; } = default!;
}




public enum PhoneEmail
{
    Email, Phone
}