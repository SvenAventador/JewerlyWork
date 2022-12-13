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
            Console.ForegroundColor = ConsoleColor.Black;
            var fio = Other.Validator.GetStringOnConsole("Пожалуйста, введите Ваше ФИО: ");
            var readClient = File.ReadAllLines(Other.PathData.pathToClient);
            var clientFlag = false;

            if (fio.Split(' ').GetLength(0) != 3)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Вы должны ввести Фамилию Имя Отчество. Попробуйте еще раз!");
                goto START;
            }

            foreach (var item in readClient)
            {
                var dataArray = item.Split(' ');

                if (($"{fio.ToLower()}")
                    ==
                    ($"{dataArray[3].ToLower()} {dataArray[5].ToLower()} {dataArray[7].ToLower()}"))
                {
                    clientFlag = true;
                    break;
                }
                else
                    clientFlag = false;
            }

            if (!(clientFlag))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Таких данных не найдено в системе. Введите данные еще раз!");
                goto START;
            }

            using (var sR = new StreamReader(Other.PathData.pathToProduct))
            {
                Console.WriteLine(sR.ReadToEnd());
            }
            START1:
            Console.ForegroundColor = ConsoleColor.Black;
            var name = Other.Validator.GetStringOnConsole("Пожалуйста, введите наименование: ");
            var readName = File.ReadAllLines(Other.PathData.pathToProduct);
            var nameFlag = false;

            foreach (var item in readName)
            {
                var dataArray = item.Split(' ');

                if (name == dataArray[3])
                {
                    nameFlag = true;
                    break;
                }
                else
                    nameFlag = false;
            }

            if (!(nameFlag))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("У нас не найден такой товар. Попробуйте ввести данные еще раз!");
                goto START1;
            }

            var count = Other.Validator.GetPrintNumberOnConsole("Пожалуйста, введите количество изделия: ");

            START2:
            Console.ForegroundColor = ConsoleColor.Black;
            var price = Other.Validator.GetPrintMoneyOnConsole("Пожалуйста, введите цену товара, которая указана на прилавке: ");
            var readPrice = File.ReadAllLines(Other.PathData.pathToProduct);
            var priceFlag = false;

            foreach (var item in readPrice)
            {
                var dataArray = item.Split(' ');

                if ((name == dataArray[3]) &&
                    (price.ToString() == dataArray[11]))
                {
                    priceFlag = true;
                    break;
                }
                else
                    priceFlag = false;
            }

            if (!(priceFlag))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Не пытайтесь нас обмануть! Данного ценника нет на прилавке! Введите данные еще раз!");
                goto START2;
            }

            price = price * count * 0.97M;

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
            Console.WriteLine("Изделие под номером " + stringNumber.ToString() + " удален.", Console.ForegroundColor = ConsoleColor.Green);
            Console.ForegroundColor = ConsoleColor.Black;
            Thread.Sleep(3000);
            Console.Clear();
            Thread.Sleep(0);
        }

    }
}
