using Core.ConcreteClases;
using Core.Interfaces;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace Indeed.Controllers.API
{
   
    public class ProcessingQueueController : ApiController
    {
        private ITaskProcessingService taskProcServise;

        public ProcessingQueueController(ITaskProcessingService taskProcServise)
        {
            this.taskProcServise = taskProcServise;
        }

        [HttpGet]
        public ActionResult AddNewTask()
        {
            var task = new ProcessingTask();
            try
            {
                taskProcServise.AddTaskToQueue(task);
            }
            catch (System.Exception e)
            {
               return new HttpStatusCodeResult(500, "Error adding message to queue");
                // log exception here
            }

            return new HttpStatusCodeResult(200, task.TaskId);
        }

        [HttpGet]
        public string GetTaskStatus(string taskId)
        {
            var task = GetTaskByTaskId(taskId);
            return task.CurrentStatus.ToString();
        }

        [HttpGet]
        public ActionResult CancelTask(string taskId)
        {
            var task = GetTaskByTaskId(taskId);
            if (task.Cancel())
            {
                return new HttpStatusCodeResult(200, task.TaskId + " Canceled");
            }

            return new HttpStatusCodeResult(204, task.TaskId + " Unable to cancel");
        }

        [HttpGet]
        public IProcessingTask GetTaskByTaskId(string taskId)
        {
            return taskProcServise.ProcessingQueue.GetAllTasksInQueue()
                .SingleOrDefault(t => t.TaskId.ToString() == taskId);
        }
    }
}