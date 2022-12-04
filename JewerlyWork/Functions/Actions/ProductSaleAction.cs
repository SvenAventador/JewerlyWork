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

            var price = Other.Validator.GetPrintNumberOnConsole("Пожалуйста, введите цену товара, которая указана на прилавке: ") * count;

            var materialProduct = new Classes.ProductSale()
            {
                Id = readFile.Length == 0 ? 1
                                          : int.Parse(File.ReadAllLines(path)
                                                            .Last()
                                                            .Split(' ')[1]) + 1,
                FIO = fio,
                ProductName = name,
                ProductCount = count,
                AllPrice = price
            };

            File.AppendAllText(path, materialProduct.ToString(), Encoding.UTF8);
            Console.WriteLine("Заказ успешно оформлен!");
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
