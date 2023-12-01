namespace HigiaServer.Application.DTOs;

public record TaskDTO
{
    [Key] public Guid? Id { get; set; }

    [Required(ErrorMessage = "Initial coordinate is required")]
    public required string InitialCoordinate { get; set; }

    [Required(ErrorMessage = "End coordinate is required")]
    public required string EndCoordinate { get; set; }

    [MinLength(3, ErrorMessage = "Description must be at least 3 characters long")]
    [MaxLength(64, ErrorMessage = "Description must be at most 18 characters long")]
    public string? Description { get; set; }

    [MaxLength(244, ErrorMessage = "Observation must be at most 244 characters long")]
    public string? Observation { get; set; }

    [DataType(DataType.Date)] public required DateTime InitialTime { get; set; }

    [DataType(DataType.Date)] public required DateTime ExpectedEndTime { get; set; }

    [DataType(DataType.Date)] public DateTime? EndTime { get; set; }
    [DataType(DataType.Date)] public DateTime? StartTime { get; set; }
}