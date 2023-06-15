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
using Tuga.Windows;

namespace Tuga.Pages
{
    /// <summary>
    /// Логика взаимодействия для OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {
        decimal sum = 0;
        public OrderPage()
        {
            InitializeComponent();
            lvOrder.ItemsSource = GlobaVariables.ContainerOrder.preOrderList;
            CountSum();
        }

        private void btnMinus_Click(object sender, RoutedEventArgs e)
        {
            var OrderRow = (sender as Button).DataContext as GlobaVariables.preOrder;
            if (OrderRow.qty==1)
            {
                GlobaVariables.ContainerOrder.preOrderList.Remove(OrderRow);
            }
            else
            {
                OrderRow.qty--;
            }
            lvOrder.ItemsSource = null;
            lvOrder.ItemsSource = GlobaVariables.ContainerOrder.preOrderList;
            CountSum();
        }

        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            var OrderRow = (sender as Button).DataContext as GlobaVariables.preOrder;
            OrderRow.qty++;
            lvOrder.ItemsSource = null;
            lvOrder.ItemsSource = GlobaVariables.ContainerOrder.preOrderList;
            CountSum();
        }

        private void CountSum()
        {
            if (GlobaVariables.ContainerOrder.preOrderList != null)
            {
                
                foreach (GlobaVariables.preOrder Row in GlobaVariables.ContainerOrder.preOrderList)
                {
                    sum += Row.sum;
                }
                if (GlobaVariables.UsedClient != null)
                {
                    if(GlobaVariables.UsedClient.BuyingSum<5000)
                    {
                        tbDiscount.Text = (sum * Convert.ToDecimal(0.01)).ToString();
                        sum = sum*Convert.ToDecimal(0.99);
                    }
                    else if (GlobaVariables.UsedClient.BuyingSum < 20000 && GlobaVariables.UsedClient.BuyingSum > 5000)
                    {
                        tbDiscount.Text = (sum * Convert.ToDecimal(0.03)).ToString();
                        sum = sum * Convert.ToDecimal(0.97);
                    }
                    else if (GlobaVariables.UsedClient.BuyingSum < 50000 && GlobaVariables.UsedClient.BuyingSum > 20000)
                    {
                        tbDiscount.Text = (sum * Convert.ToDecimal(0.05)).ToString();
                        sum = sum * Convert.ToDecimal(0.97);
                    }
                    else if (GlobaVariables.UsedClient.BuyingSum < 100000 && GlobaVariables.UsedClient.BuyingSum > 50000)
                    {
                        tbDiscount.Text = (sum * Convert.ToDecimal(0.05)).ToString();
                        sum = sum * Convert.ToDecimal(0.95);
                    }
                    if(GlobaVariables.UsedClient.BirthDay==DateTime.Today)
                    {
                        tbDiscount.Text = (sum * Convert.ToDecimal(0.1)).ToString();
                        sum = sum * Convert.ToDecimal(0.90);
                        
                    }
                }
                tbSummary.Text = "Итого: " + sum.ToString();
            }
           
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MenuPage());
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            if (GlobaVariables.ContainerOrder.preOrderList.Count() != 0)
            {
                var resClick = MessageBox.Show("Вы уверены, что готовы оформить заказ?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (resClick == MessageBoxResult.No)
                {
                    return;
                }
                EF.Order order = new EF.Order();
                order.IDEmpl = 1;
                order.IDTable = GlobaVariables.selectedTable.ID;
                order.DateTime = DateTime.Now;
                AppData.Context.Order.Add(order);
                AppData.Context.SaveChanges();
                foreach (GlobaVariables.preOrder Row in GlobaVariables.ContainerOrder.preOrderList)
                {
                    EF.OrderDish orderDish = new EF.OrderDish();
                    orderDish.IDOrder = order.ID;
                    orderDish.IDDish = Row.id;
                    orderDish.QTY = Row.qty;
                    AppData.Context.OrderDish.Add(orderDish);
                }
                if (GlobaVariables.UsedClient!=null)
                {
                    GlobaVariables.UsedClient.BuyingSum += Convert.ToInt32(sum);
                }
                AppData.Context.SaveChanges();
                PaymentWindow paymentWindow = new PaymentWindow();
                GlobaVariables.menuWindow.Hide();
                paymentWindow.ShowDialog();
                GlobaVariables.menuWindow.Close();
            }
            else
            {
                MessageBox.Show("Ваш заказ пуст", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
