using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewerlyWork.Classes
{
    /// <summary>
    /// Изделие.
    /// </summary>
    public class Product
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
                    throw new ArgumentNullException(nameof(value), "Наименование изделия не может быть пустой или равняться null!");
                _productName = value;
            }
        }

        private string _productType;
        /// <summary>
        /// Тип изделия.
        /// </summary>
        public string ProductType
        {
            get => _productType;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException(nameof(value), "Тип изделия не может быть пустым или равняться null!");
                _productType = value;
            }
        }

        private string _productMaterial;
        /// <summary>
        /// Материал изделия.
        /// </summary>
        public string ProductMaterial
        {
            get => _productMaterial;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException(nameof(value), "Материал изделия не может быть пустым или равняться null!");
                _productMaterial = value;
            }
        }

        private int _productWeight;
        /// <summary>
        /// Вес изделия.
        /// </summary>
        public int ProductWeight
        {
            get => _productWeight;
            set
            {
                if (value < 100)
                    throw new ArgumentOutOfRangeException(nameof(value), "Вес изделия не может быть меньше 100!");
                _productWeight = value;
            }
        }

        private int _productPrice;
        /// <summary>
        /// Цена изделия.
        /// </summary>
        public int ProductPrice
        {
            get => _productPrice;
            set
            {
                if (value < 1000)
                    throw new ArgumentOutOfRangeException(nameof(value), "Цена изделия не может быть меньше 1000!");
                _productPrice = value;
            }
        }

        #endregion

        public override string ToString()
        {
            return $"№ {Id} " +
                   $"Наименование: {ProductName} " +
                   $"Тип: {ProductType} " +
                   $"Материал: {ProductMaterial} " +
                   $"Вес: {ProductWeight} " +
                   $"Цена: {ProductPrice}" +
                   Environment.NewLine;
        }
    }
}
