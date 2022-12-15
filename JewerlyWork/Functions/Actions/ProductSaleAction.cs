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
        public static void AddOrder(string path, string surname, string name, string patronymic)
        {
            var readFile = File.ReadAllLines(path);
            Console.ForegroundColor = ConsoleColor.Black;
            var fio = $"{surname} {name} {patronymic}";

            using (var sR = new StreamReader(Other.PathData.pathToProduct))
            {
                Console.WriteLine(sR.ReadToEnd());
            }

            Console.ForegroundColor = ConsoleColor.Black;

            var stringNumber = Other.Validator.GetPrintNumberOnConsole("Пожалуйста, введите номер товара, который Вы хотите купить: ");
            var readProduct = File.ReadAllLines(Other.PathData.pathToProduct);
            var certainString = readProduct.Skip(stringNumber - 1).First().Split(' ');

            var count = Other.Validator.GetPrintNumberOnConsole("Пожалуйста, введите количество изделия: ");

            var price = Convert.ToInt32(certainString[11]) * count * 0.97M;

            var productSale = new Classes.ProductSale()
            {
                Id = readFile.Length == 1 ? 1
                                          : int.Parse(File.ReadAllLines(path)
                                                            .Last()
                                                            .Split(' ')[1]) + 1,
                FIO = fio,
                ProductName = certainString[3],
                ProductCount = count,
                AllPrice = price
            };

            File.AppendAllText(path, productSale.ToString());
            Console.WriteLine("Заказ успешно оформлен!", Console.ForegroundColor = ConsoleColor.Green);

            var amount = 0M;
            var readAllLines = File.ReadAllLines(path);

            for (var i = 1; i < readAllLines.Length; i++)
            {
                var dataArray = readAllLines[i].Split(' ');
                amount += Convert.ToDecimal(dataArray[15]);
            }

            readAllLines[0] = $"Общая выручка: {amount} рублей.";

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
            readAllFile.RemoveAt(0);
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
                File.AppendAllText(path, newLine.ToString() + Environment.NewLine, Encoding.UTF8);
            }

            var amount = 0M;
            var readAllLines = File.ReadAllLines(path).ToList();
            File.WriteAllText(path, string.Empty);

            foreach (var item in readAllLines) 
            {
                var dataArray = item.Split(' ');
                amount += Convert.ToDecimal(dataArray[15]);
            }

            var value = $"Общая выручка: {amount} рублей.";
            readAllLines.Insert(0, value);

            File.WriteAllLines(path, readAllLines);

            Console.WriteLine("Изделие под номером " + stringNumber.ToString() + " удален.", Console.ForegroundColor = ConsoleColor.Green);
            Console.ForegroundColor = ConsoleColor.Black;
            Thread.Sleep(3000);
            Console.Clear();
            Thread.Sleep(0);
        }

    }
}
