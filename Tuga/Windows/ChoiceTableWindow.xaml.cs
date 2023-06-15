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
using System.Windows.Shapes;
using Tuga.ClassHelper;

namespace Tuga.Windows
{
    /// <summary>
    /// Логика взаимодействия для ChoiceTableWindow.xaml
    /// </summary>
    public partial class ChoiceTableWindow : Window
    {
        EF.IDTable idtable=null;
        public ChoiceTableWindow()
        {
            InitializeComponent();
            updateTables();

            this.WindowStyle = WindowStyle.None;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            string id = (sender as Button).Name;
            id = id.Remove(0,3);
            EF.IDTable table = ClassHelper.AppData.Context.IDTable.Where(i => i.ID==id).FirstOrDefault();
            idtable = table;
            if (table.IsAvalible != false)
            {
                table.IsAvalible = false;
                GlobaVariables.selectedTable = table;
                ClassHelper.AppData.Context.SaveChanges();
                SaleCardWindow saleCardWindow=new SaleCardWindow();
                JoinNotificationBrd.Visibility = Visibility.Collapsed;
                PlugBrd.Visibility = Visibility.Collapsed;
                this.Hide();
                saleCardWindow.ShowDialog();
                updateTables();
                this.ShowDialog();
            }
            else
            {
                if (table.PeopleQTY < 6 && (table.ID=="V1"||table.ID=="V2"))
                {
                    PlugBrd.Visibility=Visibility.Visible;
                    JoinNotificationBrd.Visibility = Visibility.Visible;
                }
                else if (table.PeopleQTY < 4)
                {
                    PlugBrd.Visibility = Visibility.Visible;
                    JoinNotificationBrd.Visibility = Visibility.Visible;
                }
                else
                {
                    PlugBrd.Visibility = Visibility.Visible;
                    JoinNotificationBrd.Visibility = Visibility.Visible;
                    NotificationTb.Text = "Все места за столиком уже заняты";
                    btnYesJoin.Visibility = Visibility.Collapsed;
                    btnNoJoin.Content = "Ок";
                    btnNoJoin.Margin = new Thickness(250, 100, 0, 0);
                }
            }
            
        }

        private void updateTables()
        {
            List<EF.IDTable> tables = ClassHelper.AppData.Context.IDTable.ToList();
            foreach (EF.IDTable table in tables)
            {
                if (table.IsAvalible == false)
                {
                    if (TableGrd.FindName("btn" + table.ID) is Button button)
                    {
                        //button.IsEnabled = false;

                        if (TableGrd.FindName("imgbtn" + table.ID) is Image image)
                        {
                            image.Source = new BitmapImage(new Uri("/Photo/Занятый столик " + table.ID+".png", UriKind.Relative)) { CreateOptions = BitmapCreateOptions.IgnoreImageCache };
                        }

                    }
                }
            }
        }

        private void btnBegin_Click(object sender, RoutedEventArgs e)
        {
            btnBegin.Visibility = Visibility.Collapsed;
            TableGrd.Visibility = Visibility.Visible;
        }

        private void btnYesJoin_Click(object sender, RoutedEventArgs e)
        {
            GlobaVariables.selectedTable = idtable;
            idtable.PeopleQTY++;
            ClassHelper.AppData.Context.SaveChanges();
            JoinNotificationBrd.Visibility = Visibility.Collapsed;
            PlugBrd.Visibility = Visibility.Collapsed;
            SaleCardWindow saleCardWindow = new SaleCardWindow();
            this.Hide();
            saleCardWindow.ShowDialog();
            updateTables();
            this.ShowDialog();
        }

        private void btnNoJoin_Click(object sender, RoutedEventArgs e)
        {
            PlugBrd.Visibility = Visibility.Collapsed;
            JoinNotificationBrd.Visibility = Visibility.Collapsed;
            NotificationTb.Text = "Столик уже занят, хотите присоединиться?";
            btnYesJoin.Visibility = Visibility.Visible;
            btnNoJoin.Content = "Нет";
            btnNoJoin.Margin = new Thickness(90, 100, 0, 0);
        }
    }
}
