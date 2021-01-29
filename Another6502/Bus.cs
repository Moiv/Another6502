using System;
using System.Collections.Generic;
using System.Text;

namespace Another6502
{
    class Bus : IBus
    {
        private static int DefaultDeviceCapacity = 20;

        private List<IBusDevice> _connectedDevices = new List<IBusDevice>(DefaultDeviceCapacity);


        public void ConnectDevice(IBusDevice device)
        {
            if (!_connectedDevices.Contains(device))
                _connectedDevices.Add(device);

            device.ConnectToBus(this);
        }

        public byte ReadFromAddress(short address)
        {
            throw new NotImplementedException();
        }

        public void WriteToAddress(short address, byte data)
        {
            throw new NotImplementedException();
        }
    }
}
