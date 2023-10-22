using System.Text.RegularExpressions;
using HigiaServer.Domain.Entities;
using HigiaServer.Domain.Validations;

namespace HigiaServer.Domain.Common;

public abstract class BaseUserEntity : BaseAuditableEntity
{
    public bool IsAdmin { get; init; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Address { get; private set; }
    public DateTimeOffset Birthday { get; private set; }
    public string PhoneNumber { get; private set; }

    protected void UpdateNumberPhoneToUser(string phoneNumber)
    {
        ValidateNumber(phoneNumber);
        PhoneNumber = phoneNumber;

        LastModified = DateTimeOffset.Now;
    }

    protected void UpdateAdressToUser(string adress)
    {
        ValidateAddress(adress);
        Address = adress;

        LastModified = DateTimeOffset.Now;
    }

    protected BaseUserEntity(string firstName, string lastName, string address, string phoneNumber, DateTimeOffset birthday)
    {
        ValidateUser(firstName, lastName, address, birthday, phoneNumber);

        FirstName = firstName.Trim().ToLower();
        LastName = lastName.Trim().ToLower();
        Address = address;
        Birthday = birthday;
        PhoneNumber = phoneNumber;
    }

    protected void ValidateUser(string firstName, string lastName, string address, DateTimeOffset birthday, string phoneNumber)
    {
        DomainExeptionValidation.When(string.IsNullOrEmpty(firstName), "Invalid first name, valid first name is required");
        DomainExeptionValidation.When(firstName.Length <= 3, "Invalid first name, too short, minimum 3 characters");

        DomainExeptionValidation.When(string.IsNullOrEmpty(lastName), "Invalid last name, valid last name is required");
        DomainExeptionValidation.When(lastName.Length <= 3, "Invalid last name, too short, minimum 3 characters");

        DomainExeptionValidation.When(ValidateAddress(address), "Invalid email address, valid email address is required");

        DomainExeptionValidation.When(birthday >= DateTimeOffset.Now.AddYears(-18), "Invalid birthday, minimum age is 18 years old");
        DomainExeptionValidation.When(ValidateNumber(phoneNumber), "Invalid number phone, valid number phone is required");
    }

    private bool ValidateAddress(string address)
    {
        string pattern = @"^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$";
        return !Regex.IsMatch(address, pattern);
    }

    private bool ValidateNumber(string number)
    {
        string pattern = @"(?:([+]\d{1,4})[-.\s]?)?(?:[(](\d{1,3})[)][-.\s]?)?(\d{1,4})[-.\s]?(\d{1,4})[-.\s]?(\d{1,9})";
        return !Regex.IsMatch(number, pattern);
    }
}
