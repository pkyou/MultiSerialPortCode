using System;
using System.IO.Ports;
using System.Threading;
using System.Windows;
using SerialPortManage;

namespace MultiSerialPort
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartClicked(object sender, RoutedEventArgs args)
        {
            try
            {
                SerialPort port1 = new SerialPort()
                {
                    PortName = "COM1",
                    BaudRate = 115200,
                    Parity = Parity.None,
                    DataBits = 8,
                    StopBits = StopBits.One
                };
                PortManage manage = new PortManage();
                if (manage.OpenPort(port1))
                {
                    manage.SendDataPacket(new byte[] { 0x01 });
                    manage.ReceiveCompleteEvent += Com1;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        private void Com1(object sender, byte[] data)
        {
            Dispatcher.Invoke(() =>
            {
                Port1DataLabel.Content = data[0];
            });
        }

        private void StartThreadToSendData(byte[] data, byte number)
        {
            Thread thread = new Thread(() =>
            {
                SendData(data,number);
            });
            thread.Start();
        }

        private void SendData(byte[] data, byte number)
        {
            SerialPort port1 = new SerialPort()
            {
                PortName = "COM"+number,
                BaudRate = 115200,
                Parity = Parity.None,
                DataBits = 8,
                StopBits = StopBits.One
            };
            PortManage manage = new PortManage();
            if (manage.OpenPort(port1))
            {
                manage.SendDataPacket(data);
                manage.ReceiveCompleteEvent += Com1;
            }
        }
    }
}
