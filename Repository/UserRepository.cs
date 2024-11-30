using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Entities;

namespace WPFLabs.Repository
{
    internal class UserRepository
    {
        private static List<UserModel> _users = new List<UserModel>();
        private static int _nextId = 1;

        public static bool RegisterUser(UserModel user)
        {
            if (string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Name) || string.IsNullOrEmpty(user.Password))
            {
                return false; //пустые поля
            }

            if (!new Validator(user.Email, Validator.ValidationType.Email).IsValid())
            {
                return false; //неверный email
            }

            if (!new Validator(user.Password, Validator.ValidationType.Password).IsValid())
            {
                return false; //неверный пароль
            }

            if (!new Validator(user.Name, Validator.ValidationType.Name).IsValid())
            {
                return false; //неверное имя
            }

            if (_users.Any(u => u.Email == user.Email))
            {
                return false; //логин уже занят
            }

            user.Id = _nextId++;
            _users.Add(user);
            return true;
        }


        public static UserModel AuthenticateUser(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                return null; //пустые поля
            }

            return _users.FirstOrDefault(u => u.Email == email && u.Password == password);
        }
    }
}
