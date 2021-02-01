using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Another6502
{
    class Clock : IClock
    {
        protected Stopwatch _stopwatch;

        public Int64 AverageKhz { get { return GetAverageKhz(); } }
        public float AverageMhz { get { return GetAverageMhz(); } }
        public Int64 CurrentKhz { get { return GetCurrentKhz(); } }
        public Int64 Ticks { get; protected set; }
        public Int64 ElapsedMilliseconds { get { return _stopwatch.ElapsedMilliseconds; } }
        //public Int64 ElapsedTicks { get { return _stopwatch.ElapsedTicks; } }
        public bool IsRunning { get; protected set; }

        //private int _targetKhz = 8000;

        private static int _tickRecordSize = 20000;
        private static int _tickRecordSampleSize = 20;
        private static int _tickInterval = 1000;
        private int _tickRecord = -1;

        private Double[] _tickRecordBank = new Double[_tickRecordSize];

        public Int64 TickRecord { get { return _tickRecord; } }

        public Clock()
        {
            _stopwatch = new Stopwatch();
            IsRunning = false;
        }

        public virtual void Reset()
        {
            Stop();
            Ticks = 0;
            _stopwatch.Reset();
        }

        public virtual void Start()
        {
            IsRunning = true;
            _stopwatch.Start();
        }

        public virtual void Stop()
        {
            _stopwatch.Stop();
            IsRunning = false;
        }

        public virtual void SetTargetKhz(int khz)
        {
            //if (khz < 1) return;
            //_targetKhz = khz;
        }

        public virtual void Tick()
        {
            if (!IsRunning || Throttling()) return;

            if (Ticks % _tickInterval == 0)
                RecordTick();

            Ticks++;
        }

        private bool Throttling()
        {
            //if (_tickRecordBank[_tickRecordSize - 1] == 0) return false; // We haven't yet filled up our array so we can't calculate throttling
            
            //if (GetAverageKhz() > _targetKhz)
            //{
            //    //System.Threading.Thread.Sleep(50); // Doesn't work well
            //    return true;
            //}
            return false;
        }

        protected virtual Int64 GetAverageKhz()
        {
            if (_stopwatch.ElapsedMilliseconds == 0) return 0;
            return (Int64)(Ticks / _stopwatch.Elapsed.TotalMilliseconds);
        }

        protected virtual float GetAverageMhz()
        {
            if (_stopwatch.ElapsedMilliseconds == 0) return 0;
            return (Ticks / 1000) / (float)_stopwatch.Elapsed.TotalMilliseconds;
        }

        protected virtual Int64 GetCurrentKhz()
        {
            if (_tickRecordBank[_tickRecordSampleSize - 1] == 0) return 0; // We haven't yet filled up our array so we can't calculate throttling

            var comparerTick = _tickRecord > _tickRecordSampleSize ? _tickRecord - _tickRecordSampleSize : 0;
            var comparerMs = _tickRecordBank[comparerTick];
            var elapsedMs = _tickRecordBank[_tickRecord] - comparerMs;

            Console.SetCursorPosition(0, 15);
            Console.WriteLine(string.Format("BASE {0}     {1}    ", comparerTick, _tickRecord));
            Console.Write(string.Format("BASE {0} {1} {2}", comparerMs, _tickRecordBank[_tickRecord], elapsedMs));
            Console.SetCursorPosition(15, 8);
            
            return Convert.ToInt64((_tickRecordSampleSize * (double)_tickInterval) / elapsedMs);
        }

        protected virtual void RecordTick()
        {
            if (_tickRecord >= _tickRecordSize - 1)
                _tickRecord = -1;

            _tickRecord++;
            _tickRecordBank[_tickRecord] = _stopwatch.Elapsed.TotalMilliseconds;
        }
    }
}
