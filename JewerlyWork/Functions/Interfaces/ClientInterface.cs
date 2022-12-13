using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewerlyWork.Functions.Interfaces
{
    /// <summary>
    /// Интерфейс клиента.
    /// </summary>
    public static class ClientInterface
    {
        /// <summary>
        /// Определение действия над объектов (добавление / изменение / удаление изделия и т.п.)
        /// </summary>
        private static int _choise;

        /// <summary>
        /// Имя.
        /// </summary>
        private static string _name;

        /// <summary>
        /// Фамилия.
        /// </summary>
        private static string _surname;

        /// <summary>
        /// Отчество.
        /// </summary>
        private static string _patronymic;

        /// <summary>
        /// Интерфейс клиента.
        /// </summary>
        /// <param name="login"> Логин клиента. </param>
        public static void ClientInterfaces(string login)
        {
            START1:
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine($"Добро пожаловать, {login}, в наш магазин ювелирных изделий. \n" +
                              $"Вы являетесь нашим постоянным покупателем?");
            var answer = Other.Validator.GetStringOnConsole("Итак, Ваш ответ: ");

            if (answer.ToLower() == "да")
            {
                var readClient = File.ReadAllLines(Other.PathData.pathToClient);
                _surname = Other.Validator.GetStringOnConsole("Пожалуйста, введите Вашу фамилию для проверки: ");
                _name = Other.Validator.GetStringOnConsole("Пожалуйста, введите Ваше имя для проверки: ");
                _patronymic = Other.Validator.GetStringOnConsole("Пожалуйста, введите Ваше отчество для проверки: ");
                var fioFlag = false;

                foreach (var item in readClient)
                {
                    var dataArray = item.Split(' ');

                    if (
                        ($"{_surname.ToLower()} {_name.ToLower()} {_patronymic.ToLower()}")
                        ==
                        ($"{dataArray[3].ToLower()} {dataArray[5].ToLower()} {dataArray[7].ToLower()}"))
                    {
                        Console.WriteLine($"Добро пожаловать, {_name} {_patronymic}!");
                        Thread.Sleep(3000);
                        Console.Clear();
                        fioFlag = true;
                        break;
                    }
                    else
                        fioFlag = false;
                }

                if (!(fioFlag))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Вы уверены, что являетесь нашим постоянным покупателем? Вас нет в нашей базе. Попробуйте ввести данные еще раз!");
                    Thread.Sleep(3000);
                    goto START1;
                }
            }

            else if (answer.ToLower() == "нет")
            {
                Functions.Actions.ClientAction.AddClient(Other.PathData.pathToClient);
                Console.Clear();
                goto START1;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Неизвестная команда. Попробуйте еще раз.");
                Thread.Sleep(3000);
                goto START1;
            }

            START:
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Дорогой клиент. Что Вы хотите сделать?\n" +
                              "1) Просмотреть товары;\n" +
                              "2) Приобрести товары;\n" +
                              "3) Выход.\n");
            var choiseAction = Other.Validator.GetPrintNumberOnConsole("Итак, Ваш выбор: ");

            if ((choiseAction == 1) ||
                (choiseAction == 2) ||
                (choiseAction == 3))
            {
                _choise = choiseAction;
                switch (choiseAction)
                {
                    case 1:
                        ImplementationAction();
                        goto START;
                    case 2:
                        ImplementationAction();
                        goto START;
                    case 3:
                        Console.Clear();
                        Program.RegAuthUser();
                        break;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Введена неизвестная команда. Пожалуйста, попробуйте еще раз!");
                goto START;
            }
        }

        /// <summary>
        /// Вспомогательный метод для выборки действия.
        /// </summary>
        private static void ImplementationAction()
        {
            switch (_choise)
            {
                case 1:
                    START:
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Clear();
                    Console.WriteLine("Выберите объект работы: \n" +
                          "1) Изделие;\n" +
                          "2) Материал;\n" +
                          "3) Тип изделия;\n" +
                          "4) Выход.\n");
                    int choiseAction = Other.Validator.GetPrintNumberOnConsole("Итак, Ваш выбор: ");
                    #region Выбор вывода данных.

                    if (choiseAction == 1)
                    {
                        using (var sR = new StreamReader(Other.PathData.pathToProduct))
                        {
                            Console.WriteLine(sR.ReadToEnd());
                        }
                        Thread.Sleep(3000);
                        goto START;
                    }

                    else if (choiseAction == 2)
                    {
                        using (var sR = new StreamReader(Other.PathData.pathToMaterialProduct))
                        {
                            Console.WriteLine(sR.ReadToEnd());
                        }
                        Thread.Sleep(3000);
                        goto START;
                    }

                    else if (choiseAction == 3)
                    {
                        using (var sR = new StreamReader(Other.PathData.pathToProductType))
                        {
                            Console.WriteLine(sR.ReadToEnd());
                        }
                        Thread.Sleep(3000);
                        goto START;
                    }

                    else if (choiseAction == 4)
                    {
                        Console.Clear();
                    }

                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Введена неизвестная команда. Пожалуйста, попробуйте еще раз!");
                        goto START;
                    }

                    #endregion

                    break;
                case 2:
                    Actions.ProductSaleAction.AddOrder(Other.PathData.pathToProductSale, _surname, _name, _patronymic);
                    break;
            }

        }
    }
}
