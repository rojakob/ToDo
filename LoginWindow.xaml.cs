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

namespace WPFLabs
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var email = EmailTextBox.Text;
            var password = PasswordTextBox.Password;

            if (!new Validator(email, Validator.ValidationType.Email).IsValid())
            {
                MessageBox.Show("Неверный формат Email!", "Ошибка синтаксиса", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!new Validator(password, Validator.ValidationType.Password).IsValid())
            {
                MessageBox.Show("Недопустимый пароль!", "Ошибка синтаксиса", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            new MainEmptyWindow().Show();
            Close();
        }

        private void RegistrationWindow_Click(object sender, RoutedEventArgs e)
        {
            new RegistrationWindow().Show();
            Close();
        }
    }
}
