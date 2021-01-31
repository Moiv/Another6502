using System;

namespace Another6502
{
    interface IBusDevice
    {
        void ConnectToBus(IBus bus);
    }
}