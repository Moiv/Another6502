using System;

namespace Another6502
{
    class Program
    {
        static void Main(string[] args)
        {
            TestClock();
            System.Threading.Thread.Sleep(3000);
            TestClock2();
            System.Threading.Thread.Sleep(3000);
        }

        static void TestClock()
        {
            var clocks = new Clock[] {
                //new Clock(),
                new ClockMsI(),
                new ClockTicks()
            };

            foreach (var clock in clocks)
            {
                Console.Clear();
                Console.WriteLine(string.Format("Testing max {0} object speed", clock.ToString()));

                var starttime = DateTime.Now;
                var endtime = DateTime.Now.AddSeconds(10);

                System.Threading.Thread.Sleep(2000); // Let the system stabalise
                clock.Start();


                Console.WriteLine("Looping for 20sec");
                Console.SetCursorPosition(0, 4);
                Console.WriteLine("Ticks\nElapsed Ms\nAve Khz\nAve Mhz\nCur Khz");

                while (clock.ElapsedMilliseconds < 10000)
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

                System.Threading.Thread.Sleep(3000);
            }
        }

        static void TestClock2()
        {
            Console.Clear();
            Console.WriteLine("Testing max ClockMs object speed");

            var clock2 = new ClockMs();
            var starttime = DateTime.Now;
            var endtime = DateTime.Now.AddSeconds(10);

            System.Threading.Thread.Sleep(2000); // Let the system stabalise
            clock2.Start();


            Console.WriteLine("Looping for 20sec");
            Console.SetCursorPosition(0, 4);
            Console.WriteLine("Ticks\nElapsed Ms\nAve Khz\nAve Mhz\nCur Khz");

            while (clock2.ElapsedMilliseconds < 10000)
            {
                clock2.Tick();
                if ((clock2.ElapsedMilliseconds % 500) == 0)
                {
                    Console.SetCursorPosition(15, 4);
                    Console.Write(clock2.Ticks);
                    Console.SetCursorPosition(15, 5);
                    Console.Write(clock2.ElapsedMilliseconds);
                    Console.SetCursorPosition(15, 6);
                    Console.Write(clock2.AverageKhz);
                    Console.SetCursorPosition(15, 7);
                    Console.Write(clock2.AverageMhz);
                    Console.SetCursorPosition(15, 8);
                    Console.Write(clock2.CurrentKhz);

                    Console.SetCursorPosition(15, 10);
                    //Console.Write(clock2.TickRecordBankSelect);
                    Console.SetCursorPosition(15, 11);
                    Console.Write(clock2.TickRecord + "     ");
                }
            }
        }
    }
}
