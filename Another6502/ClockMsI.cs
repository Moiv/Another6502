using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Another6502
{
    class ClockMsI : Clock
    {
        //private Stopwatch _stopwatch;

        //public new Int64 AverageKhz { get { return GetAverageKhz(); } }
        //public new float AverageMhz { get { return GetAverageMhz(); } }
        //public new Int64 CurrentKhz { get { return GetCurrentKhz(); } }
        //public new Int64 Ticks { get; private set; }
        //public new Double ElapsedMilliseconds { get { return _stopwatch.ElapsedMilliseconds; } }
        //public Int64 ElapsedTicks { get { return _stopwatch.ElapsedTicks; } }
        //public new bool IsRunning { get; private set; }

        private int _targetKhz = 10000;

        private static int _tickRecordSize = 20000;
        private static int _tickRecordSampleSize = 4;
        private static int _tickInterval = 250;
        private int _tickRecord = -1;
        private Int64[] _tickRecordBank = new Int64[_tickRecordSize];
        private double _nextTickRecordMs = 0;

        public new Int64 TickRecord { get { return _tickRecord; } }

        public ClockMsI()
        {
            //_stopwatch = new Stopwatch();
            IsRunning = false;
        }

        //public void Reset()
        //{
        //    Stop();
        //    Ticks = 0;
        //    _stopwatch.Reset();
        //}

        //public void Start()
        //{
        //    IsRunning = true;
        //    _stopwatch.Start();
        //}

        //public void Stop()
        //{
        //    _stopwatch.Stop();
        //    IsRunning = false;
        //}

        //public void SetTargetKhz(int khz)
        //{
        //    if (khz < 1) return;
        //    _targetKhz = khz;
        //}

        public override void Tick()
        {
            if (!IsRunning || Throttling()) return;

            if (_stopwatch.Elapsed.TotalMilliseconds > _nextTickRecordMs)
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

        protected override Int64 GetAverageKhz()
        {
            if (_stopwatch.ElapsedMilliseconds == 0) return 0;
            return Ticks / _stopwatch.ElapsedMilliseconds;
        }

        protected override float GetAverageMhz()
        {
            if (_stopwatch.ElapsedMilliseconds == 0) return 0;
            //return (Ticks / 1000) / _stopwatch.ElapsedMilliseconds;
            return (Ticks / 1000) / (float)_stopwatch.Elapsed.TotalMilliseconds;
        }

        protected override Int64 GetCurrentKhz()
        {
            if (_tickRecordBank[_tickRecordSampleSize] == 0) return 0; // We haven't yet filled up our array so we can't calculate throttling
            var comparerRecord = _tickRecord > _tickRecordSampleSize ? _tickRecord - _tickRecordSampleSize : 0;
            var comparerTicks = _tickRecordBank[comparerRecord];
            var elapsedTicks = _tickRecordBank[_tickRecord] - comparerTicks;

            Console.SetCursorPosition(0, 15);
            Console.WriteLine(string.Format("{0}     {1}    ", comparerRecord, _tickRecord));
            Console.Write(string.Format("{0} {1} {2}     ", comparerTicks, _tickRecordBank[_tickRecord], elapsedTicks));
            Console.SetCursorPosition(15, 8);

            return elapsedTicks / 1000;
        }

        protected override void RecordTick()
        {
            _nextTickRecordMs += _tickInterval;

            if (_tickRecord >= _tickRecordSize - 1)
                _tickRecord = -1;

            _tickRecord++;
            _tickRecordBank[_tickRecord] = Ticks;
        }
    }
}
