using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ArduinoCommunication
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int baudrate;
        private string port;
        private bool reading;
        private bool okSettings;
        private SerialPort serialPort;

        private object lockObject = new object();

        public MainWindow()
        {
            InitializeComponent();
            serialPort = new SerialPort();
        }

        private void RunButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Task readingTask = new Task(Read);

                if (serialPort == null)
                {
                    baudrate = int.Parse(baudBox.Text);
                    port = (portBox.Text.StartsWith("COM")) ? portBox.Text : "COM" + int.Parse(portBox.Text);

                    serialPort.PortName = port;
                    serialPort.BaudRate = baudrate;

                    serialPort.Open();

                    reading = true;
                    okSettings = true;

                    readingTask.Start();
                }
                else
                {
                    if (serialPort.IsOpen)
                        serialPort.Close();

                    baudrate = int.Parse(baudBox.Text);
                    port = (portBox.Text.StartsWith("COM")) ? portBox.Text : "COM" + int.Parse(portBox.Text);

                    serialPort.PortName = port;
                    serialPort.BaudRate = baudrate;

                    if (serialPort.IsOpen == false)
                        serialPort.Open();

                    readingTask.Start();
                }
            }
            catch (Exception ex)
            {
                okSettings = false;
                MessageBox.Show("Neplatné nastavení " + ex.Message);
            }
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            if (okSettings)
            {
                reading = false;

                lock (lockObject)
                {
                    try
                    {
                        var message = new Message(sendBox.Text);

                        serialPort.WriteLine(JsonConvert.SerializeObject( message ));
                        sendBox.Text = "";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    reading = true;
                }
            }
            else
            {
                MessageBox.Show("Neplatné nastavení");
            }
        }

        private void Read()
        {
            if (okSettings)
            {
                try
                {
                    string received = "";

                    lock (lockObject)
                    {
                        while (reading)
                        {
                            received = serialPort.ReadExisting();

                            if (received.Length > 0)
                            {
                                //Message message = JsonConvert.DeserializeObject<Message>(received.Trim());
                                Dispatcher.Invoke((Action)(() => recBlock.Text += received.Trim()));
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            else
            {
                MessageBox.Show("Neplatné nastavení");
            }

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if (serialPort?.IsOpen ?? false)
            {
                lock (lockObject)
                {
                    reading = false;
                    serialPort.Close();
                }
            }
        }
    }
}
