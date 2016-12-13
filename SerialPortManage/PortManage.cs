using System;
using System.IO.Ports;
using System.Threading;

namespace SerialPortManage
{
    public class PortManage
    {
        public delegate void ReceiveCompletedDelete(object sender,byte[] data );

        public event ReceiveCompletedDelete ReceiveCompleteEvent;

        private SerialPort _currentPort;
        public bool OpenPort(SerialPort port)
        {
            if (port == null)
            {
                return false;
            }
            ClosePort();
            _currentPort = port;
            if (!_currentPort.IsOpen)
            {
                _currentPort.ReadTimeout = 8000; //串口读超时8秒
                _currentPort.WriteTimeout = 8000; //串口写超时8秒，在1ms自动发送数据时拔掉串口，写超时5秒后，会自动停止发送，如果无超时设定，这时程序假死
                _currentPort.ReadBufferSize = 1024; //数据读缓存
                _currentPort.WriteBufferSize = 1024; //数据写缓存
                _currentPort.DataReceived += Received;
                _currentPort.Open();
                return true;
            }
            return true;
        }

        private byte[] _receivedDataPacket;
        private void Received(object sender, SerialDataReceivedEventArgs e)
        {
            if (e.EventType == SerialData.Eof)
            {
                return;
            }   
            Thread.Sleep(100);
            _receivedDataPacket = new byte[_currentPort.BytesToRead];
            _currentPort.Read(_receivedDataPacket, 0, _receivedDataPacket.Length);
            ReceiveCompleteEvent?.Invoke(sender,_receivedDataPacket);
        }

        public bool SendDataPacket(byte[] dataPackeg)
        {
            _currentPort.Write(dataPackeg, 0, dataPackeg.Length);
            return true;
        }
        public void ClosePort()
        {
            if (_currentPort == null)
            {
                return;
            }
            if (_currentPort.IsOpen)
            {
                _currentPort.DiscardOutBuffer();//清发送缓存
                _currentPort.DiscardInBuffer();//清接收缓存
                _currentPort.Close();
            }
        }
    }
}
