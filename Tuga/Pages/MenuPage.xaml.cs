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
using Tuga.ClassHelper;

namespace Tuga.Pages
{
    /// <summary>
    /// Логика взаимодействия для MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        int idCat;
        public MenuPage()
        {
            InitializeComponent();         
        }

        private void btnBar_Click(object sender, RoutedEventArgs e)
        {
            tbBar.TextDecorations = TextDecorations.Underline;
            tbHotDishes.TextDecorations = null;
            tbDesserts.TextDecorations = null;
            tbSalads.TextDecorations = null;
            tbSnacks.TextDecorations = null;
            idCat = 1;
            lvMenu.ItemsSource = ClassHelper.AppData.Context.Dish.Where(i => i.IDCategory == idCat).ToList();
        }

        private void btnHotDishes_Click(object sender, RoutedEventArgs e)
        {
            tbBar.TextDecorations = null;
            tbHotDishes.TextDecorations = TextDecorations.Underline;
            tbDesserts.TextDecorations = null;
            tbSalads.TextDecorations = null;
            tbSnacks.TextDecorations = null;
            idCat = 3;
            lvMenu.ItemsSource = ClassHelper.AppData.Context.Dish.Where(i => i.IDCategory == idCat).ToList();
        }

        private void btnDesserts_Click(object sender, RoutedEventArgs e)
        {
            tbBar.TextDecorations = null;
            tbHotDishes.TextDecorations = null;
            tbDesserts.TextDecorations = TextDecorations.Underline;
            tbSalads.TextDecorations = null;
            tbSnacks.TextDecorations = null;
            idCat = 2;
            lvMenu.ItemsSource = ClassHelper.AppData.Context.Dish.Where(i => i.IDCategory == idCat).ToList();
        }

        private void btnSalads_Click(object sender, RoutedEventArgs e)
        {
            tbBar.TextDecorations = null;
            tbHotDishes.TextDecorations = null;
            tbDesserts.TextDecorations = null;
            tbSalads.TextDecorations = TextDecorations.Underline;
            tbSnacks.TextDecorations = null;
            idCat = 4;
            lvMenu.ItemsSource = ClassHelper.AppData.Context.Dish.Where(i => i.IDCategory == idCat).ToList();
        }

        private void btnSnacks_Click(object sender, RoutedEventArgs e)
        {
            tbBar.TextDecorations = null;
            tbHotDishes.TextDecorations = null;
            tbDesserts.TextDecorations = null;
            tbSalads.TextDecorations = null;
            tbSnacks.TextDecorations = TextDecorations.Underline;
            idCat = 5;
            lvMenu.ItemsSource = ClassHelper.AppData.Context.Dish.Where(i => i.IDCategory == idCat).ToList();
        }

        private void lvMenu_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(lvMenu.SelectedItem is EF.Dish)
            {
                var position = lvMenu.SelectedItem as EF.Dish;
                DishPage dishPage = new DishPage(position);
                NavigationService.Navigate(dishPage);
            }
            
        }
    }
}
