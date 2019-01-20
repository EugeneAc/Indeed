using Core.Interfaces;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;

namespace Indeed.Controllers.API
{
    public class ProcessingQueueController : ApiController
    {
        private ITaskProcessingService taskProcServise;

        [System.Web.Http.HttpPost]
        public ActionResult AddNewTask(IProcessingTask task)
        {
            try
            {
                taskProcServise.AddTaskToQueue(task);
            }
            catch (System.Exception)
            {
               return new HttpStatusCodeResult(500, "Error adding message to queue");
            }

            return new HttpStatusCodeResult(200);
        }

        public ActionResult GetTaskStatus(string taskId)
        {
            var task = GetTaskByTaskId(taskId);
            return new JsonResult { Data = task.CurrentStatus };
        }

        public ActionResult CancelTask(string taskId)
        {
            var task = GetTaskByTaskId(taskId);
            task.CurrentStatus = Core.ProcessingTaskStatus.Canceled;
            return new JsonResult { Data = task };
        }

        private IProcessingTask GetTaskByTaskId(string taskId)
        {
            return taskProcServise.ProcessingQueue.GetTasksInQueue()
                .SingleOrDefault(t => t.TaskId.ToString() == taskId);
        }
    }
}