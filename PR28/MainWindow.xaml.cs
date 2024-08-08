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

namespace PR28
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow init;
        public static bool Role = false;
        public MainWindow()
        {
            InitializeComponent();
            init = this;
            frame.Margin = new Thickness(0, 0, 0, 0);
            OpenPages(new Pages.Login());
        }
        /// <summary>
        /// Метод открытия страниц
        /// </summary>
        /// <param name="Page"></param>
        public void OpenPages(Page Page) =>
            frame.Navigate(Page);

        private void Clubs(object sender, RoutedEventArgs e) =>
            OpenPages(new Pages.Clubs.Main());


        private void Users(object sender, RoutedEventArgs e) =>
            OpenPages(new Pages.Users.Main());
    }
}
