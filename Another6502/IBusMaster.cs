using System;
using System.Collections.Generic;
using System.Text;

namespace Another6502
{
    interface IBusMaster : IBusDevice
    {
        Byte ReadFromBus(Int16 address);
        void WriteToBus(Int16 address, Byte data);

    }
}
