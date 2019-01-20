using System;

namespace Core.Interfaces
{
    public interface IProcessingTask
    {
        Guid TaskId { get; }
        ProcessingTaskStatus CurrentStatus { get; set; }
        DateTime BornTime { get; }
    }
}