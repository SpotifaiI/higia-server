using System.Security.Cryptography;

using HigiaServer.Domain.Enums;

namespace HigiaServer.Domain.Entities;

public class Task(string title, string[] coordinates, UrgencyLevel urgencyLevel, string? description)
{
    #region [Properties]

    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Title { get; private set; } = title;
    public UrgencyLevel UrgencyLevel { get; private set; } = urgencyLevel;
    public string? Description { get; private set; } = description;
    public string[] Coordinates { get; private set; } = coordinates;
    public Status Status { get; private set; } = Status.New;
    public List<User> Collaborators { get; private set; } = [];
    public RecordTask RecordTask { get; private set; } = new RecordTask();

    #endregion
    
    #region [Public Methods]

    public void UpdateTask(string? title = null, string? description = null, string[]? coordinates = null)
    {
        Title = title ?? Title;
        Description = description ?? Description;
        Coordinates = coordinates ?? Coordinates;
    }

    public void AddCollaboratorToTask(User user) => Collaborators.Add(user);

    public void AddCollaboratorsToTask(List<User> user) => Collaborators.AddRange(user);

    public void RemoveCollaboratorFromTask(User user) => Collaborators.Remove(user);

    public void UpdateTaskStatus(Status newStatus)
    {
        if(newStatus == Status.New) return;

        switch (newStatus)
        {
            case Status.Active: StartTask();  break;
            case Status.Paused: PauseTask(); break;
            case Status.Complete: CompleteTask(); break;
        }
    }

    #endregion
    
    #region [Private Methods]
    private void StartTask()
    {
        if(Status == Status.New)
        {
            Status = Status.Active;
            RecordTask.RecordActiveTask();
        }
    }

    private void PauseTask()
    {
        if(Status == Status.Active)
        {
            Status = Status.Paused;
            RecordTask.RecordPausedTask();
        }
    }

    private void CompleteTask()
    {
        if(Status == Status.Active || Status == Status.Paused)
        {
            Status = Status.Complete;
            RecordTask.RecordCompleteTask();
        }
    }

    #endregion
}