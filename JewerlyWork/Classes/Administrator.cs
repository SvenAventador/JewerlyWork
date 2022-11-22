using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewerlyWork.Classes
{
    /// <summary>
    /// Администратор.
    /// </summary>
    public class Administrator
    {
        #region Поля и свойства.

        private int _id;
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public int Id
        {
            get => _id;
            set
            {
                if (value > 0)
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
            }
        }

        #endregion

        /// <summary>
        /// Администратор.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <param name="login"> Логин. </param>
        /// <param name="password"> Пароль. </param>
        public Administrator(int id, string login, string password)
        {
            Id = id;
            Login = login;
            Password = password;
        }
    }
}
