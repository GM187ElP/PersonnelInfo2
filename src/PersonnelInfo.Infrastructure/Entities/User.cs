using Microsoft.AspNetCore.Identity;

namespace PersonnelInfo.Infrastructure.Entities;

public class User : IdentityUser<Guid>
{
    public string NationalId { get; set; } = default!;
    public string Provider { get; set; } = default!;
    public string ProviderKey { get; set; } = default!;
    public string DisplayName { get; set; } = default!;
}

public class RegularUser : User
{

}

//public class User<TKey> : IUser<TKey> where TKey : IEquatable<TKey>
//{
//    /// <summary>
//    /// Gets or sets the primary key for this user.
//    /// </summary>
//    [PersonalData]
//    public virtual TKey Id { get; set; } = default!;

//    /// <summary>
//    /// Gets or sets the user name for this user.
//    /// </summary>
//    [ProtectedPersonalData]
//    public virtual string? UserName { get; set; }

//    /// <summary>
//    /// Gets or sets the normalized user name for this user.
//    /// </summary>
//    public virtual string? NormalizedUserName { get; set; }

//    /// <summary>
//    /// Gets or sets the email address for this user.
//    /// </summary>
//    [ProtectedPersonalData]
//    public virtual string? Email { get; set; }

//    /// <summary>
//    /// Gets or sets the normalized email address for this user.
//    /// </summary>
//    public virtual string? NormalizedEmail { get; set; }

//    /// <summary>
//    /// Gets or sets a flag indicating if a user has confirmed their email address.
//    /// </summary>
//    /// <value>True if the email address has been confirmed, otherwise false.</value>
//    [PersonalData]
//    public virtual bool EmailConfirmed { get; set; }

//    /// <summary>
//    /// Gets or sets a salted and hashed representation of the password for this user.
//    /// </summary>
//    public virtual string? PasswordHash { get; set; }

//    /// <summary>
//    /// A random value that must change whenever a users credentials change (password changed, login removed)
//    /// </summary>
//    public virtual string? SecurityStamp { get; set; }

//    /// <summary>
//    /// A random value that must change whenever a user is persisted to the store
//    /// </summary>
//    public virtual string? ConcurrencyStamp { get; set; } = Guid.NewGuid().ToString();

//    /// <summary>
//    /// Gets or sets a telephone number for the user.
//    /// </summary>
//    [ProtectedPersonalData]
//    public virtual string? PhoneNumber { get; set; }

//    /// <summary>
//    /// Gets or sets a flag indicating if a user has confirmed their telephone address.
//    /// </summary>
//    /// <value>True if the telephone number has been confirmed, otherwise false.</value>
//    [PersonalData]
//    public virtual bool PhoneNumberConfirmed { get; set; }

//    /// <summary>
//    /// Gets or sets a flag indicating if two factor authentication is enabled for this user.
//    /// </summary>
//    /// <value>True if 2fa is enabled, otherwise false.</value>
//    [PersonalData]
//    public virtual bool TwoFactorEnabled { get; set; }

//    /// <summary>
//    /// Gets or sets the date and time, in UTC, when any user lockout ends.
//    /// </summary>
//    /// <remarks>
//    /// A value in the past means the user is not locked out.
//    /// </remarks>
//    public virtual DateTimeOffset? LockoutEnd { get; set; }

//    /// <summary>
//    /// Gets or sets a flag indicating if the user could be locked out.
//    /// </summary>
//    /// <value>True if the user could be locked out, otherwise false.</value>
//    public virtual bool LockoutEnabled { get; set; }

//    /// <summary>
//    /// Gets or sets the number of failed login attempts for the current user.
//    /// </summary>
//    public virtual int AccessFailedCount { get; set; }

//    public ICollection<UserClaim<TKey>> UserClaims { get; set; } = [];
//    public ICollection<UserLogin<TKey>> UserLogins { get; set; } = [];
//    public ICollection<UserRole<TKey>> UserRoles { get; set; } = [];
//    public ICollection<UserToken<TKey>> UserTokens { get; set; } = [];
//}



//public async Task AdminPhoneEmailVerification(PhoneEmail phoneEmail, string phonenumberOrEmail)
//{
//    UserManager<UserTest> userManager = new RoleManager<UserTest>();
//    var Admins = await userManager.GetUsersInRoleAsync("Admin");
//    var result = Admins.Any(x => (x.EmailConfirmed == false || x.PhoneNumberConfirmed == false) && (x.phon == phonenumberOrEmail || x.Email == phonenumberOrEmail));

//    if (result)
//    {
//        if (phoneEmail == PhoneEmail.Email)
//            SendEmail(phonenumberOrEmail);
//        if (phoneEmail == PhoneEmail.Phone)
//            SendSms(phonenumberOrEmail);
//    }
//    else
//    {
//        // else procedure
//    }
//}

//public void FillNationalIdOrPersonnelId(string id, string personnelCodeOrnationalId) // this is happens after oauth page success
//{
//    UserManager<UserTest> userManager = new RoleManager<UserTest>();
//    var user=userManager.FindByIdAsync(id).Result;
//    user.nationalId = personnelCodeOrnationalId; // or
//    user.PersonnelCode = personnelCodeOrnationalId;
//}

//private void SendEmail(string phonenumberOrEmail)
//{
//    //sendemail and response procedure
//    EmailConfirmed = true;       
//}

//private void SendSms(string phonenumberOrEmail)
//{
//    //sendsms and response procedure
//    PhoneNUmberConfirmed = true;

//}
