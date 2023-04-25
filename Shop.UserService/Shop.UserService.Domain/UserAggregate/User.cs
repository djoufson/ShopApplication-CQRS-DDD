using Shop.Common.Domain_Layer.Models.Base;

namespace Shop.UserService.Domain.UserAggregate;

public sealed class User : AggregateRoot<UserId>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public int PhoneNumber { get; set; }
    public List<UserRole> UserRoles { get; set; }
    private User(
        UserId id,
        string firstName,
        string lastName,
        string email,
        string password,
        int phoneNumber,
        IEnumerable<UserRole>? userRoles) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        PhoneNumber = phoneNumber;
        UserRoles = userRoles?.ToList() ?? new List<UserRole>();
    }

    public static User Create(
        string firstName,
        string lastName,
        string email,
        string password,
        int phoneNumber,
        IEnumerable<UserRole>? userRoles = null)
    {
        return new(
            UserId.CreateUnique(),
            firstName,
            lastName,
            email,
            password,
            phoneNumber,
            userRoles);
    }

    public static User Create(
        string firstName,
        string lastName,
        string email,
        string password,
        int phoneNumber,
        params UserRole[] userRoles)
    {
        return new(
            UserId.CreateUnique(),
            firstName,
            lastName,
            email,
            password,
            phoneNumber,
            userRoles);
    }
}
