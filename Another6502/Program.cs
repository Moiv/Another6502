using System;

namespace Another6502
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing max Clock object speed");
            
            var clock = new Clock();
            var starttime = DateTime.Now;
            var endtime = DateTime.Now.AddSeconds(20);

            clock.Start();
            System.Threading.Thread.Sleep(2);

            Console.WriteLine("Looping for 20sec");
            Console.SetCursorPosition(0, 4);
            Console.Write("Ticks\nElapsed Ms\nAve Khz\nAve Mhz");

            while (clock.ElapsedMilliseconds < 20000)
            {
                clock.Tick();
                if ((clock.ElapsedMilliseconds % 500) == 0)
                {
                    Console.SetCursorPosition(15, 4);
                    Console.Write(clock.Ticks);
                    Console.SetCursorPosition(15, 5);
                    Console.Write(clock.ElapsedMilliseconds);
                    Console.SetCursorPosition(15, 6);
                    Console.Write(clock.AverageKhz);
                    Console.SetCursorPosition(15, 7);
                    Console.Write(clock.AverageMhz);
                }

            }

            System.Threading.Thread.Sleep(5000);
        }
    }
}
