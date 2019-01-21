using Core.Abstracts;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Core.ConcreteClases
{
    public class ProcessingQueueService : ITaskProcessingService
    {
        private static readonly Lazy<ProcessingQueueService> lazy =
        new Lazy<ProcessingQueueService>(() => new ProcessingQueueService());

        public static ITaskProcessingService Instance { get { return lazy.Value; } }

        public ProcessingQueueService()
        {
            Operators = new List<AbstractEmployee> { new Operator() };
            Managers = new List<AbstractEmployee> { new Manager() };
            Directors = new List<AbstractEmployee> { new Director() };

            Tm_milliseconds = 100;
            Td_milliseconds = 200;

            ProcessingQueue = new ProcessingQueue();
        }

        public IEnumerable<AbstractEmployee> Operators { get; set; }
        public IEnumerable<AbstractEmployee> Managers { get; set; }
        public IEnumerable<AbstractEmployee> Directors { get; set; }
        public IProcessingQueue ProcessingQueue { get; set; }
        public int Tm_milliseconds { get; set; }
        public int Td_milliseconds { get; set; }
        public Task ServiceTask { get; private set; }

        public void AddTaskToQueue(IProcessingTask task)
        {
            ProcessingQueue.AddTask(task);
        }

        public void AssignTaskToFreeEmployee(IProcessingTask task)
        {
            var employee = FindFreeEmployee(task);
            if (employee != null)
            {
                employee.AssignTask(task);
            }
        }

        public void StartService()
        {
            if (this.ServiceTask == null)
            {
                this.ServiceTask = Task.Factory.StartNew(() =>
                {
                    Console.WriteLine("ProcessingQueueService Started");
                    while (true)
                    {
                        CheckQeue();
                        Thread.Sleep(100);
                    }
                });
            }
        }

        private void CheckQeue()
        {
            var waitingTasks = ProcessingQueue?.TakeTaskToProcess();

            if (waitingTasks != null)
            {
                AssignTaskToFreeEmployee(waitingTasks);
            }
        }

        private AbstractEmployee FindFreeEmployee(IProcessingTask task)
        {
            var freeEmployee = Operators?.SingleOrDefault(o => o.CurrentStatus == EmployeeStatus.Free);
            if (freeEmployee == null && (System.DateTime.Now - task.BornTime).Milliseconds >= Tm_milliseconds)
            {
                freeEmployee = Managers?.SingleOrDefault(m => m.CurrentStatus == EmployeeStatus.Free);
            }
            if (freeEmployee == null && (System.DateTime.Now - task.BornTime).Milliseconds >= Td_milliseconds)
            {
                freeEmployee = Directors?.SingleOrDefault(d => d.CurrentStatus == EmployeeStatus.Free);
            }

            return freeEmployee;
        }
    }
}

