using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewerlyWork.Functions.Other
{
    /// <summary>
    /// Обработчик ошибок.
    /// </summary>
    public static class Validator
    {
        /// <summary>
        /// Проверка на то, было ли введено в консоль число.
        /// </summary>
        /// <param name="message"> Сообщение. </param>
        /// <returns> Число, введенное с клавиатуры. </returns>
        public static int GetPrintNumberOnConsole(string message)
        {
            Console.Write(message);

            var value = 0;
            while (!int.TryParse(Console.ReadLine(), out value))
            {
                Console.WriteLine("Пожалуйста, введите число! Введите данные еще раз.");
                Console.Write(message);
            }

            return value;
        }

        /// <summary>
        /// Проверка на то, было ли введено в консоль денежное значение.
        /// </summary>
        /// <param name="message"> Сообщение. </param>
        /// <returns> Денежное значение, введенное с клавиатуры. </returns>
        public static decimal GetPrintMoneyOnConsole(string message)
        {
            Console.Write(message);

            var value = 0M;
            while (!decimal.TryParse(Console.ReadLine(), out value))
            {
                Console.WriteLine("Пожалуйста, введите денежное значение! Введите данные еще раз.");
                Console.Write(message);
            }

            return value;
        }

        /// <summary>
        /// Проверка на то, была ли введена дата в консоль.
        /// </summary>
        /// <param name="message"> Сообщение. </param>
        /// <returns> Дата, введенная с клавиатуры. </returns>
        public static DateTime GetPrintDateOnConsole(string message)
        {
            START:
            Console.Write(message);
            var yourDate = Console.ReadLine();
            var dateFormat = "yyyy-MM-dd";
            DateTime sheduleDate;

            while (!DateTime.TryParseExact(yourDate,
                                         dateFormat,
                                         DateTimeFormatInfo.InvariantInfo,
                                         DateTimeStyles.None,
                                         out sheduleDate))
            {
                Console.WriteLine($"Дата рождения должна быть внесена следующим форматом: {dateFormat}");
                goto START;
            }

            return DateTime.Parse(DateTime.Parse(yourDate).ToShortDateString());
        }

        /// <summary>
        /// Ввод НЕ пустой строки в консоль.
        /// </summary>
        /// <param name="message"> Сообщение для вывода. </param>
        /// <returns> НЕ пустая строка. </returns>
        public static string GetStringOnConsole(string message)
        {
            START:
            Console.Write(message);
            var value = Console.ReadLine();

            if (string.IsNullOrEmpty(value))
            {
                Console.WriteLine("Пожалуйста, введите значение!");
                goto START;
            }

            return value;
        }
    }
}
