using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewerlyWork.Classes
{
    /// <summary>
    /// Материал изделия.
    /// </summary>
    public class MaterialProduct
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

        private string _materialName;
        /// <summary>
        /// Название материала.
        /// </summary>
        public string MaterialName
        {
            get => _materialName;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException(nameof(value), "Название материала не может быть пустым или равняться null!");
                _materialName = value;
            }
        }

        private int _pricePerGramm;
        public int PricePerGramm
        {
            get => _pricePerGramm;
            set
            {
                if (value < 100)
                    throw new ArgumentOutOfRangeException(nameof(value), "Цена за грамм не может быть меньше 100 рублей!");
                _pricePerGramm = value;
            }
        }

        #endregion

        public override string ToString()
        {
            return $"№ {Id} " +
                   $"Наименование: {MaterialName} " +
                   $"Цена: {PricePerGramm}" + 
                   Environment.NewLine;
        }
    }
}
