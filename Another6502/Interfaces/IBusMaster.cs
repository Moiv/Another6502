using System;

namespace Another6502
{
    interface IBusMaster : IBusDevice
    {
        Byte ReadFromBus(Int16 address);
        void WriteToBus(Int16 address, Byte data);

    }
}
