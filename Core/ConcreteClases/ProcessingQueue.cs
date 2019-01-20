using Core.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.ConcreteClases
{
    public class ProcessingQueue : IProcessingQueue
    {
        private BlockingCollection<IProcessingTask> _qeue;
        public ProcessingQueue()
        {
            _qeue = new BlockingCollection<IProcessingTask>();
        }

        bool IProcessingQueue.AddTask(IProcessingTask task)
        {
            var success = _qeue.TryAdd(task);
            if (success)
            {
                task.CurrentStatus = ProcessingTaskStatus.WaitingInQueue;
                Console.WriteLine("Task added " + task.TaskId);
            }
            return success;
        }

        IEnumerable<IProcessingTask> IProcessingQueue.GetTasksInQueue()
        {
            return _qeue;
        }

        IProcessingTask IProcessingQueue.TakeTaskToProcess()
        {
            var firstTask = _qeue
                 .Where(t => t.CurrentStatus == ProcessingTaskStatus.WaitingInQueue)
                 .OrderBy(t => t.BornTime)
                 .FirstOrDefault();
            return firstTask;
        }
    }
}
