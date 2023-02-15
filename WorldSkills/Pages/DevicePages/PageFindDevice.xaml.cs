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
using WorldSkills.HelperClasses;

namespace WorldSkills.Pages.DevicePages
{
    /// <summary>
    /// Логика взаимодействия для PageFindDevice.xaml
    /// </summary>
    public partial class PageFindDevice : Page
    {
        ISetDevice _nextPage;
        public PageFindDevice(ISetDevice nextPage)
        {
            InitializeComponent();
            _nextPage = nextPage;
        }

        private void ClickFindDevice(object sender, RoutedEventArgs e)
        {
            var device = DeviceDBController.FindDevice(TxbDeviceName.Text);
            if(device == null)
            {
                MessageBox.Show("Device not found");
                return;
            }

            _nextPage.SetDevice(device);
            FrameNavigation.Frame.Navigate((Page)_nextPage);
        }
    }
}
