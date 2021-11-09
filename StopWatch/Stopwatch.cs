using System;

namespace StopWatch
{
    class Stopwatch
    {
        private int d = 0;
        private int h = 0;
        private int m = 0;
        private int s = 0;

        public string Timer()
        {
            s++;
            if (s == 59)
            {
                Console.Clear();
                s = 0;
                m++;
                if (m == 59)
                {
                    Console.Clear();
                    m = 0;
                    h++;
                    if (h == 24)
                    {
                        Console.Clear();
                        h = 0;
                        d++;
                    }
                }
            }
            return $"D: {d} H: {h} M: {m} S: {s}";
        }
    }
}
