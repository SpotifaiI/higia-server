namespace HigiaServer.Application.DTOs;

public record CollaboratorDTO
{
    [Key] public Guid? Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    [MinLength(3, ErrorMessage = "Name must be at least 3 characters long")]
    [MaxLength(64, ErrorMessage = "Name must be at most 64 characters long")]
    public required string Name { get; set; }

    [Required(ErrorMessage = "Email address is required")]
    [EmailAddress(ErrorMessage = "Email address is not valid")]
    public required string Email { get; set; }

    [DataType(DataType.Date)]
    [Required(ErrorMessage = "Birthday is required")]
    public DateTime Birthday { get; set; }

    [Required(ErrorMessage = "Phone number is required")]
    [Phone(ErrorMessage = "Phone number is not valid")]
    public required string PhoneNumber { get; set; }
}