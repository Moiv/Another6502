using System;
using System.Collections.Generic;
using System.Text;

namespace Another6502
{
    interface ISystem
    {
        void Reset();
        void Start();
        void Stop();
    }
}
