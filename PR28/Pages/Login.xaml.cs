using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PR28.Pages
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Admin(object sender, MouseButtonEventArgs e)
        {
            MainWindow.init.frame.Margin = new Thickness(0, 40, 0, 0);
            MainWindow.init.OpenPages(new Pages.Clubs.Main());
        }

        private void Guest(object sender, MouseButtonEventArgs e)
        {
            MainWindow.init.frame.Margin = new Thickness(0, 40, 0, 0);
            MainWindow.Role = true;
            MainWindow.init.OpenPages(new Pages.Clubs.Main()); 
        }
    }
}
