using System;
using System.Collections.Generic;
using System.Text;

namespace Another6502
{
    interface IBusSlave : IBusDevice
    {
        
        Byte ReadFromAddress(Int16 address);
        void WriteToAddress(Int16 address, Byte data);
    }
}
