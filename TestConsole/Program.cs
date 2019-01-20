using Indeed.Tests;
using System;
using System.Threading;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = new ProcessingQueueServiceTest();
            test.StartService();
            Console.ReadLine();
            test.AddTask();
            Thread.Sleep(100);
            test.AddTask();
            Thread.Sleep(100);
            test.AddTask();
            Thread.Sleep(100);
            test.AddTask();
            Thread.Sleep(100);
            test.AddTask();
            Thread.Sleep(100);
            test.AddTask();
            Console.ReadLine();
        }
    }
}
