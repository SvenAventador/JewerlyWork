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

            File.AppendAllText(path, materialProduct.ToString(), Encoding.UTF8);
            Console.Write("Материал успешно добавлен!");
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
            var certainString = File.ReadLines(path);

            var changeData = certainString.Skip(stringNumber - 1).First().Split(' ');

            var newData = Other.Validator.GetStringOnConsole("Введите новые данные: ");

            changeData[action == "Название" ? 3
                                            : 5] = newData;
            File.WriteAllText(path, String.Join(" ", changeData), Encoding.UTF8);
            Console.WriteLine("Данные успешно обновлены!");
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
            Console.WriteLine("Материал под номером " + stringNumber.ToString() + " удален.");
            Thread.Sleep(0);
        }
    }
}
