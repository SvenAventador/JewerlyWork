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
        /// Интерфейс клиента.
        /// </summary>
        /// <param name="login"> Логин клиента. </param>
        public static void ClientInterfaces(string login)
        {
            Console.Clear();
            Console.WriteLine($"Добро пожаловать, {login}, в наш магазин ювелирных изделий. \n" +
                              $"Перед тем, как перейти к покупкам, введите, пожалуйста, свои личные данные в систему.");
            Functions.Actions.ClientAction.AddClient(Other.PathData.pathToClient);
            Console.Clear();

            START:
            Console.WriteLine("Дорогой клиент. Что Вы хотите сделать?\n" +
                              "1) Просмотреть товары;\n" +
                              "2) Приобрести товары;\n" +
                              "3) Выход.\n");
            int choiseAction = Other.Validator.GetPrintNumberOnConsole("Итак, Ваш выбор: ");

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
                        Console.WriteLine("Введена неизвестная команда. Пожалуйста, попробуйте еще раз!");
                        goto START;
                    }

                    #endregion

                    break;
                case 2:
                    Actions.ProductSaleAction.AddOrder(Other.PathData.pathToProductSale);
                    break;
            }

        }
    }
}
