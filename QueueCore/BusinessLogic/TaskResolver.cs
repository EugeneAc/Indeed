using System.Threading.Tasks;
using System.Threading;
using System.Web.Hosting;

namespace Core.BusinessLogic
{
    public static class TaskResolver
    {
        public static async Task CompleteTask(Interfaces.IProcessingTask task, int _processingTimeMin)
        {
            HostingEnvironment.QueueBackgroundWorkItem(async ct =>
            {
                var cancelationToken = CancellationTokenSource.CreateLinkedTokenSource(ct);
                task.TaskCanceledEvent += (o, e) =>
                {
                    cancelationToken.Cancel();
                };

                // Some business logic here
                Thread.Sleep(_processingTimeMin);
            });
        }
    }
}
