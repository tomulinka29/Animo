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
        }

        private void RunButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                baudrate = int.Parse(baudBox.Text);
                port = (portBox.Text.StartsWith("COM")) ? portBox.Text : "COM" + int.Parse(portBox.Text);

                serialPort = new SerialPort(port, baudrate);
                serialPort.Open();

                reading = true;
                okSettings = true;

                Task readingTask = new Task(Read);
                readingTask.Start();
            }
            catch (Exception)
            {
                okSettings = false;
                MessageBox.Show("Neplatné nastavení");
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
                string received = "";

                lock (lockObject)
                {
                    while (reading)
                    {
                        received = serialPort.ReadExisting();

                        if (received.Length > 0)
                        {
                            Message message = JsonConvert.DeserializeObject<Message>(received);
                            Dispatcher.Invoke((Action)(() => recBlock.Text += message.text.Trim()));
                        }
                    }
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
