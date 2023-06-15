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
    /// Логика взаимодействия для DishPage.xaml
    /// </summary>
    public partial class DishPage : Page
    {
        EF.Dish position;
        public DishPage(EF.Dish dish)
        {
            InitializeComponent();
            position = dish;
            tbTitle.Text = dish.Title;
            checkSale();
            tbDescription.Text = dish.Description;
            imgDish.Source = new BitmapImage(new Uri(dish.PhotoPath, UriKind.Relative)); 
            
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MenuPage());
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {           
            GlobaVariables.preOrder preorder = new GlobaVariables.preOrder(){
                title=position.Title,
                id = position.ID,
                price = position.Cost,
                qty = 1
            };
            var orderExists = GlobaVariables.ContainerOrder.preOrderList.Where(i => i.id == preorder.id).FirstOrDefault();
            if(orderExists != null)
            {
                orderExists.qty++;
            }
            else
            {
                GlobaVariables.ContainerOrder.preOrderList.Add(preorder);
            }
            GlobaVariables.menuWindow.tbOrder.Foreground = new SolidColorBrush(Colors.LimeGreen);
            GlobaVariables.menuWindow.tbChooseTable.Foreground = new SolidColorBrush(Colors.Black);
            GlobaVariables.menuWindow.tbMenu.Foreground = new SolidColorBrush(Colors.Black);
            NavigationService.Navigate(new OrderPage());
        }

        private void checkSale()
        {
            if ((DateTime.Now.Day == 29 || DateTime.Now.Day == 30 || DateTime.Now.Day == 31) && DateTime.Now.DayOfWeek.ToString() == "Saturday")
            {
                position.Cost = position.Cost * Convert.ToDecimal(0.89);
                tbPrice.Text = position.Cost.ToString() + "- с учетом скидки 11%";
            }
            else
            {
                tbPrice.Text ="Цена :"+position.Cost.ToString();
            }
        }
    }
}
