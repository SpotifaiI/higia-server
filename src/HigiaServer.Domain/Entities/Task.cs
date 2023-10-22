using System.Text.RegularExpressions;

namespace HigiaServer.Domain.Entities;

public class Task : BaseAuditableEntity
{
    public string InitialCoordinate { get; private set; }
    public string EndCoordinate { get; private set; }

    public string? Description { get; private set; }
    public string? Observation { get; private set; }

    public DateTimeOffset InitialTime { get; private set; }
    public DateTimeOffset ExpectedEndTime { get; private set; }

    public DateTimeOffset EndTime { get; private set; }
    public DateTimeOffset StartTime { get; private set; }

    public void UpdateInitialTimeToTask(DateTimeOffset initialTime)
    {
        DomainExeptionValidation.When(initialTime < DateTimeOffset.Now.AddMinutes(-10),
            "Invalid initial time, valid initial time is required");
        InitialTime = initialTime;

        LastModified = DateTimeOffset.Now;
    }

    public void UpdateInitialCoordinateToTask(string initialCoordinate)
    {
        DomainExeptionValidation.When(ValidateCoordinate(initialCoordinate),
            "Invalid initial coordinate, valid initial coordinate is required");
        InitialCoordinate = initialCoordinate;

        LastModified = DateTimeOffset.Now;
    }

    public void UpdateEndCoordinateToTask(string endCoordinate)
    {
        DomainExeptionValidation.When(ValidateCoordinate(endCoordinate),
            "Invalid end coordinate, valid end coordinate is required");
        EndCoordinate = endCoordinate;

        LastModified = DateTimeOffset.Now;
    }

    public void UpdateExpectedEndTimeToTask(DateTimeOffset expectedEndTime)
    {
        DomainExeptionValidation.When(expectedEndTime < DateTimeOffset.Now,
            "Invalid end time, valid end time is required");
        ExpectedEndTime = expectedEndTime;

        LastModified = DateTimeOffset.Now;
    }

    public void UpdateDescriptionToTask(string description)
    {
        DomainExeptionValidation.When(description.Length < 3, "Invalid description, valid description is required");
        Description = description;

        LastModified = DateTimeOffset.Now;
    }

    public void UpdateObservationToTask(string observation)
    {
        DomainExeptionValidation.When(observation.Length < 3, "Invalid observation, valid observation is required");
        Observation = observation;

        LastModified = DateTimeOffset.Now;
    }

    public Task(Administrator? administrator, string initialCoordinate, string endCoordinate,
        string description, string observation, DateTimeOffset initialTime, DateTimeOffset expectedEndTime)
    {
        ValidateTask(initialCoordinate, endCoordinate, initialTime, expectedEndTime, description, observation);

        InitialCoordinate = initialCoordinate;
        EndCoordinate = endCoordinate;
        Description = description.Trim();
        Observation = observation.Trim();

        InitialTime = initialTime;
        ExpectedEndTime = expectedEndTime;

        CreatedBy = administrator;
        LastModifiedBy = administrator;
    }

    private void ValidateTask(string initialCoordinate, string endCoordinate, DateTimeOffset initialTime,
        DateTimeOffset expectedEndTime, string? description, string? observation)
    {
        DomainExeptionValidation.When(ValidateCoordinate(initialCoordinate),
            "Invalid initial coordinate, valid initial coordinate is required");
        DomainExeptionValidation.When(ValidateCoordinate(endCoordinate),
            "Invalid end coordinate, valid end coordinate is required");

        DomainExeptionValidation.When(initialTime < DateTimeOffset.Now.AddMinutes(-10),
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