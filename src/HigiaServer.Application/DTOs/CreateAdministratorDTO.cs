namespace HigiaServer.Application.DTOs;

public record class CreateAdministratorDTO : AdministratorDTO
{
    [Required(ErrorMessage = "Password is required")]
    [MinLength(6, ErrorMessage = "Password must be at least 6 characters long")]
    [MaxLength(18, ErrorMessage = "Password must be at most 18 characters long")]
    public required string Password { get; set; }
}
