using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.IO.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;

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

        [ObservableProperty]
        public bool? _portIsEnabled = true;

        [ObservableProperty]
        public bool _checkBoxDiod;

        [ObservableProperty]
        public SerialPort _selectedSerialPort = new SerialPort();

        [ObservableProperty]
        public string? _outputInfo;

        [ObservableProperty]
        public string? _arduinoInfo = "Привет";

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(ConnectPortCommand))]
        public bool _conectionButtonIsEnabled;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(UpdatePortsCommand))]
        public bool _updateButtonIsEnabled = true;

        [ObservableProperty]
        public Brush _comboBoxColor = Brushes.Black;

        [ObservableProperty]
        public Brush _outputInfoColor = Brushes.Black;

        [ObservableProperty]
        public Brush _connectButtonColor = Brushes.YellowGreen;

        

        [RelayCommand(CanExecute = nameof(ConectionButtonIsEnabled))]
        private void ConnectPort()
        {
            if (ConnectButtonName == "Connect")
            {
                try
                {
                    SelectedSerialPort.PortName = SelectedPort;
                    SelectedSerialPort.BaudRate = 250000;
                    SelectedSerialPort.Open();
                    PortIsEnabled = false;

                    ComboBoxColor = Brushes.Gray;
                    OutputInfo = $"{SelectedPort} is connected";
                    OutputInfoColor = Brushes.Black;
                    ConnectButtonName = "Disconnect";
                    OutputInfoColor = Brushes.Green;
                    ConnectButtonColor = Brushes.Orange;
                                        
                    UpdateButtonIsEnabled = false;
                }
                catch (Exception ex)
                {
                    OutputInfo = ex.Message;
                    OutputInfoColor = Brushes.Red;
                }
            }
            else if (ConnectButtonName == "Disconnect")
            {
                SelectedSerialPort.Close();
                ConnectButtonName = "Connect";
                ConnectButtonColor = Brushes.YellowGreen;

                ComboBoxColor = Brushes.Black;
                PortIsEnabled = true;
                OutputInfoColor = Brushes.Black;
                OutputInfo = $"{SelectedPort} is disconnect";

                UpdateButtonIsEnabled = true;
            }
        }

        [RelayCommand(CanExecute = nameof(UpdateButtonIsEnabled))]
        private void UpdatePorts()
        {
            PortNamesList = SerialPort.GetPortNames();

            if (PortNamesList.Length != 0)
            {
                SelectedPort = PortNamesList[0];
                ConectionButtonIsEnabled = true;
            }
        }

        [RelayCommand]
        private void UpdateArduino()
        {
            //ArduinoInfo = SerialPorts.ReadLine();
            if (!SelectedSerialPort.IsOpen)
            {
                return;
            }
            if (CheckBoxDiod == true)
            {
                SelectedSerialPort.Write("0");
            }
            else
            {
                SelectedSerialPort.Write("1");
            }
        }


    }
}
