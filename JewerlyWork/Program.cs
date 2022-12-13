using System;
using JewerlyWork.Functions.Actions;
using JewerlyWork.Functions.Other;
using Microsoft.Win32;
using System.IO;
using System.Threading;
using System.Linq;

namespace JewerlyWork
{
    public static class Program
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
        public static void RegAuthUser()
        {
            var login = "";
            var password = "";
            START:
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            START1:
            Console.ForegroundColor = ConsoleColor.Black;

            Console.WriteLine("Добро пожаловать в магазин ювелирных изделий. \n" +
                              "Пожалуйста, зарегистрируйтесь или авторизируйтесь в нашей сестеме! \n" +
                              "1) Регистрация;\n" +
                              "2) Авторизация;\n" +
                              "3) Выход.");
            int choise = Validator.GetPrintNumberOnConsole("Итак, Ваш выбор: ");
            if ((choise == 1) ||
                (choise == 2) ||
                (choise == 3))
            {
                switch (choise)
                {
                    case 1:
                        #region Регистрация.
                        login = Validator.GetStringOnConsole("Пожалуйста, введите логин: ");
                        password = Validator.GetStringOnConsole("Пожалуйста, введите пароль: ");
                        UserAction.AddUser(PathData.pathToUsers, login, password, "Client");
                        Console.WriteLine("Регистрация прошла успешно!");
                        goto START;
                    #endregion
                    case 2:
                        #region Авторизация.
                        login = Validator.GetStringOnConsole("Пожалуйста, введите логин: ");
                        password = Validator.GetStringOnConsole("Пожалуйста, введите пароль: ");
                        var readAllFile = File.ReadAllLines(PathData.pathToUsers).ToList();

                        var isEntry = false;
                        foreach (var item in readAllFile)
                        {
                            var dataArray = item.Split(' ');

                            if ((login == dataArray[3]) &&
                                (password == dataArray[5]) &&
                                (dataArray[7] == "Admin"))
                            {
                                isEntry = true;
                                Functions.Interfaces.AdministratorAction.AdminInterface();
                                break;
                            }
                            else if ((login == dataArray[3]) &&
                                     (password == dataArray[5]) &&
                                     (dataArray[7] == "Client"))
                            {
                                isEntry = true;
                                Functions.Interfaces.ClientInterface.ClientInterfaces(login);
                                break;
                            }
                        }

                        if (!(isEntry))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Такой аккаунт не найден. Попробуйте еще раз!");
                            Thread.Sleep(2000);
                            Console.Clear();
                            goto START1;
                        }

                        break;
                    #endregion.
                    case 3:
                        #region Выход из приложения.
                        Console.WriteLine("До скорых встреч, мой дорогой друг", Console.ForegroundColor = ConsoleColor.Green);
                        Console.ForegroundColor = ConsoleColor.Black;
                        Thread.Sleep(1000);
                        Environment.Exit(0);
                        break;
                        #endregion
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Была введена неверная команда. Попробуйте еще раз!");
                Thread.Sleep(2000);
                Console.Clear();
                goto START;
            }
        }
    }
}