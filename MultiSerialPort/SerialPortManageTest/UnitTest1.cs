using System;
using System.IO.Ports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SerialPortManage;

namespace SerialPortManageTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            SerialPort port = new SerialPort()
            {
                PortName = "COM1",
                BaudRate = 115200,
                Parity = Parity.None,
                DataBits = 8,
                StopBits = StopBits.One,
            };
            PortManage portManage = new PortManage();
            if (portManage.OpenPort(port))
            {
                portManage.SendDataPacket(new byte[] {0x01, 0x02, 0x03, 0x04, 0x05});
            }

        }
    }
}
