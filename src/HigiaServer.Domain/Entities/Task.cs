using System.Text.RegularExpressions;

namespace HigiaServer.Domain.Entities;

public class Task : BaseEntity
{
    public Task(string initialCoordinate, string endCoordinate,
        string? description, string? observation, DateTime initialTime, DateTime expectedEndTime)
    {
        ValidateTask(initialCoordinate, endCoordinate, initialTime, expectedEndTime, description, observation);

        InitialCoordinate = initialCoordinate;
        EndCoordinate = endCoordinate;
        Description = description?.Trim();
        Observation = observation?.Trim();

        InitialTime = initialTime;
        ExpectedEndTime = expectedEndTime;
    }

    public string InitialCoordinate { get; private set; }
    public string EndCoordinate { get; private set; }

    public string? Description { get; private set; }
    public string? Observation { get; private set; }

    public DateTime InitialTime { get; private set; }
    public DateTime ExpectedEndTime { get; private set; }

    public DateTime? EndTime { get; }
    public DateTime? StartTime { get; }

    public List<Collaborator>? Collaborators { get; } = new();

    public void AddCollaborator(Collaborator collaborator)
    {
        DomainExeptionValidation.When(Collaborators!.Contains(collaborator),
            "Collaborator already exists in this task");
        Collaborators.Add(collaborator);
    }

    private void ValidateTask(string initialCoordinate, string endCoordinate, DateTime initialTime,
        DateTime expectedEndTime, string? description, string? observation)
    {
        DomainExeptionValidation.When(ValidateCoordinate(initialCoordinate),
            "Invalid initial coordinate, valid initial coordinate is required");
        DomainExeptionValidation.When(ValidateCoordinate(endCoordinate),
            "Invalid end coordinate, valid end coordinate is required");

        DomainExeptionValidation.When(expectedEndTime < initialTime,
            "Expected end time must be greater than initial time");

        DomainExeptionValidation.When(description?.Length < 3, "Invalid description, valid description is required");
        DomainExeptionValidation.When(observation?.Length < 3, "Invalid observation, valid observation is required");
    }

    private bool ValidateCoordinate(string coordinate)
    {
        string pattern = @"^-?(90|[0-8]?\d)(\.\d+)?, *-?(180|1[0-7]\d|\d?\d)(\.\d+)?$";
        return !Regex.IsMatch(coordinate, pattern);
    }
}