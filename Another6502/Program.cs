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

            System.Threading.Thread.Sleep(2000); // Let the system stabalise
            clock.Start();
            

            Console.WriteLine("Looping for 20sec");
            Console.SetCursorPosition(0, 4);
            Console.WriteLine("Ticks\nElapsed Ms\nAve Khz\nAve Mhz\nCur Khz");
            
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
                    Console.SetCursorPosition(15, 8);
                    Console.Write(clock.CurrentKhz);

                    Console.SetCursorPosition(15, 10);
                    //Console.Write(clock.TickRecordBankSelect);
                    Console.SetCursorPosition(15, 11);
                    Console.Write(clock.TickRecord + "     ");
                }

            }

            System.Threading.Thread.Sleep(5000);
        }
    }
}
