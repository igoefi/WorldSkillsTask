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
using WorldSkills.Classes;
using WorldSkills.Classes.Interfaces;
using WorldSkills.HelperClasses;
using WorldSkills.Models;
using WorldSkills.Pages.DevicePages;

namespace WorldSkills.Pages.MainPages
{
    /// <summary>
    /// Логика взаимодействия для PageMainUser.xaml
    /// </summary>
    public partial class PageMainUser : Page, ISetUser
    {
        private Users _user;
        public PageMainUser()
        {
            InitializeComponent();
        }
        public void SetUser(Users user)
        {
            _user = user;
            RnUserName.Text = _user.FirstName;
        }

        private void BtnClickCreateDevice(object sender, RoutedEventArgs e) =>
            FrameNavigation.Frame.Navigate(new PageCreateRefreshDevice());


        private void BtnClickRefreshDeviceInfo(object sender, RoutedEventArgs e) =>
            FrameNavigation.Frame.Navigate(new PageFindDevice(new PageCreateRefreshDevice()));

        private void BtnClickSetPortsDevice(object sender, RoutedEventArgs e) =>
            FrameNavigation.Frame.Navigate(new PageFindDevice(new PageSetDevicePort()));

        private void BtnClickViewDeviceInfo(object sender, RoutedEventArgs e) =>
            FrameNavigation.Frame.Navigate(new PageFindDevice(new PageDeviceInfo()));
    }
}
