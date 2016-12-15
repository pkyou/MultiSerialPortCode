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
                StopBits = StopBits.One
            };
            PortManage portManage = new PortManage();
            portManage.ReceiveCompleteEvent += Received;
            if (portManage.OpenPort(port))
            {
                portManage.SendDataPacket(new byte[] {0x01, 0x02, 0x03, 0x04, 0x05});
            }
            while (true)
            {
                ;
            }
        }

        private void Received(object sender, byte[] data)
        {
            foreach (byte b in data)
            {
                Console.WriteLine(b);
            }
        }
    }
}
