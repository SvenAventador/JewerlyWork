using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewerlyWork.Functions.Actions
{
    /// <summary>
    /// Действия изделия.
    /// </summary>
    public static class ProductAction
    {
        /// <summary>
        /// Добавление изделия.
        /// </summary>
        /// <param name="path"> Путь к файлу. </param>
        public static void AddProduct(string path)
        {
            var readFile = File.ReadAllLines(path);

            var name = Other.Validator.GetStringOnConsole("Пожалуйста, введите название: ");
            using (var sR = new StreamReader(Other.PathData.pathToProductType))
            {
                Console.WriteLine(sR.ReadToEnd());
            }
            START:
            var readType = File.ReadAllText(Other.PathData.pathToProductType);
            var type = Other.Validator.GetStringOnConsole("Пожалуйста, введите тип: ");
            if (!(readType.Contains(type)))
            {
                Console.WriteLine("Такого типа не найдено! Попробуйте еще раз!");
                goto START;
            }

            using (var sR = new StreamReader(Other.PathData.pathToMaterialProduct))
            {
                Console.WriteLine(sR.ReadToEnd());
            }    
            START1:
            var readMaterial = File.ReadAllText(Other.PathData.pathToMaterialProduct);
            var material = Other.Validator.GetStringOnConsole("Пожалуйста, введите материал: ");
            if (!(readMaterial.Contains(material)))
            {
                Console.WriteLine("Такого материала не найдено! Попробуйте еще раз!");
                goto START1;
            }

            var weight = Other.Validator.GetPrintNumberOnConsole("Пожалуйста, введите вес: ");
            var price = Other.Validator.GetPrintNumberOnConsole("Пожалуйста, введите цену: ");

            var product = new Classes.Product()
            {
                Id = readFile.Length == 0 ? 1
                                          : int.Parse(File.ReadAllLines(path)
                                                            .Last()
                                                            .Split(' ')[1]) + 1,
                ProductName = name,
                ProductType = type,
                ProductMaterial = material,
                ProductWeight = weight,
                ProductPrice = price
            };

            File.AppendAllText(path, product.ToString(), Encoding.UTF8);
            Console.WriteLine("Изделие успешно добавлено!");
        }


        /// <summary>
        /// Изменение данных изделия.
        /// </summary>
        /// <param name="path"> Путь к файлу. </param>
        /// <param name="stringNumber"> Номер строки. </param>
        /// <param name="action"> Действие для изменения. </param>
        public static void UpdateDataProduct(string path, int stringNumber, string action)
        {
            var readAllFile = File.ReadAllLines(path);
            var certainString = File.ReadLines(path);

            var changeData = certainString.Skip(stringNumber - 1).First().Split(' ');

            var arrayCount = (action == "Название") ? 3
                                                  : (action == "Тип") ? 5
                                                                      : (action == "Материал") ? 7
                                                                                               : (action == "Вес") ? 9
                                                                                                                   : 10;

            var newData = Other.Validator.GetStringOnConsole("Пожалуйста, введите новые данные: ");

            changeData[arrayCount] = newData;

            File.WriteAllText(path, string.Join(" ", changeData), Encoding.UTF8);
            Console.WriteLine("Данные успешно обновлены!");
        }

        /// <summary>
        /// Удаление изделия.
        /// </summary>
        /// <param name="path"> Путь к файлу. </param>
        /// <param name="stringNumber"> Номер строки. </param>
        public static void DeleteDataProduct(string path, int stringNumber)
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
