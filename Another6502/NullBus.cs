using System;
using System.Collections.Generic;
using System.Text;

namespace Another6502
{
    class NullBus : IBus
    {

        public void ConnectDevice(IBusDevice device)
        {
            
        }

        public Byte ReadFromAddress(short address)
        {
            return new Byte();
        }

        public void WriteToAddress(short address, Byte data)
        {
            
        }
    }
}
