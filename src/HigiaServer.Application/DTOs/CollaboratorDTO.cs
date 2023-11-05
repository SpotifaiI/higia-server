using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HigiaServer.Application.DTOs;

public class CollaboratorDTO
{
    [Required(ErrorMessage = "First name is required")]
    [MinLength(3, ErrorMessage = "First name must be at least 3 characters long")]
    [MaxLength(18, ErrorMessage = "First name must be at most 18 characters long")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Last name is required")]
    [MinLength(3, ErrorMessage = "Last name must be at least 3 characters long")]
    [MaxLength(18, ErrorMessage = "Last name must be at most 18 characters long")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Email address is required")]
    [EmailAddress(ErrorMessage = "Email address is not valid")]
    public string Address { get; set; }

    [Required(ErrorMessage = "Birthday is required")]
    [Column(TypeName = "Date")]
    public DateTime Birthday { get; set; }

    [Required(ErrorMessage = "Phone number is required")]
    [Phone(ErrorMessage = "Phone number is not valid")]
    public string PhoneNumber { get; set; }

    public List<TaskDTO> Tasks { get; set; }
}
