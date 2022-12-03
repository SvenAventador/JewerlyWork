using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewerlyWork.Functions.Actions
{
    /// <summary>
    /// Действия клиента.
    /// </summary>
    public static class ClientAction
    {
        /// <summary>
        /// Добавление клиента.
        /// </summary>
        /// <param name="path"> Путь к файлу. </param>
        public static void AddClient(string path)
        {
            var readFile = File.ReadAllLines(path);

            var surname = Functions.Other.Validator.GetStringOnConsole("Пожалуйста, введите Вашу фамилию: ");
            var name = Functions.Other.Validator.GetStringOnConsole("Пожалуйста, введите Ваше имя: ");
            var patronymic = Functions.Other.Validator.GetStringOnConsole("Пожалуйста, введите Ваше отчество: ");
            var birthDay = Functions.Other.Validator.GetPrintDateOnConsole("Пожалуйста, введите дату Вашего рождения формата (yyyy-MM-dd): ");

            var client = new Classes.Client()
            {
                Id = readFile.Length == 0 ? 1
                                          : int.Parse(File.ReadAllLines(path)
                                                            .Last()
                                                            .Split(' ')[1]) + 1,
                Surname = surname,
                Name = name,
                Patronymic = patronymic,
                DateOfBirth = birthDay
            };

            File.AppendAllText(path, client.ToString(), Encoding.UTF8);
            Console.WriteLine("Данные успешно добавлены!");
            Thread.Sleep(3000);
            Console.Clear();
        }

        /// <summary>
        /// Обновление данных клиента.
        /// </summary>
        /// <param name="path"> Путь к файлу. </param>
        /// <param name="stringNumber"> Номер строки. </param>
        /// <param name="action"> Действие для изменения. </param>
        public static void UpdateDataClient(string path, int stringNumber, string action)
        {
            var readAllFile = File.ReadAllLines(path);
            var certainString = File.ReadLines(path);

            var changeData = certainString.Skip(stringNumber - 1).First().Split(' ');

            var arrayCount = (action == "Фамилия") ? 3
                                                  : (action == "Имя") ? 5
                                                                      : (action == "Отчество") ? 7
                                                                                               : 9;

            var newData = Other.Validator.GetStringOnConsole("Пожалуйста, введите новые данные: ");

            changeData[arrayCount] = newData;

            File.WriteAllText(path, string.Join(" ", changeData), Encoding.UTF8);
            Console.WriteLine("Данные успешно обновлены!");
            Thread.Sleep(3000);
            Console.Clear();
        }

        /// <summary>
        /// Удаление клиента.
        /// </summary>
        /// <param name="path"> Путь к файлу. </param>
        /// <param name="stringNumber"> Номер строки. </param>
        public static void DeleteDataClient(string path, int stringNumber)
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
            Thread.Sleep(0);
            Console.WriteLine("Клиент под номером " + stringNumber.ToString() + " удален.");
            Thread.Sleep(3000);
            Console.Clear();
        }
    }
}
