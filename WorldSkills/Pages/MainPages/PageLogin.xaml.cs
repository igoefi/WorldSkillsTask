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
using WorldSkills.HelperClasses;
using WorldSkills.Pages.MainPages;

namespace WorldSkills.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageLogin.xaml
    /// </summary>
    public partial class PageLogin : Page
    {
        private int _code;
        private Random _rand = new Random();

        private DateTime _timeLastUpdatedCode;
        public PageLogin()
        {
            InitializeComponent();
            SetCodeRandom();
            _timeLastUpdatedCode = DateTime.Now;
        }

        private void BtnRefreshCode(object sender, RoutedEventArgs e)
        {
            if (DateTime.Now.Subtract(_timeLastUpdatedCode).Minutes < 1) return;
            
            SetCodeRandom();
            _timeLastUpdatedCode = DateTime.Now;
        }

        private void SetCodeRandom()
        {
            _code = _rand.Next(999999);
            MessageBox.Show($"Code {_code}");
        }

        private void BtnClickExit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnClickEnter(object sender, RoutedEventArgs e)
        {
            if(TxbCode.Text != _code.ToString())
            {
                MessageBox.Show("Code is wrong!");
                return;
            }    
            var user = UserFind.FindUser(TxbNumber.Text, TxbPassword.Password);

            if(user == null)
            {
                MessageBox.Show("Number or password uncorrect");
                return;
            }
            var userPage = new PageMainUser();
            userPage.SetUser(user);
            FrameNavigation.Frame.Navigate(userPage);
        }
    }
}
