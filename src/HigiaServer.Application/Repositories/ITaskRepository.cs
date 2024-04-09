using HigiaServer.Domain.Entities;

namespace HigiaServer.Application.Repositories;

public interface ITaskRepository
{
    void AddTask(Domain.Entities.Task task);
}