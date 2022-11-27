using System;
using JewerlyWork.Functions.Actions;
using JewerlyWork.Functions.Other;
using Microsoft.Win32;

namespace JewerlyWork
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

            RegAuthUser();
        }

        /// <summary>
        /// Авторизация / регистрация в системе.
        /// </summary>
        /// <param name="path"> Путь к файлу. </param>
        private static void RegAuthUser()
        {
            var login = "";
            var password = "";
        START:

            Console.WriteLine("Добро пожаловать в магазин ювелирных изделий. \n" +
                              "Пожалуйста, зарегистрируйтесь или авторизируйтесь в нашей сестеме! \n" +
                              "1) Регистрация;\n" +
                              "2) Авторизация.");
            int choise = Validator.GetPrintNumberOnConsole("Итак, Ваш выбор: ");
            if (choise == 1 || choise == 2)
            {
                switch (choise)
                {
                    case 1:
                        login = Validator.GetStringOnConsole("Пожалуйста, введите логин: ");
                        password = Validator.GetStringOnConsole("Пожалуйста, введите пароль: ");
                        UserAction.AddUser(PathData.pathToUsers, login, password, "Client");
                        Console.WriteLine("Регистрация прошла успешно!");
                        goto START;
                    case 2:
                        login = Validator.GetStringOnConsole("Пожалуйста, введите логин: ");
                        password = Validator.GetStringOnConsole("Пожалуйста, введите пароль: ");
                        var readAllFile = File.ReadAllLines(PathData.pathToUsers).ToList();

                        foreach (var item in readAllFile)
                        {
                            var dataArray = item.Split(' ');

                            if ((login == dataArray[3]) &&
                                (password == dataArray[5]) &&
                                (dataArray[7] == "Client"))
                            {
                                Functions.Interfaces.ClientInterface.ClientInterfaces(login);
                            }
                            else if ((login == dataArray[3]) &&
                                (password == dataArray[5]) &&
                                (dataArray[7] == "Admin"))
                            {
                                Functions.Interfaces.AdministratorAction.AdminInterface();
                            }
                        }
                        break;
                }
            }
            else
            {
                Console.WriteLine("Была введена неверная команда. Попробуйте еще раз!");
                goto START;
            }
        }
    }
}