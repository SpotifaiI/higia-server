using System.Text.RegularExpressions;

namespace HigiaServer.Domain.Common;

public abstract class BaseUserEntity : BaseAuditableEntity
{
    protected BaseUserEntity(string firstName, string lastName, string address, string phoneNumber,
        DateTime birthday)
    {
        ValidateUser(firstName, lastName, address, birthday, phoneNumber);

        FirstName = firstName.Trim().ToLower();
        LastName = lastName.Trim().ToLower();
        Address = address;
        Birthday = birthday;
        PhoneNumber = phoneNumber;
    }

    public bool IsAdmin { get; init; }
    public string FirstName { get; protected set; }
    public string LastName { get; protected set; }
    public string Address { get; protected set; }
    public DateTime Birthday { get; protected set; }
    public string PhoneNumber { get; protected set; }

    public void UpdateNumberPhoneToUser(string phoneNumber)
    {
        DomainExeptionValidation.When(ValidateNumber(phoneNumber),
            "Invalid number phone, valid number phone is required");

        PhoneNumber = phoneNumber;
        LastModifiedAt = DateTime.Now;
    }

    public void UpdateAdressToUser(string address)
    {
        DomainExeptionValidation.When(ValidateAddress(address),
            "Invalid email address, valid email address is required");

        Address = address;
        LastModifiedAt = DateTime.Now;
    }

    protected void ValidateUser(string firstName, string lastName, string address, DateTime birthday,
        string phoneNumber)
    {
        DomainExeptionValidation.When(string.IsNullOrEmpty(firstName),
            "Invalid first name, valid first name is required");
        DomainExeptionValidation.When(firstName.Length <= 3, "Invalid first name, too short, minimum 3 characters");

        DomainExeptionValidation.When(string.IsNullOrEmpty(lastName), "Invalid last name, valid last name is required");
        DomainExeptionValidation.When(lastName.Length <= 3, "Invalid last name, too short, minimum 3 characters");

        DomainExeptionValidation.When(ValidateAddress(address),
            "Invalid email address, valid email address is required");

        DomainExeptionValidation.When(birthday >= DateTime.Now.AddYears(-18),
            "Invalid birthday, minimum age is 18 years old");
        DomainExeptionValidation.When(ValidateNumber(phoneNumber),
            "Invalid number phone, valid number phone is required");
    }

    private bool ValidateAddress(string address)
    {
        if (string.IsNullOrEmpty(address))
        {
            return true;
        }

        string pattern = @"^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$";
        return !Regex.IsMatch(address, pattern);
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