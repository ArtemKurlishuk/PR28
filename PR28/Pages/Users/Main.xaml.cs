using PR28.Classes;
using PR28.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Xml.Linq;

namespace PR28.Pages.Users
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        /// <summary>
        /// Контекст пользователей
        /// </summary>
        public UserContext AllUser = new UserContext();
        bool flagFiltr = false;


        public Main()
        {
            InitializeComponent();
            if (MainWindow.Role) BtnAdd.Visibility = Visibility.Hidden;
            //Перебираем пользователей
            foreach (Models.Users User in AllUser.Users)
                //Выводим на экран через пользовательский элемент
                Parent.Children.Add(new Elements.Item(User, this));
        }

        private void AddUser(object sender, RoutedEventArgs e) =>
            //Открываем страницу добавления пользователей  
            MainWindow.init.OpenPages(new Pages.Users.Add(this));

        private void Filtr(object sender, RoutedEventArgs e)
        {
            Parent.Children.Clear();
            if (flagFiltr)
            {
                foreach (Models.Users User in AllUser.Users.OrderBy(x => x.RentStart))
                    //Выводим на экран через пользовательский элемент
                    Parent.Children.Add(new Elements.Item(User, this));
                flagFiltr = !flagFiltr;
            }
            else
            {
                foreach (Models.Users User in AllUser.Users.OrderByDescending(x => x.RentStart))
                    //Выводим на экран через пользовательский элемент
                    Parent.Children.Add(new Elements.Item(User, this));
                flagFiltr = !flagFiltr;
            }
        }
    }
}
