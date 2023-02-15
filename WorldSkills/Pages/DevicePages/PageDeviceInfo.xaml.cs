using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для PageDeviceInfo.xaml
    /// </summary>
    public partial class PageDeviceInfo : Page, ISetDevice
    {
        private Dictionary<int, string> _ports;
        public PageDeviceInfo()
        {
            InitializeComponent();
        }

        public void SetDevice(Devices device)
        {
            RnDeviceIP.Text = device.IP != null ? device.IP : "Не задан";
            RnDeviceMAC.Text = device.MAC != null ? device.MAC : "Не задан";
            RnDeviceName.Text = device.Name;

            var portsJson = JsonConvert.DeserializeObject<PortsJson>(device.PortsJson);

            _ports = new Dictionary<int, string>();
            foreach (var port in portsJson.Ports)
                _ports.Add(port.Num, port.Decription);

            CmbBoxPorts.ItemsSource = _ports.Keys;
            CmbBoxPorts.SelectedIndex = 0;
        }

        private void BtnClickGoToMain(object sender, RoutedEventArgs e)
        {
            FrameNavigation.Frame.GoBack();
            FrameNavigation.Frame.GoBack();
        }

        private void CmbBoxSelectedPorts(object sender, SelectionChangedEventArgs e)
        {
            RnPortNum.Text = CmbBoxPorts.SelectedIndex+1 + "\n"; 
            RnPortDescription.Text = "\n" + _ports[CmbBoxPorts.SelectedIndex + 1] ; 
        }
    }
}
