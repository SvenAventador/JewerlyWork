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
    /// Взаимодействие с пользователем.
    /// </summary>
    public class UserAction
    {
        /// <summary>
        /// Добавление администратора.
        /// </summary>
        /// <param name="path"> Файл. </param>
        /// <param name="login"> Логин. </param>
        /// <param name="password"> Пароль. </param>
        /// <param name="role"> Роль. </param>

        public static void AddUser(string path, string login, string password, string role)
        {
            var readFile = File.ReadAllLines(path);

            var user = new Classes.User()
            {
                Id = readFile.Length == 0 ? 1
                                          : int.Parse(File.ReadAllLines(path)
                                                            .Last()
                                                            .Split(' ')[1]) + 1,
                Login = login,
                Password = password,
                Role = role
            };

            File.AppendAllText(path, user.ToString() + Environment.NewLine, Encoding.UTF8);
            Console.WriteLine("Успешно создана новая учетная запись!");
            Thread.Sleep(3000);
            Console.Clear();
        }

        /// <summary>
        /// Изменение данных пользователя.
        /// </summary>
        /// <param name="path"> Файл. </param>
        /// <param name="stringNumber"> Идентификатор. </param>
        /// <param name="action"> Что нужно изменить (логин/ пароль). </param>
        public static void UpdateDataUser(string path, int stringNumber, string action)
        {
            var readAllFile = File.ReadAllLines(path);
            var certainString = readAllFile.Skip(stringNumber - 1).First().Split(' ');

            var newData = Other.Validator.GetStringOnConsole("Пожалуйста, введите новые данные: ");

            certainString[action.ToLower() == "логин" ? 3
                                                      : 5] = newData;

            readAllFile[stringNumber - 1] = String.Join(" ", certainString);

            File.WriteAllLines(path, readAllFile);
            Console.WriteLine("Данные успешно обновлены!"); 
            Thread.Sleep(3000);
            Console.Clear();
        }

        /// <summary>
        /// Удаление администратора.
        /// </summary>
        /// <param name="path"> Путь к файлу. </param>
        /// <param name="stringNumber"> Номер строки. </param>
        public static void DeleteDataUser(string path, int stringNumber)
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

                File.AppendAllText(path, newLine.ToString() + Environment.NewLine);
            }
            Console.WriteLine("Пользователь под номером " + stringNumber.ToString() + " удален.");
            Thread.Sleep(0);
            Thread.Sleep(3000);
            Console.Clear();
        }
    }
}
