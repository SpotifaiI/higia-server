using System.Text.RegularExpressions;

using HigiaServer.Domain.Common;
using HigiaServer.Domain.Validations;

namespace HigiaServer.Domain.Entities;

public class Task : BaseAuditableEntity
{
    public string InitialCoordinate { get; private set; }
    public string EndCoordinate { get; private set; }

    public string? Description { get; private set; }
    public string? Observation { get; private set; }

    public DateTimeOffset InitialTime { get; private set; }
    public DateTimeOffset EndTime { get; private set; }
    public DateTimeOffset StartTime { get; private set; }

    private void UpdateDescriptionToTask(string description)
    {
        ValidateTask(InitialCoordinate, EndCoordinate, InitialTime, EndTime, StartTime, description, Observation);
        Description = description;
    }

    private void UpdateObservationToTask(string observation)
    {
        ValidateTask(InitialCoordinate, EndCoordinate, InitialTime, EndTime, StartTime, Description, observation);
        Observation = observation;
    }

    public Task(Administrator? administrator, string initialCoordinate, string endCoordinate,
    string description, string observation, DateTimeOffset initialTime, DateTimeOffset endTime)
    {
        ValidateTask(initialCoordinate, endCoordinate, initialTime, EndTime, StartTime, description, observation);

        InitialCoordinate = initialCoordinate;
        EndCoordinate = endCoordinate;
        Description = description.Trim();
        Observation = observation.Trim();

        InitialTime = initialTime;
        EndTime = endTime;

        CreatedBy = administrator;
        LastModifiedBy = administrator;
    }

    private void ValidateTask(string initialCoordinate, string endCoordinate, DateTimeOffset initialTime, DateTimeOffset endTime, DateTimeOffset startTime, string? description, string? observation)
    {
        DomainExeptionValidation.When(ValidateCoordinate(initialCoordinate), "Invalid initial coordinate, valid initial coordinate is required");
        DomainExeptionValidation.When(ValidateCoordinate(endCoordinate), "Invalid end coordinate, valid end coordinate is required");

        DomainExeptionValidation.When(initialTime > DateTimeOffset.Now, "Invalid initial time, valid initial time is required");
        DomainExeptionValidation.When(endTime > DateTimeOffset.Now, "Invalid end time, valid end time is required");
        DomainExeptionValidation.When(startTime > initialTime, "Invalid start, valid start is required");

        DomainExeptionValidation.When(description?.Length > 3, "Invalid description, valid description is required");
        DomainExeptionValidation.When(observation?.Length > 3, "Invalid observation, valid observation is required");
    }

    private bool ValidateCoordinate(string coordinate)
    {
        string pattern = @"^-?(90|[0-8]?\d)(\.\d+)?, *-?(180|1[0-7]\d|\d?\d)(\.\d+)?$";
        return Regex.IsMatch(coordinate, pattern);
    }
}
