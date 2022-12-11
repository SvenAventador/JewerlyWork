using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace JewerlyWork.Functions.Actions
{
    /// <summary>
    /// Действия с заказами.
    /// </summary>
    public static class ProductSaleAction
    {
        /// <summary>
        /// Оформление заказа.
        /// </summary>
        /// <param name="path"> Путь к файлу. </param>
        public static void AddOrder(string path)
        {
            var readFile = File.ReadAllLines(path);
            START:
            var fio = Other.Validator.GetStringOnConsole("Пожалуйста, введите Ваше ФИО: ");
            if (fio.Split(' ').GetLength(0) != 3)
            {
                Console.WriteLine("Вы должны ввести Фамилию Имя Отчество. Попробуйте еще раз!");
                goto START;
            }

            using (var sR = new StreamReader(Other.PathData.pathToProduct))
            {
                Console.WriteLine(sR.ReadToEnd());
            }
            START1:
            var name = Other.Validator.GetStringOnConsole("Пожалуйста, введите наименование: ");
            var readName = File.ReadAllText(Other.PathData.pathToProduct);
            if (!(readName.Contains(name)))
            {
                Console.WriteLine("Такого изделия нет. Попробуйте еще раз!");
                goto START1;
            }

            var count = Other.Validator.GetPrintNumberOnConsole("Пожалуйста, введите количество изделия: ");

            var price = Other.Validator.GetPrintNumberOnConsole("Пожалуйста, введите цену товара, которая указана на прилавке: ") * count * 0.97M;

            var productSale = new Classes.ProductSale()
            {
                Id = readFile.Length == 1 ? 1
                                          : int.Parse(File.ReadAllLines(path)
                                                            .Last()
                                                            .Split(' ')[1]) + 1,
                FIO = fio,
                ProductName = name,
                ProductCount = count,
                AllPrice = price
            };

            File.AppendAllText(path, productSale.ToString());
            Console.WriteLine("Заказ успешно оформлен!");

            var amount = 0M;
            var readAllLines = File.ReadAllLines(path);
            for (var i = 1; i < readAllLines.Length; i++)
            {
                var dataArray = readAllLines[i].Split(' ');
                amount += Convert.ToDecimal(dataArray[15]);
            }

            readAllLines[0] = $"Общая выручка: {amount}";

            File.WriteAllLines(path, readAllLines);

            Thread.Sleep(3000);
            Console.Clear();
        }

        /// <summary>
        /// Удаление данных заказа.
        /// </summary>
        /// <param name="path"> Путь к файлу. </param>
        /// <param name="stringNumber"> Номер строки. </param>
        public static void DeleteDataOrder(string path, int stringNumber)
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

                Console.Write(newLine);
                Console.WriteLine();
                File.AppendAllText(path, newLine.ToString() + Environment.NewLine);

            }
            Console.WriteLine("Изделие под номером " + stringNumber.ToString() + " удален.");
            Thread.Sleep(3000);
            Console.Clear();
            Thread.Sleep(0);
        }

    }
}
