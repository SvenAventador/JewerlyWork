using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewerlyWork.Functions.Actions
{
    /// <summary>
    /// Взаимодействие с материалом.
    /// </summary>
    public static class MaterialProductAction
    {
        /// <summary>
        /// Добавить материал.
        /// </summary>
        /// <param name="path"> Путь к файлу.</param>
        public static void AddMaterial(string path)
        {
            var readFile = File.ReadAllLines(path);

            var materialName = Other.Validator.GetStringOnConsole("Пожалуйста, введите название материала: ");
            var pricePerGramm = Other.Validator.GetPrintNumberOnConsole("Пожалуйста, введите цену за грамм: ");

            var materialProduct = new Classes.MaterialProduct()
            {
                Id = readFile.Length == 0 ? 1
                                          : int.Parse(File.ReadAllLines(path)
                                                            .Last()
                                                            .Split(' ')[1]) + 1,
                MaterialName = materialName,
                PricePerGramm = pricePerGramm,
            };

            File.AppendAllText(path, materialProduct.ToString());
            Console.WriteLine("Материал успешно добавлен!", Console.ForegroundColor = ConsoleColor.Green);
            Console.ForegroundColor = ConsoleColor.Black;
            Thread.Sleep(3000);
            Console.Clear();
        }

        /// <summary>
        /// Обновление данных.
        /// </summary>
        /// <param name="path"> Путь к файлу. </param>
        /// <param name="stringNumber"> Номер строки. </param>
        /// <param name="action"> Действие для изменения. </param>
        public static void UpdateDataMaterial(string path, int stringNumber, string action)
        {
            var readAllFile = File.ReadAllLines(path);
            var certainString = readAllFile.Skip(stringNumber - 1).First().Split(' ');

            var newData = Other.Validator.GetStringOnConsole("Пожалуйста, введите новые данные: ");

            certainString[action.ToLower() == "название" ? 3
                                                         : 5] = newData;

            readAllFile[stringNumber - 1] = String.Join(" ", certainString);

            File.WriteAllLines(path, readAllFile);
            Console.WriteLine("Данные успешно обновлены!", Console.ForegroundColor = ConsoleColor.Green);
            Console.ForegroundColor = ConsoleColor.Black;
            Thread.Sleep(3000);
            Console.Clear();
        }

        /// <summary>
        /// Удалить материал.   
        /// </summary>
        /// <param name="path"> Путь к файлу. </param>
        /// <param name="stringNumber"> Номер строки, который нужно удалить. </param>
        public static void DeleteDataMaterial(string path, int stringNumber)
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
            Console.WriteLine("Материал под номером " + stringNumber.ToString() + " удален.", Console.ForegroundColor = ConsoleColor.Green);
            Console.ForegroundColor = ConsoleColor.Black;
            Thread.Sleep(3000);
            Console.Clear();
            Thread.Sleep(0);
        }
    }
}
