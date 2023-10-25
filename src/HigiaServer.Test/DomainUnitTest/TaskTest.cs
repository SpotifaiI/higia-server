using Task = HigiaServer.Domain.Entities.Task;

namespace HigiaServer.Test.DomainUnitTest;

public class TaskTest
{
    private static readonly string InitialCoordinate = "24.53525235, 23.45235";
    private static readonly string EndCoordinate = "24.53525235, 23.45235";
    private static readonly string Description = "Description";
    private static readonly string Observation = "Observation";
    private static readonly DateTime InitialTime = DateTime.Now;
    private static readonly DateTime ExpectedEndTime = DateTime.Now.AddDays(3);
    private static readonly DateTime StartTime = DateTime.Now.AddDays(1);

    private readonly Task _task;

    public TaskTest()
    {
        _task = new Task(InitialCoordinate, EndCoordinate, Description, Observation, InitialTime,
            ExpectedEndTime);
    }

    [Fact(DisplayName = "Create Task With Valid State")]
    public void CreateTask_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Task(InitialCoordinate, EndCoordinate, Description, Observation,
            InitialTime, ExpectedEndTime);
        action.Should().NotThrow<DomainExeptionValidation>();
    }

    [Fact(DisplayName = "Create Valid Task With Null Description")]
    public void CreateTask_WithNullDescription_ResultObjectValidState()
    {
        Action action = () => new Task(InitialCoordinate, EndCoordinate, null, Observation,
            InitialTime, ExpectedEndTime);
        action.Should().NotThrow<DomainExeptionValidation>();
    }

    [Fact(DisplayName = "Create Valid Task With Null Observation")]
    public void CreateTask_WithNullObservation_ResultObjectValidState()
    {
        Action action = () => new Task(InitialCoordinate, EndCoordinate, Description, null,
            InitialTime, ExpectedEndTime);
        action.Should().NotThrow<DomainExeptionValidation>();
    }

    [Theory(DisplayName = "Create Task With Invalid Initial Coordinate")]
    [InlineData("")]
    [InlineData("24.53525235")]
    [InlineData("24.53525235,")]
    [InlineData(", 23.45235")]
    [InlineData("24.53525235, 23.45235, 23.45235")]
    public void CreateTask_WithInvalidInitialCoordinate_ResultObjectInvalidState(string initialCoordinate)
    {
        Action action = () => new Task(initialCoordinate, EndCoordinate, Description, Observation,
            InitialTime, ExpectedEndTime);
        action.Should().Throw<DomainExeptionValidation>()
            .WithMessage("Invalid initial coordinate, valid initial coordinate is required");
    }

    [Theory(DisplayName = "Create Task With Invalid End Coordinate")]
    [InlineData("")]
    [InlineData("24.53525235")]
    [InlineData("24.53525235,")]
    [InlineData(", 23.45235")]
    [InlineData("24.53525235, 23.45235, 23.45235")]
    public void CreateTask_WithInvalidEndCoordinate_ResultObjectInvalidState(string endCoordinate)
    {
        Action action = () => new Task(InitialCoordinate, endCoordinate, Description, Observation,
            InitialTime, ExpectedEndTime);
        action.Should().Throw<DomainExeptionValidation>()
            .WithMessage("Invalid end coordinate, valid end coordinate is required");
    }

    [Fact(DisplayName = "Create Task With Invalid Initial Time")]
    public void CreateTask_WithInvalidInitialTime_ResultObjectInvalidState()
    {
        Action action = () => new Task(InitialCoordinate, EndCoordinate, Description, Observation,
            DateTime.Now.AddMinutes(-10), ExpectedEndTime);
        action.Should().Throw<DomainExeptionValidation>()
            .WithMessage("Invalid initial time, valid initial time is required");
    }

    [Fact(DisplayName = "Create Task With Invalid Expected End Time")]
    public void CreateTask_WithInvalidExpectedEndTime_ResultObjectInvalidState()
    {
        Action action = () => new Task(InitialCoordinate, EndCoordinate, Description, Observation,
            InitialTime, DateTime.Now.AddDays(-1));
        action.Should().Throw<DomainExeptionValidation>().WithMessage("Invalid end time, valid end time is required");
    }

    [Fact(DisplayName = "Create Task With Invalid Description")]
    public void CreateTask_WithInvalidDescription_ResultObjectInvalidState()
    {
        Action action = () => new Task(InitialCoordinate, EndCoordinate, "A", Observation,
            InitialTime, ExpectedEndTime);
        action.Should().Throw<DomainExeptionValidation>()
            .WithMessage("Invalid description, valid description is required");
    }

    [Fact(DisplayName = "Create Task With Invalid Observation")]
    public void CreateTask_WithInvalidObservation_ResultObjectInvalidState()
    {
        Action action = () => new Task(InitialCoordinate, EndCoordinate, Description, "A",
            InitialTime, ExpectedEndTime);
        action.Should().Throw<DomainExeptionValidation>()
            .WithMessage("Invalid observation, valid observation is required");
    }

    [Fact(DisplayName = "Update Description To Task With Valid State")]
    public void UpdateDescriptionToTask_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => _task.UpdateDescriptionToTask("New Description");
        action.Should().NotThrow<DomainExeptionValidation>();
    }

    [Theory(DisplayName = "Update Description To Task With Invalid Description")]
    [InlineData("")]
    [InlineData("A")]
    [InlineData("AB")]
    public void UpdateDescriptionToTask_WithInvalidDescription_ResultObjectInvalidState(string description)
    {
        Action action = () => _task.UpdateDescriptionToTask(description);
        action.Should().Throw<DomainExeptionValidation>()
            .WithMessage("Invalid description, valid description is required");
    }

    [Fact(DisplayName = "Update Observation To Task With Valid State")]
    public void UpdateObservationToTask_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => _task.UpdateObservationToTask("New Observation");
        action.Should().NotThrow<DomainExeptionValidation>();
    }

    [Theory(DisplayName = "Update Observation To Task With Invalid Observation")]
    [InlineData("")]
    [InlineData("A")]
    [InlineData("AB")]
    public void UpdateObservationToTask_WithInvalidObservation_ResultObjectInvalidState(string observation)
    {
        Action action = () => _task.UpdateObservationToTask(observation);
        action.Should().Throw<DomainExeptionValidation>()
            .WithMessage("Invalid observation, valid observation is required");
    }

    [Fact(DisplayName = "Update Initial Coordinate To Task With Valid State")]
    public void UpdateInitialCoordinateToTask_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => _task.UpdateInitialCoordinateToTask("24.53525235, 23.45235");
        action.Should().NotThrow<DomainExeptionValidation>();
    }

    [Theory(DisplayName = "Update Initial Coordinate To Task With Invalid Initial Coordinate")]
    [InlineData("")]
    [InlineData("24.53525235")]
    [InlineData("24.53525235,")]
    [InlineData(", 23.45235")]
    [InlineData("24.53525235, 23.45235, 23.45235")]
    public void UpdateInitialCoordinateToTask_WithInvalidInitialCoordinate_ResultObjectInvalidState(
        string initialCoordinate)
    {
        Action action = () => _task.UpdateInitialCoordinateToTask(initialCoordinate);
        action.Should().Throw<DomainExeptionValidation>()
            .WithMessage("Invalid initial coordinate, valid initial coordinate is required");
    }

    [Fact(DisplayName = "Update End Coordinate To Task With Valid State")]
    public void UpdateEndCoordinateToTask_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => _task.UpdateEndCoordinateToTask("24.53525235, 23.45235");
        action.Should().NotThrow<DomainExeptionValidation>();
    }

    [Theory(DisplayName = "Update End Coordinate To Task With Invalid End Coordinate")]
    [InlineData("")]
    [InlineData("24.53525235")]
    [InlineData("24.53525235,")]
    [InlineData(", 23.45235")]
    [InlineData("24.53525235, 23.45235, 23.45235")]
    public void UpdateEndCoordinateToTask_WithInvalidEndCoordinate_ResultObjectInvalidState(string endCoordinate)
    {
        Action action = () => _task.UpdateEndCoordinateToTask(endCoordinate);
        action.Should().Throw<DomainExeptionValidation>()
            .WithMessage("Invalid end coordinate, valid end coordinate is required");
    }

    [Fact(DisplayName = "Update Initial Time To Task With Valid State")]
    public void UpdateInitialTimeToTask_WithValidParameters_ResultObjectValidState()
    {
        Task task = new(InitialCoordinate, EndCoordinate, Description, Observation,
            DateTime.Now.AddDays(1), ExpectedEndTime);
        Action action = () => _task.UpdateInitialTimeToTask(DateTime.Now.AddDays(2));
        action.Should().NotThrow<DomainExeptionValidation>();
    }

    [Fact(DisplayName = "Update Initial Time To Task With Invalid Initial Time")]
    public void UpdateInitialTimeToTask_WithInvalidInitialTime_ResultObjectInvalidState()
    {
        Task task = new(InitialCoordinate, EndCoordinate, Description, Observation,
            DateTime.Now.AddDays(1), ExpectedEndTime);
        Action action = () => _task.UpdateInitialTimeToTask(DateTime.Now.AddDays(-1));
        action.Should().Throw<DomainExeptionValidation>()
            .WithMessage("Invalid initial time, valid initial time is required");
    }

    [Fact(DisplayName = "Update Expected End Time To Task With Valid State")]
    public void UpdateExpectedEndTimeToTask_WithValidParameters_ResultObjectValidState()
    {
        Task task = new(InitialCoordinate, EndCoordinate, Description, Observation,
            InitialTime, DateTime.Now.AddDays(1));
        Action action = () => _task.UpdateExpectedEndTimeToTask(DateTime.Now.AddDays(2));
        action.Should().NotThrow<DomainExeptionValidation>();
    }

    [Fact(DisplayName = "Update Expected End Time To Task With Invalid Expected End Time")]
    public void UpdateExpectedEndTimeToTask_WithInvalidExpectedEndTime_ResultObjectInvalidState()
    {
        Task task = new(InitialCoordinate, EndCoordinate, Description, Observation,
            InitialTime, DateTime.Now.AddDays(1));
        Action action = () => _task.UpdateExpectedEndTimeToTask(DateTime.Now.AddDays(-1));
        action.Should().Throw<DomainExeptionValidation>().WithMessage("Invalid end time, valid end time is required");
    }
}