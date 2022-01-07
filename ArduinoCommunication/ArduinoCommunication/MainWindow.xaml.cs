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
                port = portBox.Text;

                serialPort = new SerialPort(port, baudrate);
                serialPort.Open();

                reading = true;

                Task readingTask = new Task(Read);
                readingTask.Start();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            reading = false;

            lock (lockObject) 
            {
                try
                {
                    serialPort.WriteLine(sendBox.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                reading = true;
            }  
        }

        private void Read()
        {
            string text = "";

            lock (lockObject)
            {
                while (reading)
                {
                    text = serialPort.ReadExisting();

                    if (text.Length > 0)
                        Dispatcher.Invoke((Action)(() => recBlock.Text += text.Trim()));
                }
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
