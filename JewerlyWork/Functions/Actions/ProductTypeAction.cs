﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewerlyWork.Functions.Actions
{
    /// <summary>
    /// Взаимодействие с типом изделия.
    /// </summary>
    public static class ProductTypeAction
    {
        /// <summary>
        /// Добавление типа.
        /// </summary>
        /// <param name="path"></param>
        public static void AddProductType(string path)
        {
            var readFile = File.ReadAllLines(path);

            var productType = Other.Validator.GetStringOnConsole("Пожалуйсте, введите тип изделия: ");

            var type = new Classes.ProductType()
            {
                Id = readFile.Length == 0 ? 1
                                          : int.Parse(File.ReadAllLines(path)
                                                            .Last()
                                                            .Split(' ')[1]) + 1,
                ProductTypes = productType
            };

            File.AppendAllText(path, type.ToString(), Encoding.UTF8);
            Console.Write("Тип успешно добавлен!");
        }

        /// <summary>
        /// Изменение данных типа.
        /// <param name="path"> Путь к файлу.</param>
        /// <param name="stringNumber"> Номер строки. </param>
        /// </summary>
        public static void UpdateProductType(string path, int stringNumber)
        {
            var readAllFile = File.ReadAllLines(path);
            var certainString = File.ReadLines(path);

            var changeData = certainString.Skip(stringNumber - 1).First().Split(' ');

            var newData = Other.Validator.GetStringOnConsole("Введите новые данные: ");

            changeData[3] = newData;
            File.WriteAllText(path, String.Join(" ", changeData), Encoding.UTF8);
            Console.WriteLine("Данные успешно обновлены!");
        }

        /// <summary>
        /// Удаление данных типа.
        /// </summary>
        /// <param name="path"> Путь к файлу.</param>
        /// <param name="stringNumber"> Номер строки. </param>
        public static void DeleteProductType(string path, int stringNumber)
        {
            var readAllFile = File.ReadAllLines(path).ToList();

            readAllFile.RemoveAt(stringNumber - 1);
            var numberLine = 0;

            File.WriteAllText(path, string.Empty);

            foreach (var item in readAllFile)
            {
                numberLine++;
                var newLine = "";
                var dataArray = item.Split(' ');

                for (var i = 0; i < dataArray.Length; i++)
                {
                    newLine += i == 1 ? numberLine.ToString() + " "
                                      : dataArray[i] + " ";
                }

                File.AppendAllText(path, newLine.ToString() + Environment.NewLine);
            }
            Console.WriteLine("Тип под номером " + stringNumber.ToString() + " удален.");
            Thread.Sleep(0);
        }
    }
}
