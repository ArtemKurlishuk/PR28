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

namespace PR28.Pages.Clubs.Elements
{
    /// <summary>
    /// Логика взаимодействия для Item.xaml
    /// </summary>
    public partial class Item : UserControl
    {
        /// <summary>
        /// Главная страница клубов
        /// </summary>
        Main Main;
        /// <summary>
        /// Данные клубов
        /// </summary>
        Models.Clubs Club;

        public Item(Models.Clubs Club, Main Main)
        {
            InitializeComponent();
            if (MainWindow.Role)
            {
                BtnEdit.Visibility = Visibility.Hidden;
                BtnDel.Visibility = Visibility.Hidden;
            }
            this.Name.Text = Club.Name;
            this.Address.Text = Club.Address;
            this.WorkTime.Text = Club.WorkTime;
            this.Club = Club;
            this.Main = Main;
        }

        /// <summary>
        /// Метод изменения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditClub(object sender, RoutedEventArgs e) =>
            // Открываем страницу добавления, пересылаем данные
            MainWindow.init.OpenPages(new Pages.Clubs.Add(this.Main, this.Club));

        /// <summary>
        /// Метод удаления
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteClub(object sender, RoutedEventArgs e)
        {
            // Удаляем клуб из контекста
            Main.AllClub.Clubs.Remove(Club);
            // Сохраняем изменения
            Main.AllClub.SaveChanges();
            // Удаляем элемент со страницы Main
            Main.Parent.Children.Remove(this);
        }
    }
}
