﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewerlyWork.Classes
{
    /// <summary>
    /// Продажа изделия.
    /// </summary>
    internal class ProductSale
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

        private string _fio;
        /// <summary>
        /// Фамилия имя отчество. 
        /// </summary>
        public string FIO
        {
            get => _fio;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException(nameof(value), "ФИО не может быть пустым или равное null!");
                if (value.Split(' ').Length != 3)
                    throw new ArgumentOutOfRangeException(nameof(value), "ФИО содержит 3 слова, а не больше или меньше!");
                _fio = value;
            }
        }

        private string _productName;
        /// <summary>
        /// Наименование изделия.
        /// </summary>
        public string ProductName
        {
            get => _productName;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException(nameof(value), "Наименование изделия не может быть пустым или равняться null!");
                _productName = value;
            }
        }

        private int _productCount;
        /// <summary>
        /// Количество продукции. 
        /// </summary>
        public int ProductCount
        {
            get => _productCount;
            set
            {
                if (value < 1)
                    throw new ArgumentOutOfRangeException(nameof(value), "Количество купленной продукции не может быть меньше 0!");
                _productCount = value;
            }
        }

        /// <summary>
        /// Дата покупки (сегодняшняя).
        /// </summary>
        public string SaleDate
        {
            get => DateTime.Now.ToShortDateString();
        }

        #endregion

        /// <summary>
        /// Продажа изделия.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <param name="fio"> ФИО. </param>
        /// <param name="name"> Наименование изделия. </param>
        /// <param name="count"> Количество купленного изделия. </param>
        public ProductSale(int id, string fio, string name, int count)
        {
            Id = id;
            FIO = fio;
            ProductName = name;
            ProductCount = count;
        }
    }
}
