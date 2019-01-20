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
        ITaskProcessingService _service = new ProcessingQueueService();

        [TestMethod]
        public void StartService()
        {
            _service.StartService();
            Assert.IsTrue(_service.ServiceTask.Status == TaskStatus.Running || _service.ServiceTask.Status == TaskStatus.WaitingToRun);
        }

        [TestMethod]
        public void AddTask()
        {
             _service.StartService();
            var task = new ProcessingTask();
            _service.ProcessingQueue.AddTask(task);
            Assert.IsTrue(_service.ProcessingQueue.GetTasksInQueue().Contains(task));
        }
    }
}
