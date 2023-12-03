using System.Text.RegularExpressions;

namespace HigiaServer.Domain.Common;

public abstract class BaseUserEntity : BaseEntity
{
#pragma warning disable CS8618
    protected BaseUserEntity() { }

    protected BaseUserEntity(string name, string email, string phoneNumber,
        DateTime birthday, string passwordHash)
    {
        ValidateUser(name, email, birthday, phoneNumber, passwordHash);

        Name = name.Trim().ToLower();
        Email = email;
        Birthday = birthday;
        PhoneNumber = phoneNumber;
        PasswordHash = passwordHash;
    }

    public bool IsAdmin { get; init; }
    public string Name { get; protected set; }
    public string Email { get; protected set; }
    public DateTime Birthday { get; protected set; }
    public string PhoneNumber { get; protected set; }
    public string PasswordHash { get; protected set; }

    protected void ValidateUser(string name, string email, DateTime birthday,
        string phoneNumber, string passwordHash)
    {
        DomainExeptionValidation.When(string.IsNullOrEmpty(name),
            "Invalid first name, valid first name is required");

        DomainExeptionValidation.When(name.Length < 3, "Invalid name, too short, minimum 3 characters");

        DomainExeptionValidation.When(ValidateEmailAdress(email),
            "Invalid email address, valid email address is required");

        DomainExeptionValidation.When(birthday >= DateTime.Now.AddYears(-18),
            "Invalid birthday, minimum age is 18 years old");
        DomainExeptionValidation.When(ValidateNumber(phoneNumber),
            "Invalid number phone, valid number phone is required");

        DomainExeptionValidation.When(string.IsNullOrEmpty(passwordHash),
            "Invalid password, valid password is required");
    }

    private bool ValidateEmailAdress(string email)
    {
        if (string.IsNullOrEmpty(email))
        {
            return true;
        }

        string pattern = @"^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$";
        return !Regex.IsMatch(email, pattern);
    }

    private bool ValidateNumber(string number)
    {
        if (string.IsNullOrEmpty(number))
        {
            return true;
        }

        string pattern =
            @"^1\d\d(\d\d)?$|^0800 ?\d{3} ?\d{4}$|^(\(0?([1-9a-zA-Z][0-9a-zA-Z])?[1-9]\d\) ?|0?([1-9a-zA-Z][0-9a-zA-Z])?[1-9]\d[ .-]?)?(9|9[ .-])?[2-9]\d{3}[ .-]?\d{4}$";
        return !Regex.IsMatch(number, pattern);
    }
}