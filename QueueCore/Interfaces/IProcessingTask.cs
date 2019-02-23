using System;

namespace Core.Interfaces
{
    public interface IProcessingTask
    {
        string TaskId { get; }
        ProcessingTaskStatus CurrentStatus { get; set; }
        DateTime BornTime { get; }
        string ProcessedBy { get; set; }
        int ProcessedTime { get; set; }
        event EventHandler TaskCanceledEvent;
        bool Cancel();
    }
}