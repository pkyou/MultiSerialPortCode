using System;
using System.IO.Ports;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
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
                StartThreadToSendData(new byte[]{0x01,0x02},1);
                StartThreadToSendData(new byte[]{0x03,0x02},3);
                StartThreadToSendData(new byte[]{0x05,0x02},5);
                StartThreadToSendData(new byte[]{0x07,0x02},7);
                StartThreadToSendData(new byte[]{0x09,0x02},9);
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
                PortLabel1.Content = data[0];
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
                do
                {
                } while (!manage.ReceiveCompleted);
                Dispatcher.Invoke(() =>
                {
                    string receivedString = GetString(manage.ReceivedDataPacket);
                    FindDataLabel(number).Content = receivedString;
                });
            }
        }

        private Label FindDataLabel(byte number)
        {
            Label label = this.FindName("PortLabel" + number) as Label;
            return label;
        }

        private string GetString(byte[] bytes)
        {
            string result="";
            foreach (byte b in bytes)
            {
                result += b;
            }
            return result;
        }
    }
}
