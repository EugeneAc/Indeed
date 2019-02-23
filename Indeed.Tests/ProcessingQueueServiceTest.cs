using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Core.ConcreteClases;
using Core.Interfaces;
using System.Linq;

namespace Indeed.Tests
{
    [TestClass]
    public class ProcessingQueueServiceTest
    {
        [TestMethod]
        public void StartService()
        {
            var service = new ProcessingQueueService(new ProcessingQueue());

            Assert.IsTrue(service.ServiceTask.Status == TaskStatus.Running || service.ServiceTask.Status == TaskStatus.WaitingToRun);
        }

        [TestMethod]
        public void AddTask()
        {
            var service = new ProcessingQueueService(new ProcessingQueue());
            var task = new ProcessingTask();

            service.ProcessingQueue.AddTask(task);

            Assert.IsTrue(service.ProcessingQueue.GetAllTasksInQueue().Contains(task));
        }
    }
}
