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

namespace PR28.Pages.Clubs
{
    /// <summary>
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Page
    {
        /// <summary>
        /// Главная страница клубов
        /// </summary>
        Main Main;
        /// <summary>
        /// Данные клубов
        /// </summary>
        Models.Clubs Club;

        public Add(Main Main, Models.Clubs Club = null)
        {
            InitializeComponent();
            this.Main = Main;
            // Если пришёл клуб, отображаем
            if (Club != null)
            {
                this.Club = Club;
                this.Name.Text = Club.Name;
                this.Address.Text = Club.Address;
                this.WorkTime.Text = Club.WorkTime;
                BtnAdd.Content = "Изменить";
            }
        }

        /// <summary>
        /// Метод добавления или изменения
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddClub(object sender, RoutedEventArgs e)
        {
            // Если клуб пустой
            if (Club == null)
            {
                Club = new Models.Clubs();
                Club.Name = this.Name.Text;
                Club.Address = this.Address.Text;
                Club.WorkTime = this.WorkTime.Text;
                this.Main.AllClub.Clubs.Add(this.Club);
            }
            else
            {
                Club.Name = this.Name.Text;
                Club.Address = this.Address.Text;
                Club.WorkTime = this.WorkTime.Text;
            }
            this.Main.AllClub.SaveChanges();
            // Открываем страницу клубов
            MainWindow.init.OpenPages(new Pages.Clubs.Main());
        }
    }
}
