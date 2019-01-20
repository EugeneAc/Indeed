using System;
using System.Collections.Generic;
using System.Text;

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
