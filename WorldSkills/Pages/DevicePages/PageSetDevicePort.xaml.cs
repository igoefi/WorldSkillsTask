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
    /// Логика взаимодействия для PageSetDevicePort.xaml
    /// </summary>
    public partial class PageSetDevicePort : Page, ISetDevice
    {
        private Devices _device;
        private Dictionary<int, string> _ports;

        private int _lastIndexPort = -1;
        public PageSetDevicePort() =>
            InitializeComponent();


        public void SetDevice(Devices device)
        {
            _device = device;
            var portsJson = JsonConvert.DeserializeObject<PortsJson>(device.PortsJson);

            _ports = new Dictionary<int, string>();
            foreach (var port in portsJson.Ports)
                _ports.Add(port.Num, port.Decription);

            CmbBoxPorts.ItemsSource = _ports.Keys;
            CmbBoxPorts.SelectedIndex = 0;
        }

        private void BtnSaveClick(object sender, RoutedEventArgs e)
        {
            _ports[_lastIndexPort + 1] = TxbDescription.Text;

            var portsFile = new PortsJson(_ports.Count);
            foreach (var port in portsFile.Ports) 
                port.Decription = _ports[port.Num];

            var portsJson = SerializationController.SerializeFile(portsFile);
            _device.PortsJson = portsJson;
            DeviceDBController.SaveRefreshDevice(_device);
        }

        private void BtnToMainMenu(object sender, RoutedEventArgs e)
        {
            FrameNavigation.Frame.GoBack(); 
            FrameNavigation.Frame.GoBack(); 
        }

        private void CmbBoxSelectedPorts(object sender, RoutedEventArgs e)
        {
            if(_lastIndexPort > -1)
                _ports[_lastIndexPort+1] = TxbDescription.Text;

            _lastIndexPort = CmbBoxPorts.SelectedIndex;
            TxbDescription.Text = _ports[_lastIndexPort + 1];
        }
    }
}
