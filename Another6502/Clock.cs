using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Another6502
{
    class Clock : IClock
    {
        Stopwatch _stopwatch;

        public Int64 AverageKhz { get { return GetAverageKhz(); } }
        public Int64 AverageMhz { get { return GetAverageMhz(); } }
        public Int64 Ticks { get; private set; }
        public Int64 ElapsedMilliseconds { get { return _stopwatch.ElapsedMilliseconds; } }
        public bool IsRunning { get; private set; }


        public Clock()
        {
            _stopwatch = new Stopwatch();
            IsRunning = false;
        }

        public void Reset()
        {
            Stop();
            Ticks = 0;
            _stopwatch.Reset();
        }

        public void Start()
        {
            IsRunning = true;
            _stopwatch.Start();
        }

        public void Stop()
        {
            _stopwatch.Stop();
            IsRunning = false;
        }

        public void Tick()
        {
            Ticks++;
        }

        private Int64 GetAverageKhz()
        {
            return Ticks / _stopwatch.ElapsedMilliseconds;
        }

        private Int64 GetAverageMhz()
        {
            return (Ticks / 1000) / _stopwatch.ElapsedMilliseconds;
        }
    }
}
