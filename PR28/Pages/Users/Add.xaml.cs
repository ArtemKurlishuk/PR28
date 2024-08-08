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

namespace PR28.Pages.Users
{
    /// <summary>
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Page
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

        public Add(Main Main, Models.Users User = null)
        {
            InitializeComponent();
            this.Main = Main;
            foreach (Models.Clubs Club in AllClubs.Clubs)
            {
                Clubs.Items.Add(Club.Name);
            }
            Clubs.Items.Add("Выберите...");
            // Если пользователь для изменения
            if (User != null)
            {
                this.User = User;
                this.FIO.Text = User.FIO;
                this.RentStart.Text = User.RentStart.ToString("yyyy-MM-dd");
                this.RentTime.Text = User.RentStart.ToString("HH:mm");
                this.Duration.Text = User.Duration.ToString();
                Clubs.SelectedItem = AllClubs.Clubs.Where(x => x.Id == User.IdClub).First().Name;
                BtnAdd.Content = "Изменить";
            }
        }

        private void AddUser(object sender, RoutedEventArgs e)
        {
            // Создаём дату аренды
            DateTime DTRentStart = new DateTime();
            DateTime.TryParse(this.RentStart.Text, out DTRentStart);
            DTRentStart = DTRentStart.Add(TimeSpan.Parse(this.RentTime.Text));
            // Если пользователь для добавления
            if (this.User == null)
            {
                User = new Models.Users();
                User.FIO = this.FIO.Text;
                User.RentStart = DTRentStart;
                User.Duration = Convert.ToInt32(this.Duration.Text);
                User.IdClub = AllClubs.Clubs.Where(x => x.Name == Clubs.SelectedItem).First().Id;
                // Добавляем пользователя в контекст
                this.Main.AllUser.Users.Add(this.User);
            }
            else
            {
                // Изменяем данные объекта
                User.FIO = this.FIO.Text;
                User.RentStart = DTRentStart;
                User.Duration = Convert.ToInt32(this.Duration.Text);
                User.IdClub = AllClubs.Clubs.Where(x => x.Name == Clubs.SelectedItem).First().Id;
            }
            // Сохраняем все изменения
            this.Main.AllUser.SaveChanges();
            MainWindow.init.OpenPages(new Pages.Users.Main());
        }
    }
}
