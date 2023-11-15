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

    // public void UpdateInitialTimeToTask(DateTime initialTime)
    // {
    //     DomainExeptionValidation.When(initialTime < DateTime.Now.AddMinutes(-10),
    //         "Invalid initial time, valid initial time is required");
    //     InitialTime = initialTime;

    //     LastModifiedAt = DateTime.Now;
    // }

    // public void UpdateInitialCoordinateToTask(string initialCoordinate)
    // {
    //     DomainExeptionValidation.When(ValidateCoordinate(initialCoordinate),
    //         "Invalid initial coordinate, valid initial coordinate is required");
    //     InitialCoordinate = initialCoordinate;

    //     LastModifiedAt = DateTime.Now;
    // }

    // public void UpdateEndCoordinateToTask(string endCoordinate)
    // {
    //     DomainExeptionValidation.When(ValidateCoordinate(endCoordinate),
    //         "Invalid end coordinate, valid end coordinate is required");
    //     EndCoordinate = endCoordinate;

    //     LastModifiedAt = DateTime.Now;
    // }

    // public void UpdateExpectedEndTimeToTask(DateTime expectedEndTime)
    // {
    //     DomainExeptionValidation.When(expectedEndTime < DateTime.Now,
    //         "Invalid end time, valid end time is required");
    //     ExpectedEndTime = expectedEndTime;

    //     LastModifiedAt = DateTime.Now;
    // }

    // public void UpdateDescriptionToTask(string description)
    // {
    //     DomainExeptionValidation.When(description.Length < 3, "Invalid description, valid description is required");
    //     Description = description;

    //     LastModifiedAt = DateTime.Now;
    // }

    // public void UpdateObservationToTask(string observation)
    // {
    //     DomainExeptionValidation.When(observation.Length < 3, "Invalid observation, valid observation is required");
    //     Observation = observation;

    //     LastModifiedAt = DateTime.Now;
    // }

    private void ValidateTask(string initialCoordinate, string endCoordinate, DateTime initialTime,
        DateTime expectedEndTime, string? description, string? observation)
    {
        DomainExeptionValidation.When(ValidateCoordinate(initialCoordinate),
            "Invalid initial coordinate, valid initial coordinate is required");
        DomainExeptionValidation.When(ValidateCoordinate(endCoordinate),
            "Invalid end coordinate, valid end coordinate is required");

        DomainExeptionValidation.When(initialTime < DateTime.Now.AddMinutes(-10),
            "Invalid initial time, valid initial time is required");
        DomainExeptionValidation.When(expectedEndTime < initialTime, "Invalid end time, valid end time is required");

        DomainExeptionValidation.When(description?.Length < 3, "Invalid description, valid description is required");
        DomainExeptionValidation.When(observation?.Length < 3, "Invalid observation, valid observation is required");
    }

    private bool ValidateCoordinate(string coordinate)
    {
        string pattern = @"^-?(90|[0-8]?\d)(\.\d+)?, *-?(180|1[0-7]\d|\d?\d)(\.\d+)?$";
        return !Regex.IsMatch(coordinate, pattern);
    }
}