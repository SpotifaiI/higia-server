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
    public DateTime? Birthday { get; private set; }
    public string PhoneNumber { get; private set; }

    protected void ChangeNumberPhoneToUser<T>(T user, string phoneNumber) where T: BaseUserEntity
    {
        ValidateNumber(phoneNumber);
        PhoneNumber = phoneNumber;
    }

    protected void ChangeAdressToUser<T>(T user, string adress) where T : BaseUserEntity
    {
        ValidateAdress(adress);
        Address = adress;
    }

    protected BaseUserEntity(string firstName, string lastName, string address, string phoneNumber, DateTime? birthday, Administrator? lastModifiedBy, Administrator? createdBy)
    : base(lastModifiedBy, createdBy)
    {
        ValidateUser(firstName, lastName, address, birthday, phoneNumber);

        FirstName = firstName.Trim().ToLower();
        LastName = lastName.Trim().ToLower();
        Address = address;
        Birthday = birthday;
        PhoneNumber = phoneNumber;
        LastModifiedBy = lastModifiedBy;
        CreatedBy = createdBy;
    }

    protected void ValidateUser(string firstName, string lastName, string address, DateTime? birthday, string phoneNumber)
    {
        DomainExeptionValidation.When(string.IsNullOrEmpty(firstName), "Invalid first name, valid first name is required");
        DomainExeptionValidation.When(firstName.Length <= 3, "Invalid first name, too short, minimum 3 characters");

        DomainExeptionValidation.When(string.IsNullOrEmpty(lastName), "Invalid last name, valid last name is required");
        DomainExeptionValidation.When(lastName.Length <= 3, "Invalid last name, too short, minimum 3 characters");

        DomainExeptionValidation.When(ValidateAdress(address), "Invalid email address, valid email address is required");

        DomainExeptionValidation.When(birthday >= DateTimeOffset.Now.AddYears(-18), "Invalid birthday, minimum age is 18 years old");
        DomainExeptionValidation.When(ValidateNumber(phoneNumber), "Invalid number phone, valid number phone is required");
    }

    private bool ValidateAdress(string address)
    {
        string pattern = @"^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$";
        return Regex.IsMatch(address, pattern);
    }

    private bool ValidateNumber(string number)
    {
        string pattern = @"(?:([+]\d{1,4})[-.\s]?)?(?:[(](\d{1,3})[)][-.\s]?)?(\d{1,4})[-.\s]?(\d{1,4})[-.\s]?(\d{1,9})";
        return Regex.IsMatch(number, pattern);
    }
}
