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
        public string? _colorProperty;

        [ObservableProperty]
        public string? _statusConditionerButton = "ON";

        [ObservableProperty]
        public double _opacityButton = 0.4;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(SwitchingSoundCommand))]
        [NotifyCanExecuteChangedFor(nameof(SwitchingModesCommand))]
        [NotifyCanExecuteChangedFor(nameof(UpTemperatureCommand))]
        [NotifyCanExecuteChangedFor(nameof(DownTemperatureCommand))]
        [NotifyCanExecuteChangedFor(nameof(SwitchingFanSpeedCommand))]
        [NotifyCanExecuteChangedFor(nameof(TimerOnCommand))]
        [NotifyCanExecuteChangedFor(nameof(TimerOffCommand))]
        [NotifyCanExecuteChangedFor(nameof(ClockSettingCommand))]
        [NotifyCanExecuteChangedFor(nameof(HealthyButtonCommand))]
        [NotifyCanExecuteChangedFor(nameof(FollowMeButtonCommand))]
        [NotifyCanExecuteChangedFor(nameof(OkButtonCommand))]
        [NotifyCanExecuteChangedFor(nameof(SwitchingAirDirectionCommand))]
        [NotifyCanExecuteChangedFor(nameof(SwitchingSwingVerticalCommand))]
        [NotifyCanExecuteChangedFor(nameof(SwitchingSwingHorizontalCommand))]
        public bool _statusConditioner = false;

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

                    ChangePropertiesWhenConnecting(false, "Disconnect");
                    OutputInfo = $"{SelectedPort} is connected";
                }
                catch (Exception ex)
                {
                    ColorProperty = "Error";
                    OutputInfo = ex.Message;
                }
            }
            else if (ConnectButtonName == "Disconnect")
            {
                SelectedSerialPort.Close();

                ChangePropertiesWhenConnecting(true, "Connect");
                OutputInfo = $"{SelectedPort} is disconnect";
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

        [RelayCommand]
        private void TurnOnConditioner()
        {
            if (StatusConditioner == false)
            {
                StatusConditioner = true;
                StatusConditionerButton = "OFF";
                OpacityButton = 1;
            }
            else
            {
                StatusConditioner = false;
                StatusConditionerButton = "ON";
                OpacityButton = 0.4;
            }
        }

        [RelayCommand(CanExecute = nameof(StatusConditioner))]
        private void UpTemperature()
        {

        }

        [RelayCommand(CanExecute = nameof(StatusConditioner))]
        private void DownTemperature()
        {

        }

        [RelayCommand(CanExecute = nameof(StatusConditioner))]
        private void SwitchingSound()
        {

        }

        [RelayCommand(CanExecute = nameof(StatusConditioner))]
        private void SwitchingModes()
        {

        }

        [RelayCommand(CanExecute = nameof(StatusConditioner))]
        private void SwitchingFanSpeed()
        {

        }

        [RelayCommand(CanExecute = nameof(StatusConditioner))]
        private void TimerOn()
        {

        }

        [RelayCommand(CanExecute = nameof(StatusConditioner))]
        private void TimerOff()
        {

        }

        [RelayCommand(CanExecute = nameof(StatusConditioner))]
        private void ClockSetting()
        {

        }

        [RelayCommand(CanExecute = nameof(StatusConditioner))]
        private void HealthyButton()
        {

        }

        [RelayCommand(CanExecute = nameof(StatusConditioner))]
        private void FollowMeButton()
        {

        }

        [RelayCommand(CanExecute = nameof(StatusConditioner))]
        private void OkButton()
        {

        }

        [RelayCommand(CanExecute = nameof(StatusConditioner))]
        private void SwitchingAirDirection()
        {

        }

        [RelayCommand(CanExecute = nameof(StatusConditioner))]
        private void SwitchingSwingVertical()
        {

        }

        [RelayCommand(CanExecute = nameof(StatusConditioner))]
        private void SwitchingSwingHorizontal()
        {

        }

        private void ChangePropertiesWhenConnecting(bool status, string statusConnecting)
        {
            PortIsEnabled = status;
            UpdateButtonIsEnabled = status;
            ConnectButtonName = statusConnecting;
            ColorProperty = statusConnecting;
        }


    }
}
