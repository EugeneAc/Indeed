using Core.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Abstracts
{
    public abstract class AbstractEmployee
    {
        protected IProcessingTask _currentTask;
        protected int _processingTime = 1000;
        public readonly string Title;

        protected AbstractEmployee(string title)
        {
            Title = title;
        }

        public EmployeeStatus CurrentStatus
        {
            get
            {
                return GetCurrentStatus();
            }
        }

        public virtual void AssignTask(IProcessingTask task)
        {
            _currentTask = task;
            task.CurrentStatus = ProcessingTaskStatus.WorkInProcess;
            WorkOnTask();
        }

        public virtual EmployeeStatus GetCurrentStatus()
        {
            return _currentTask != null ? EmployeeStatus.Working : EmployeeStatus.Free;
        }

        protected virtual async void WorkOnTask()
        {
            await Task.Factory.StartNew(() =>
            {
                Console.WriteLine(Title + " Works On Task " + _currentTask.TaskId);
                Thread.Sleep(_processingTime);
                Console.WriteLine(Title + " Finished working On Task " + _currentTask.TaskId);
                _currentTask = null;
            });
        }
    }
}
