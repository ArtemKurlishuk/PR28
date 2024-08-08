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
using PR28.Classes;

namespace PR28.Pages.Clubs
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        /// <summary>
        /// Получаем контекст данных для клубов
        /// </summary>
        public ClubsContext AllClub = new ClubsContext();

        bool flagFiltr = false;

        public Main()
        {
            InitializeComponent();
            if (MainWindow.Role) BtnAdd.Visibility = Visibility.Hidden;
            //Перебираем клубы
            foreach (Models.Clubs Club in AllClub.Clubs)
                //Выводим на экран через пользовательский элемент
                Parent.Children.Add(new Elements.Item(Club, this));
        }
        //Меод добавления клубов
        private void AddClub(object sender, RoutedEventArgs e) =>
            //Открываем страницу добавления клубов  
            MainWindow.init.OpenPages(new Pages.Clubs.Add(this));

        private void Filtr(object sender, RoutedEventArgs e)
        {
            Parent.Children.Clear();
            if (flagFiltr)
            {
                foreach (Models.Clubs Club in AllClub.Clubs.OrderBy(x => x.Name))
                    //Выводим на экран через пользовательский элемент
                    Parent.Children.Add(new Elements.Item(Club, this));
                flagFiltr = !flagFiltr;
            }
            else
            {
                foreach (Models.Clubs Club in AllClub.Clubs.OrderByDescending(x => x.Name))
                    //Выводим на экран через пользовательский элемент
                    Parent.Children.Add(new Elements.Item(Club, this));
                flagFiltr = !flagFiltr;
            }
            
        }
    }
}
