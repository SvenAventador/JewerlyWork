using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewerlyWork.Classes
{
    public class User
    {
        #region Поля и свойства
        private int _id;
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public int Id
        {
            get => _id;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "Идентификатор должен быть больше или равен 1!");
                _id = value;
            }
        }

        private string _login;
        /// <summary>
        /// Логин.
        /// </summary>
        public string Login
        {
            get => _login;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException(nameof(value), "Логин не может быть пустым или равен null!");
                _login = value;
            }
        }

        private string _password;
        /// <summary>
        /// Пароль.
        /// </summary>
        public string Password
        {
            get => _password;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException(nameof(value), "Пароль не может быть пустым или равен null!");
                _password = value;
            }
        }

        private string _role;
        /// <summary>
        /// Пароль.
        /// </summary>
        public string Role
        {
            get => _role;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException(nameof(value), "Пароль не может быть пустым или равен null!");
                _role = value;
            }
        }

        #endregion

        public override string ToString()
        {
            return $"№ {Id} " +
                   $"Логин: {Login} " +
                   $"Пароль: {Password} " +
                   $"Роль: {Role}" +
                   Environment.NewLine;
        }
    }
}
