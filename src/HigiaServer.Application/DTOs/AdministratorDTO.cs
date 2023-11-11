namespace HigiaServer.Application.DTOs;

public record AdministratorDTO
{
    [Key] public Guid? Id { get; set; }

    [Required(ErrorMessage = "First name is required")]
    [MinLength(3, ErrorMessage = "First name must be at least 3 characters long")]
    [MaxLength(18, ErrorMessage = "First name must be at most 18 characters long")]
    public required string FirstName { get; set; }

    [Required(ErrorMessage = "Last name is required")]
    [MinLength(3, ErrorMessage = "Last name must be at least 3 characters long")]
    [MaxLength(18, ErrorMessage = "Last name must be at most 18 characters long")]
    public required string LastName { get; set; }

    [Required(ErrorMessage = "Email address is required")]
    [EmailAddress(ErrorMessage = "Email address is not valid")]
    public required string Address { get; set; }

    [DataType(DataType.Date)]
    [Required(ErrorMessage = "Birthday is required")]
    public DateTime Birthday { get; set; }

    [Required(ErrorMessage = "Phone number is required")]
    [Phone(ErrorMessage = "Phone number is not valid")]
    public required string PhoneNumber { get; set; }
}