namespace Core
{
    public enum ProcessingTaskStatus
    {
        WaitingInQueue,
        WorkInProcess,
        Completed,
        Canceled,
        NewUnadded
    }
}
