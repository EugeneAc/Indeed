using Core.Interfaces;
using System;

namespace Core.ConcreteClases
{
    public class ProcessingTask : IProcessingTask
    {
        public ProcessingTask()
        {
            this.TaskId = Guid.NewGuid();
            this.BornTime = System.DateTime.Now;
            this.CurrentStatus = ProcessingTaskStatus.NewUnadded;
        }

        public Guid TaskId { get; private set; }

        public ProcessingTaskStatus CurrentStatus { get ; set; }

        public DateTime BornTime { get; private set; }
    }
}
