using System;
using System.Collections.Generic;
using System.Text;

namespace Another6502
{
    abstract class CPU : ICPU
    {
        private IBus _bus = new NullBus();

        public IBus Bus { get { return _bus; }  }


        public virtual void ConnectToBus(IBus bus)
        {
            if (_bus is NullBus)
            {
                _bus = bus;
                bus.ConnectDevice(this);
            }
        }

        public virtual Byte ReadFromBus(Int16 address)
        {
            return _bus.ReadFromAddress(address);
        }

        public virtual void WriteToBus(Int16 address, Byte data)
        {
            _bus.WriteToAddress(address, data);
        }
    }
}
