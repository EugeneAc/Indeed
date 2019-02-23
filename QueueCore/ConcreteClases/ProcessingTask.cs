using Core.Interfaces;
using System;

namespace Core.ConcreteClases
{
    public class ProcessingTask : IProcessingTask
    {
        public ProcessingTask()
        {
            this.TaskId = Guid.NewGuid().ToString();
            this.BornTime = System.DateTime.Now;
            this.CurrentStatus = ProcessingTaskStatus.NewUnadded;
        }

        public string TaskId { get; private set; }

        public ProcessingTaskStatus CurrentStatus { get ; set; }

        public DateTime BornTime { get; private set; }

        public string ProcessedBy { get; set; }

        public int ProcessedTime { get; set; }

        public event EventHandler TaskCanceledEvent;

        public bool Cancel()
        {
            if (this.CurrentStatus != ProcessingTaskStatus.Completed)
            {
                TaskCanceledEvent?.Invoke(this, new EventArgs());
                this.CurrentStatus = ProcessingTaskStatus.Canceled;
                return true;
            }

            return false;
        }
    }
}
