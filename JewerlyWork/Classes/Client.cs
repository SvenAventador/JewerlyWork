using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewerlyWork.Classes
{
    /// <summary>
    /// Клиент (Покупатель).
    /// </summary>
    public class Client
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

        private string _surname;
        /// <summary>
        /// Фамилия.
        /// </summary>
        public string Surname
        {
            get => _surname;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException(nameof(value), "Фамилия не может быть пустой или равна null");
                _surname = value;
            }
        }

        private string _name;
        /// <summary>
        /// Имя.
        /// </summary>
        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException(nameof(value), "Имя не может быть пустой или равна null");
                _name = value;
            }
        }

        private string _patronymic;
        /// <summary>
        /// Отчество.
        /// </summary>
        public string Patronymic
        {
            get => _patronymic;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException(nameof(value), "Отчество не может быть пустой или равна null");
                _patronymic = value;
            }
        }

        private DateTime _dateOfBirth;
        /// <summary>
        /// Дата рождения.
        /// </summary>
        public DateTime DateOfBirth
        {
            get => _dateOfBirth;
            set
            {
                if (value.Year - DateTime.Now.Year < 18)
                    throw new ArgumentOutOfRangeException(nameof(value), "К сожалению, в нашем магазине" +
                                                                         " изделия могут покупать только соверщеннолетние!");
                _dateOfBirth = value;
            }
        }
        #endregion

        /// <summary>
        /// Клиент.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <param name="surname"> Фамилия. </param>
        /// <param name="name"> Имя. </param>
        /// <param name="patronymic"> Отчество. </param>
        /// <param name="bDate"> Дата рождения. </param>
        public Client(int id, string surname, string name, string patronymic, DateTime bDate)
        {
            Id = id;
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            DateOfBirth = bDate;
        }
    }
}
