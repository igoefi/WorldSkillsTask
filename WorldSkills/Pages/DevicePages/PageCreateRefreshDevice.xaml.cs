using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using WorldSkills.Classes.Helpers;
using WorldSkills.Classes.Interfaces;
using WorldSkills.Classes.Jsons;
using WorldSkills.HelperClasses;
using WorldSkills.Models;

namespace WorldSkills.Pages.DevicePages
{
    /// <summary>
    /// Логика взаимодействия для PageCreateRefreshDevice.xaml
    /// </summary>
    public partial class PageCreateRefreshDevice : Page, ISetDevice
    {
        private const string _taskSave = "Добавление устройства";
        private const string _taskUpdate = "Обновление информации";

        private Devices _oldDevice;

        public void SetDevice(Devices device)
        {
            _oldDevice = device;
            RnTaskName.Text = _taskUpdate;

            TxbDeviceName.Text = device.Name;
            TxbIP.Text = device.IP;
            TxbMAC.Text = device.MAC;
            TxbNumPortsDevice.Text = "Не изменяется";
        }

        public PageCreateRefreshDevice()
        {
            InitializeComponent();
            RnTaskName.Text = _taskSave;
        }

        private void ClickSaveUpdateDevice(object sender, RoutedEventArgs e)
        {
            if (_oldDevice != null)
            {
                if(_oldDevice.Name.ToLower() != TxbDeviceName.Text.ToLower())
                    if (IsDeviceNameEngaged(TxbDeviceName.Text)) return;

                _oldDevice.Name = TxbDeviceName.Text;
                _oldDevice.IP = TxbIP.Text;
                _oldDevice.MAC= TxbMAC.Text;

                DeviceDBController.SaveRefreshDevice(_oldDevice);
            }
            else
            {
                if (IsDeviceNameEngaged(TxbDeviceName.Text)) return;

                if (int.TryParse(TxbNumPortsDevice.Text, out int numPorts))
                    if (numPorts <= 0)
                    {
                        MessageBox.Show("Uncorrect num ports");
                        return;
                    }

                var device = new Devices
                {
                    Name = TxbDeviceName.Text,
                    IP = TxbIP.Text,
                    MAC = TxbMAC.Text,
                    PortsJson = SerializationController.SerializeFile(new PortsJson(numPorts))
                };
                DeviceDBController.SaveNewDevice(device);
            }
            FrameNavigation.Frame.GoBack();
            FrameNavigation.Frame.GoBack();
            if(!FrameNavigation.Frame.CanGoBack)
                FrameNavigation.Frame.GoForward();
        }

        private bool IsDeviceNameEngaged(string name)
        {
            if (DeviceDBController.FindDevice(name) == null) 
                return false;

            MessageBox.Show("Name is engaged");
            return true;
        }
    }
}
