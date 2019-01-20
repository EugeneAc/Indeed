using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IProcessingQueue
    {
        bool AddTask(IProcessingTask task);

        IProcessingTask TakeTaskToProcess();

        IEnumerable<IProcessingTask> GetTasksInQueue();
    };
}