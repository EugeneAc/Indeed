using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!Int32.TryParse(args.FirstOrDefault(), out int lowTimeLimit))
            {
                lowTimeLimit = 1000;
            }

            if (!Int32.TryParse(args.Skip(1).FirstOrDefault(), out int hightTimeLimit))
            {
                hightTimeLimit = 10000;
            }

            var hasRepeatCounter = UInt32.TryParse(args.Skip(2).FirstOrDefault(), out uint repeatCount);

            var rnd = new Random();
            string url = @"http://localhost:63485/api/ProcessingQueue/AddNewTask";
            while (hasRepeatCounter ? repeatCount > 0 : true)
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    Console.WriteLine(reader.ReadToEnd());
                }
                var sleeptime = rnd.Next(lowTimeLimit, hightTimeLimit);
                Console.WriteLine("Sleep " + sleeptime);
                Thread.Sleep(sleeptime);
                repeatCount--;
            }

            Console.WriteLine("End of cycle");
            Console.ReadLine();
        }


    }
}
