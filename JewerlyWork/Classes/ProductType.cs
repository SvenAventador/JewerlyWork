using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewerlyWork.Classes
{
    /// <summary>
    /// Тип изделия.
    /// </summary>
    internal class ProductType
    {
        #region Тип изделия.

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

        private string _productType;
        public string ProductTypes
        {
            get => _productType;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException(nameof(value), "Тип изделия не может быть пустым или равняться null!");
            }
        }

        #endregion

        /// <summary>
        /// Тип изделия.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <param name="type"> Тип изделия. </param>
        public ProductType(int id, string type)
        {
            Id = id;
            ProductTypes = type;
        }
    }
}
