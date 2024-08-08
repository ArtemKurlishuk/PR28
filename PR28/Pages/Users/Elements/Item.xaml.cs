using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using PR28.Classes;

namespace PR28.Pages.Users.Elements
{
    /// <summary>
    /// Логика взаимодействия для Item.xaml
    /// </summary>
    public partial class Item : UserControl
    {
        /// <summary>
        /// Контекст клубов
        /// </summary>
        public ClubsContext AllClubs = new ClubsContext();
        /// <summary>
        /// Главная страница пользователей
        /// </summary>
        Main Main;
        /// <summary>
        /// Данные пользователей
        /// </summary>
        Models.Users User;

        public Item(Models.Users User, Main Main)
        {
            InitializeComponent();
            if (MainWindow.Role)
            {
                BtnEdit.Visibility = Visibility.Hidden;
                BtnDel.Visibility = Visibility.Hidden;
            }

            this.FIO.Text = User.FIO;
            this.RentStart.Text = User.RentStart.ToString("yyyy-MM-dd");
            this.RentTime.Text = User.RentStart.ToString("HH:mm");
            this.Duration.Text = User.Duration.ToString();
            this.Club.Text = AllClubs.Clubs.Where(x => x.Id == User.IdClub).First().Name;
            this.Main = Main;
            this.User = User;
        }

        /// <summary>
        /// Метод изменения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditUser(object sender, RoutedEventArgs e) =>
            // Открываем страницу добавления, пересылаем данные
            MainWindow.init.OpenPages(new Pages.Users.Add(this.Main, this.User));

        /// <summary>
        /// Метод удаления
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteUser(object sender, RoutedEventArgs e)
        {
            // Удаляем пользователя из контекста
            Main.AllUser.Users.Remove(User);
            // Сохраняем изменения
            Main.AllUser.SaveChanges();
            // Удаляем элемент со страницы Main
            Main.Parent.Children.Remove(this);
        }
    }
}
