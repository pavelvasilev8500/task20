using System;
using System.Collections.Generic;
using System.Threading;

namespace StopWatch
{
    class Controller
    {

        private string time { get; set; }
        private List<string> timeList = new List<string>();

        public void Manager()
        {
            Clear();
            while (true)
            {
                Console.WriteLine("Choose action:");
                var key = Console.ReadKey().Key;
                if (key == ConsoleKey.Q)
                {
                    Environment.Exit(0);
                }
                Console.WriteLine();
                switch (key)
                {
                    case ConsoleKey.NumPad1:
                        Start(key);
                        break;
                    case ConsoleKey.C:
                        Clear();
                        break;
                    default:
                        break;
                }
            }
        }

        private void Start(ConsoleKey key)
        {
            var sw = new Stopwatch();
            bool stopped = false;
            Thread t = new Thread(new ThreadStart(() =>
            {
                while (!stopped)
                {
                    time = sw.Timer();
                    Console.WriteLine(time);
                    Thread.Sleep(1000);
                }
            }));
            t.Start();
            while(key != ConsoleKey.NumPad3)
            {
                Console.WriteLine();
                key = Console.ReadKey().Key;
                if (key == ConsoleKey.NumPad3)
                {
                    stopped = true;
                }
                else if(key == ConsoleKey.NumPad2)
                {
                    timeList.Add(time);
                }
            }
            t.Join();
            Console.WriteLine();
            foreach(var ti in timeList)
            {
                Console.WriteLine(ti);
            }
        }

        public void Clear()
        {
            Console.Clear();
            Console.Write("Menu:" +
                          "\n1 - Start timer;" +
                          "\n2 - Interval;" +
                          "\nc - Clear;" +
                          "\nq - Exit." +
                          "\n");
        }

    }
}
