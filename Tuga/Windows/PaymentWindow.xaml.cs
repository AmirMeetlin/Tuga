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
    /// Логика взаимодействия для PaymentWindow.xaml
    /// </summary>
    public partial class PaymentWindow : Window
    {
        public PaymentWindow()
        {
            InitializeComponent();

                this.WindowStyle = WindowStyle.None;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void PayByCardBtn_Click(object sender, RoutedEventArgs e)
        {
            GlobaVariables.UsedClient = null;
            GlobaVariables.selectedTable = null;    
            GlobaVariables.ContainerOrder.preOrderList = new List<GlobaVariables.preOrder>();
            this.Close();
            
        }

        private void AuthBtn_Click(object sender, RoutedEventArgs e)
        {
            GlobaVariables.UsedClient = null;
            GlobaVariables.selectedTable = null;
            GlobaVariables.ContainerOrder.preOrderList = null;
            this.Close();
        }
    }
}
