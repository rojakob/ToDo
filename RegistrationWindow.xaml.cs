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
    /// Interaction logic for RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
       
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            var email = EmailTextBox.Text;
            var name = UsernameTextBox.Text;
            var password = PasswordTextBox.Password;
            var confirmPassword = ConfirmPasswordTextBox.Password;

            if (password != confirmPassword)
            {
                MessageBox.Show("Пароли не совпадают!", "Ошибка синтаксиса", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!new Validator(email, Validator.ValidationType.Email).IsValid())
            {
                MessageBox.Show("Неверный формат Email!", "Ошибка синтаксиса", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!new Validator(password, Validator.ValidationType.Password).IsValid())
            {
                MessageBox.Show("Недопустимый пароль!", "Ошибка синтакисиса", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!new Validator(name, Validator.ValidationType.Name).IsValid())
            {
                MessageBox.Show("Недопустимое имя!", "Ошибка синтаксиса", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            new MainEmptyWindow().Show();
            Close();
        }
    }
}
