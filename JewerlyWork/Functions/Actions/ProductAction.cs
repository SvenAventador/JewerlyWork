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
            Console.WriteLine(@"/--------------------------------\");
            using (var sR = new StreamReader(Other.PathData.pathToProductType))
            {
                Console.WriteLine(sR.ReadToEnd());
            }

            START:
            var readType = File.ReadAllLines(Other.PathData.pathToProductType);
            var type = Other.Validator.GetStringOnConsole("Пожалуйста, введите тип: ");
            var typeFlag = false;

            foreach (var item in readType)
            {
                var dataArray = item.Split(' ');

                if (type == dataArray[3])
                {
                    typeFlag = true;
                    break;
                }
                else
                    typeFlag = false;
            }

            if (!(typeFlag))
            {
                Console.WriteLine("Такого типа не найдено. Попробуйте еще раз!");
                goto START;
            }

            Console.WriteLine(@"/--------------------------------\");
            using (var sR = new StreamReader(Other.PathData.pathToMaterialProduct))
            {
                Console.WriteLine(sR.ReadToEnd());
            }

            START1:
            var readMaterial = File.ReadAllLines(Other.PathData.pathToMaterialProduct);
            var material = Other.Validator.GetStringOnConsole("Пожалуйста, введите материал: ");
            var materialFlag = false;

            foreach (var item in readMaterial)
            {
                var dataArray = item.Split(' ');

                if (material == dataArray[3])
                {
                    materialFlag = true;
                    break;
                }
                else
                    materialFlag = false;
            }

            if (!(materialFlag))
            {
                Console.WriteLine("Данного материала не найдено. Пожалуйста, введите данные еще раз!");
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

            File.AppendAllText(path, product.ToString());
            Console.WriteLine("Изделие успешно добавлено!");
            Thread.Sleep(3000);
            Console.Clear();
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
            var certainString = readAllFile.Skip(stringNumber - 1).First().Split(' ');

            var newData = Other.Validator.GetStringOnConsole("Пожалуйста, введите новые данные: ");

            certainString[action.ToLower() == "название" ? 3
                                                         : (action.ToLower() == "тип") ? 5
                                                                                      : (action.ToLower() == "материал") ? 7
                                                                                                                         : (action.ToLower() == "вес") ? 9
                                                                                                                                                       : 11] = newData;

            readAllFile[stringNumber - 1] = String.Join(" ", certainString);

            File.WriteAllLines(path, readAllFile);
            Console.WriteLine("Данные успешно обновлены!");
            Thread.Sleep(3000);
            Console.Clear();
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
                File.AppendAllText(path, newLine.ToString() + Environment.NewLine, Encoding.UTF8);

            }
            Thread.Sleep(0);
            Console.WriteLine("Изделие под номером " + stringNumber.ToString() + " удален.");
            Thread.Sleep(3000);
            Console.Clear();
        }
    }
}
