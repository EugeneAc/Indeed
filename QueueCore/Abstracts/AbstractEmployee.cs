using Core.Interfaces;
using System;

namespace Core.Abstracts
{
    public abstract class AbstractEmployee
    {
        protected IProcessingTask _currentTask;
        protected int _processingTimeMin = 1000;
        protected int _processingTimeMax = 5000;
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

        public void SetProcessingTimeMin(int time)
        {
            this._processingTimeMin = time;
        }

        public void SetProcessingTimeMax(int time)
        {
            this._processingTimeMax = time;
        }

        public virtual void AssignTask(IProcessingTask task)
        {
            _currentTask = task;
            task.CurrentStatus = ProcessingTaskStatus.WorkInProcess;
            WorkOnTask(task);
        }

        public virtual EmployeeStatus GetCurrentStatus()
        {
            return _currentTask != null ? EmployeeStatus.Working : EmployeeStatus.Free;
        }

        protected virtual async void WorkOnTask(IProcessingTask task)
        {
            Console.WriteLine(Title + " Works On Task " + _currentTask.TaskId);
            await BusinessLogic.TaskResolver.CompleteTask(task, _processingTimeMin);
            Console.WriteLine(Title + " Finished working On Task " + _currentTask.TaskId);
            task.ProcessedTime = _processingTimeMin;
            task.ProcessedBy = Title;
            task.CurrentStatus = ProcessingTaskStatus.Completed;
            _currentTask = null;
        }
    }
}
