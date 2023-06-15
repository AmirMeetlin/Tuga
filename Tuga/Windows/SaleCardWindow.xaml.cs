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
    /// Логика взаимодействия для SaleCardWindow.xaml
    /// </summary>
    public partial class SaleCardWindow : Window
    {

        int isRegistration;
        public SaleCardWindow()
        {
            InitializeComponent();
            this.WindowStyle = WindowStyle.None;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void SkipBtn_Click(object sender, RoutedEventArgs e)
        {
            MenuWindow menuWindow = new MenuWindow();
            GlobaVariables.menuWindow = menuWindow;
            this.Hide();
            menuWindow.ShowDialog();
            this.Close();
        }

        private void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            RegisterGrd.Visibility = Visibility.Visible;
            RegistrationBtnsWP.Visibility = Visibility.Visible;
            ActionWithCardWp.Visibility = Visibility.Collapsed;
            SaleCardRequestImg.Visibility = Visibility.Collapsed;
            PirateImg.Margin=new Thickness(0);
            isRegistration = 1;
        }

        private void AuthBtn_Click(object sender, RoutedEventArgs e)
        {
            EnterPhoneWp.Visibility = Visibility.Visible;
            RegistrationBtnsWP.Visibility=Visibility.Visible;
            CancelBtn.Margin= new Thickness(400,0,0,0);
            OkBtn.Margin=new Thickness(100,0,0,0);
            ActionWithCardWp.Visibility = Visibility.Collapsed;
            SaleCardRequestImg.Visibility = Visibility.Collapsed;
            isRegistration = 0;
        }

        private void NameTb_GotFocus(object sender, RoutedEventArgs e)
        {
            HintNameTb.Visibility = Visibility.Collapsed;
        }

        private void NameTb_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameTb.Text) == false)
            {
                HintNameTb.Visibility = Visibility.Collapsed;
            }
            else
            {
                HintNameTb.Visibility = Visibility.Visible;
            }
        }

        private void BirthTb_GotFocus(object sender, RoutedEventArgs e)
        {
            HintBirthTb.Visibility = Visibility.Collapsed;
        }

        private void BirthTb_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(BirthTb.Text) == false)
            {
                HintBirthTb.Visibility = Visibility.Collapsed;
            }
            else
            {
                HintBirthTb.Visibility = Visibility.Visible;
            }
        }

        private void PhoneTb_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PhoneTb.Text) == false)
            {
                HintPhoneTb.Visibility = Visibility.Collapsed;
            }
            else
            {
                HintPhoneTb.Visibility = Visibility.Visible;
            }
        }

        private void PhoneTb_GotFocus(object sender, RoutedEventArgs e)
        {
            HintPhoneTb.Visibility = Visibility.Collapsed;
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            if (isRegistration == 1)
            {
                RegisterGrd.Visibility = Visibility.Collapsed;
                RegistrationBtnsWP.Visibility = Visibility.Collapsed;
                ActionWithCardWp.Visibility = Visibility.Visible;
                SaleCardRequestImg.Visibility = Visibility.Visible;
                PirateImg.Margin = new Thickness(50,0,0,50);
                isRegistration = -1;
            }
            else
            {
                EnterPhoneWp.Visibility = Visibility.Collapsed;
                RegistrationBtnsWP.Visibility = Visibility.Collapsed;
                CancelBtn.Margin = new Thickness(220, 0, 0, 0);
                OkBtn.Margin = new Thickness(220, 0, 0, 0);
                ActionWithCardWp.Visibility = Visibility.Visible;
                SaleCardRequestImg.Visibility = Visibility.Visible;
                isRegistration = -1;
            }
        }

        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            if (isRegistration == 1)
            {
                if (string.IsNullOrWhiteSpace(NameTb.Text))
                {
                    PlugBrd.Visibility = Visibility.Visible;
                    NotificationBrd.Visibility = Visibility.Visible;
                    NotificationTb.Text = "Укажите имя!";
                }
                else if (string.IsNullOrWhiteSpace(PhoneTb.Text))
                {
                    PlugBrd.Visibility = Visibility.Visible;
                    NotificationBrd.Visibility = Visibility.Visible;
                    NotificationTb.Text = "Укажите номер телефона!";
                }
                else if (string.IsNullOrWhiteSpace(BirthTb.Text)) 
                {
                    PlugBrd.Visibility = Visibility.Visible;
                    NotificationBrd.Visibility = Visibility.Visible;
                    NotificationTb.Text = "Укажите день рождения!";
                }
                else if(DateTime.TryParse(BirthTb.Text, out DateTime date) == false)
                {
                    PlugBrd.Visibility = Visibility.Visible;
                    NotificationBrd.Visibility = Visibility.Visible;
                    NotificationTb.Text = "Указан неверный формат даты!";
                }
                else if (PhoneTb.Text.Length<10)
                {
                    PlugBrd.Visibility = Visibility.Visible;
                    NotificationBrd.Visibility = Visibility.Visible;
                    NotificationTb.Text = "Указан неверный формат номера телефона!";
                }
                else
                {
                    EF.Client client= new EF.Client();
                    client.FirstName = NameTb.Text;
                    client.Phone = "7"+PhoneTb.Text;
                    client.IsDeleted = false;
                    client.BirthDay = Convert.ToDateTime(BirthTb.Text);
                    ClassHelper.AppData.Context.Client.Add(client);
                    ClassHelper.AppData.Context.SaveChanges();
                    GlobaVariables.UsedClient = client;

                    MenuWindow menuWindow = new MenuWindow();
                    GlobaVariables.menuWindow = menuWindow;
                    this.Hide();
                    menuWindow.ShowDialog();
                    this.Close();
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(AuthPhoneTb.Text))
                {
                    PlugBrd.Visibility = Visibility.Visible;
                    NotificationBrd.Visibility = Visibility.Visible;
                    NotificationTb.Text = "Укажите номер телефона!";
                }
                else if (AuthPhoneTb.Text.Length < 10)
                {
                    PlugBrd.Visibility = Visibility.Visible;
                    NotificationBrd.Visibility = Visibility.Visible;
                    NotificationTb.Text = "Указан неверный формат номера телефона!";
                }
                else
                {
                    
                    if (AuthPhoneTb.Text.Length == 10)
                    {
                       var authUser = AppData.Context.Client.Where(i => i.Phone == "7" + AuthPhoneTb.Text+" ").FirstOrDefault();

                        if (authUser != null)
                        {
                            GlobaVariables.UsedClient = authUser;

                            MenuWindow menuWindow = new MenuWindow();
                            GlobaVariables.menuWindow = menuWindow;
                            this.Hide();
                            menuWindow.ShowDialog();
                            this.Close();
                        }
                        else
                        {
                            PlugBrd.Visibility = Visibility.Visible;
                            NotificationBrd.Visibility = Visibility.Visible;
                            NotificationTb.Text = "Пользователь не найден!";
                        }
                    }
                    else
                    {
                      var authUser = AppData.Context.Client.Where(i => i.Phone == "7" + AuthPhoneTb.Text).FirstOrDefault();

                        if (authUser != null)
                        {
                            GlobaVariables.UsedClient = authUser;

                            MenuWindow menuWindow = new MenuWindow();
                            GlobaVariables.menuWindow = menuWindow;
                            this.Hide();
                            menuWindow.ShowDialog();
                            this.Close();
                        }
                        else
                        {
                            PlugBrd.Visibility = Visibility.Visible;
                            NotificationBrd.Visibility = Visibility.Visible;
                            NotificationTb.Text = "Пользователь не найден!";
                        }
                    }                   
                    
                }
                
            }
        }

        private void PhoneTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true; // Запретить ввод символов, отличных от цифр
            }
        }

        private void BirthTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text[0]) && e.Text[0] != '.')
            {
                e.Handled = true; // Запретить ввод символа
            }
        }

        private void Tbs_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true; // Запретить обработку нажатия клавиши пробела
            }
        }

        private void NameTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            foreach (char c in e.Text)
            {
                if (!char.IsLetter(c))
                {
                    e.Handled = true; // Запретить обработку ввода символа, если это не буква
                    break;
                }
            }
        }

        private void btnNoJoin_Click(object sender, RoutedEventArgs e)
        {
            PlugBrd.Visibility = Visibility.Collapsed;
            NotificationBrd.Visibility = Visibility.Collapsed;
        }
    }
}
