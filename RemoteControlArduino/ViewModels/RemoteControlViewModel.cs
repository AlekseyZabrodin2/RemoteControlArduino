using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.IO.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RemoteControlArduino.ViewModels
{
    public partial class RemoteControlViewModel : ObservableObject
    {
        [ObservableProperty]
        public string[]? _portNamesList;

        [ObservableProperty]
        public string? _selectedPort;

        [ObservableProperty]
        public string? _connectButtonName = "Connect";








        [RelayCommand]
        private void ConnectPort()
        {
            var serialPort = new SerialPort();

            try
            {
                serialPort.PortName = SelectedPort;
                serialPort.Open();
            }
            catch (Exception)
            {
                MessageBox.Show("Порт занят");
            }
        }

        [RelayCommand]
        private void UpdatePorts()
        {
            PortNamesList = SerialPort.GetPortNames();

            if (PortNamesList.Length != 0)
            {
                SelectedPort = PortNamesList[0];
            }
        }

    }
}
