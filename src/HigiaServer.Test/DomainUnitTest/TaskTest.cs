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
}