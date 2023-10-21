using System.Text.RegularExpressions;

using HigiaServer.Domain.Common;
using HigiaServer.Domain.Entities;
using HigiaServer.Domain.Validations;

namespace HigiaServer.Domain;

public class Task : BaseAuditableEntity
{
    public string InitialCoordinate { get; private set; }
    public string EndCoordinate { get; private set; }
    
    public string Description { get; private set; }
    public string Observation { get; private set; }

    public DateTimeOffset InitialTime { get; private set; }
    public DateTimeOffset EndTime { get; set; }
    public DateTimeOffset StartTime { get; set; }

    public Task(Administrator? lastModifiedBy, Administrator? createdBy, string initialCoordinate, string endCoordinate, string description, string observation) : base(lastModifiedBy, createdBy)
    {
        ValidateTask(initialCoordinate, endCoordinate, description, observation);

        InitialCoordinate = initialCoordinate;
        EndCoordinate = endCoordinate;
        Description = description.Trim();
        Observation = observation.Trim();
    }

   private void ValidateTask(string initialCoordinate, string endCoordinate, string description, string observation)
   {
        DomainExeptionValidation.When(ValidateCoordinate(initialCoordinate), "Invalid initial coordinate, valid initial coordinate is required");
        DomainExeptionValidation.When(ValidateCoordinate(endCoordinate), "Invalid end coordinate, valid end coordinate is required");

        DomainExeptionValidation.When(string.IsNullOrEmpty(description), "Invalid description, valid description is required");
        DomainExeptionValidation.When(string.IsNullOrEmpty(observation), "Invalid observation, valid observation is required");
   }

   private bool ValidateCoordinate(string coordinate)
   {
        string pattern = @"^-?(90|[0-8]?\d)(\.\d+)?, *-?(180|1[0-7]\d|\d?\d)(\.\d+)?$";
        return Regex.IsMatch(coordinate, pattern);
   }
}
