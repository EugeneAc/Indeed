using Core.Abstracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ITaskProcessingService
    {
        IEnumerable<AbstractEmployee> Operators { get; set; }
        IEnumerable<AbstractEmployee> Managers { get; set; }
        IEnumerable<AbstractEmployee> Directors { get; set; }

        IProcessingQueue ProcessingQueue { get; set; }

        int Tm_milliseconds { get; set; }
        int Td_milliseconds { get; set; }
        Task ServiceTask { get; }

        void StartService();
        void AddTaskToQueue(IProcessingTask task);
        void AssignTaskToFreeEmployee(IProcessingTask task);
    }
}
