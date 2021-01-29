using System;
using System.Collections.Generic;
using System.Text;

namespace Another6502
{
    interface IClock
    {
        void Reset();
        void Start();
        void Stop();
    }
}
