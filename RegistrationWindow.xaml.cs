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
using Todo.Entities;
using WPFLabs.Repository;

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

            var user = new UserModel { Email = email, Name = name, Password = password };
            if (UserRepository.RegisterUser(user))
            {
                MessageBox.Show("Регистрация прошла успешно!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                new MainEmptyWindow().Show();
                Close();
            }
            else
            {
                MessageBox.Show("Ошибка при регистрации. Некорректный адрес электронной почты.", "Ошибка регистрации", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            
        }
    }
}
