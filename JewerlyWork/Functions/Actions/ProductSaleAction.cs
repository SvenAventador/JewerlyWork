using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewerlyWork.Functions.Actions
{
    /// <summary>
    /// Действия с заказами.
    /// </summary>
    public static class ProductSaleAction
    {
        /*            return $"№ {Id} " +
                   $"ФИО: {FIO} " +
                   $"Наименование: {ProductName} " +
                   $"Количество: {ProductCount} " +
                   $"Дата заказа: {SaleDate} " +
                   $"Общая цена: {AllPrice}" +
                   Environment.NewLine;*/
        /// <summary>
        /// Оформление заказа.
        /// </summary>
        /// <param name="path"> Путь к файлу. </param>
        public static void AddOrder(string path)
        {
            var readFile = File.ReadAllLines(path);

            var fio = Other.Validator.GetStringOnConsole("Пожалуйста, введите Ваше ФИО: ");

            using (var sR = new StreamReader(Other.PathData.pathToProduct))
            {
                Console.WriteLine(sR.ReadToEnd());
            }
            START:
            var name = Other.Validator.GetStringOnConsole("Пожалуйста, введите наименование: ");
            var readName = File.ReadAllText(Other.PathData.pathToProduct);
            if (readName.Contains(name))
            {
                Console.WriteLine("Такого изделия нет. Попробуйте еще раз!");
                goto START;
            }

            var count = Other.Validator.GetPrintNumberOnConsole("Пожалуйста, введите количество изделия: ");
            var readCertainString = File.ReadLines(Other.PathData.pathToProduct).Where(x => x == name).First().Split(' ');

            var price = count * Convert.ToInt32(readCertainString[11]);

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
            Console.Write("Заказ успешно оформлен!");
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
            Thread.Sleep(0);
        }

    }
}
