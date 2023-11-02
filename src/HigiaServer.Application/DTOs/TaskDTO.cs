﻿using System.ComponentModel.DataAnnotations;

namespace HigiaServer.Application;

public class TaskDTO
{
    [Required(ErrorMessage = "Initial coordinate is required")]
    public string InitialCoordinate { get; set; }

    [Required(ErrorMessage = "End coordinate is required")]
    public string EndCoordinate { get; set; }
    
    [MinLength(3, ErrorMessage = "Description must be at least 3 characters long")]
    public string? Description { get; set; }
    public string? Observation { get; set; }

    public DateTime InitialTime { get; set; }
    public DateTime ExpectedEndTime { get; set; }

    public DateTime EndTime { get; set; }
    public DateTime StartTime { get; set; }
}
