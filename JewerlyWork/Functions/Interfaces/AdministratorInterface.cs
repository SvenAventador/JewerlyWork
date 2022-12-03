using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using JewerlyWork.Functions.Other;
using JewerlyWork.Functions.Actions;

namespace JewerlyWork.Functions.Interfaces
{
    /// <summary>
    /// Интерфейс администратора.
    /// </summary>
    public static class AdministratorAction
    {
        /// <summary>
        /// Определение действия над объектов (добавление / изменение / удаление изделия и т.п.)
        /// </summary>
        private static int _choice;

        /// <summary>
        /// Интерфейс администратора.
        /// </summary>
        public static void AdminInterface()
        {
            Console.Clear();
            START:
            Console.WriteLine("Администратор системы. \n" +
                              "Выберите одну из опций: \n" +
                              "1) Просмотреть данные;\n" +
                              "2) Добавить запись;\n" +
                              "3) Изменить запись;\n" +
                              "4) Удалить запись.\n");
            int choiceAction = Validator.GetPrintNumberOnConsole("Итак, Ваш выбор: ");
            if ((choiceAction == 1) ||
                (choiceAction == 2) ||
                (choiceAction == 3) ||
                (choiceAction == 4))
            {
                _choice = choiceAction;
                switch (choiceAction)
                {
                    case 1:
                        ImplementationAction();
                        goto START;
                    case 2:
                        ImplementationAction();
                        goto START;
                    case 3:
                        ImplementationAction();
                        goto START;
                    case 4:
                        ImplementationAction();
                        goto START;
                }
            }
            else
            {
                Console.WriteLine("Введена неизвестная команда. Пожалуйста, попробуйте еще раз!");
                goto START;
            }
        }

        /// <summary>
        /// Вспомогательный метод для выборки определенного действия.
        /// </summary>
        private static void ImplementationAction()
        {
            Console.WriteLine("Выберите объект работы: \n" +
                              "1) Изделие\n" +
                              "2) Материал\n" +
                              "3) Тип изделия\n" +
                              "4) Клиент\n" +
                              "5) Заказ\n" +
                              "6) Пользователь\n");
            int choice2 = Validator.GetPrintNumberOnConsole("Итак, Ваш выбор: ");
            switch (choice2)
            {
                case 1:
                    #region CRUD над изделиями.
                    if (_choice == 1)
                    {
                        using (var sR = new StreamReader(Other.PathData.pathToProduct))
                        {
                            Console.WriteLine(sR.ReadToEnd());
                        }
                        Thread.Sleep(5000);
                        Console.Clear();
                    }
                    if (_choice == 2)
                    {
                        Actions.ProductAction.AddProduct(PathData.pathToProduct);
                    }
                    if (_choice == 3)
                    {
                        START:
                        int stringNumber = Other.Validator.GetPrintNumberOnConsole("Введите номер строчки, которую хотите изменить: ");

                        if ((stringNumber < 1) ||
                            (stringNumber > PathData.pathToProduct.Length))
                        {
                            Console.WriteLine("Данная строчка не найдена. Попробуйте еще раз!");
                            goto START;
                        }

                        START1:
                        var action = Validator.GetStringOnConsole("Введите то, что Вы хотите изменить (Название, Тип, Материал, Вес, Цена): ");
                        if ((action != "Название") ||
                            (action != "Тип") ||
                            (action != "Материал") ||
                            (action != "Вес") ||
                            (action != "Цена"))
                        {
                            Console.WriteLine("Введена неверная команда. Попробуйте еще раз!");
                            goto START1;
                        }

                        Actions.ProductAction.UpdateDataProduct(PathData.pathToProduct, stringNumber, action);
                    }
                    if (_choice == 4)
                    {
                        START:
                        int stringNumber = Other.Validator.GetPrintNumberOnConsole("Введите номер строчки, которую хотите изменить: ");

                        if ((stringNumber < 1) ||
                            (stringNumber > PathData.pathToProduct.Length))
                        {
                            Console.WriteLine("Данная строчка не найдена. Попробуйте еще раз!");
                            goto START;
                        }

                        Actions.ProductAction.DeleteDataProduct(PathData.pathToProduct, stringNumber);
                    }
                    #endregion
                    break;
                case 2:
                    #region CRUD над материалами.
                    if (_choice == 1)
                    {
                        using (var sR = new StreamReader(Other.PathData.pathToMaterialProduct))
                        {
                            Console.WriteLine(sR.ReadToEnd());
                        }
                        Thread.Sleep(5000);
                        Console.Clear();
                    }
                    if (_choice == 2)
                    {
                        Actions.MaterialProductAction.AddMaterial(PathData.pathToMaterialProduct);
                    }
                    if (_choice == 3)
                    {
                        START:
                        var stringNumber = Other.Validator.GetPrintNumberOnConsole("Введите номер строчки, которую хотите изменить: ");

                        if ((stringNumber < 1) ||
                            (stringNumber > PathData.pathToMaterialProduct.Length))
                        {
                            Console.WriteLine("Данная строчка не найдена. Попробуйте еще раз!");
                            goto START;
                        }

                        START1:
                        var action = Other.Validator.GetStringOnConsole("Введите то, что хотите изменить: ");

                        if (action != "Название" ||
                            action != "Цена")
                        {
                            Console.WriteLine("Введена неправильная команда. Попробуйте еще раз!");
                            goto START1;
                        }
                        Actions.MaterialProductAction.UpdateDataMaterial(PathData.pathToMaterialProduct, stringNumber, action);
                    }
                    if (_choice == 4)
                    {
                        START:
                        var stringNumber = Other.Validator.GetPrintNumberOnConsole("Введите номер строчки, которую хотите изменить: ");

                        if ((stringNumber < 1) ||
                            (stringNumber > PathData.pathToMaterialProduct.Length))
                        {
                            Console.WriteLine("Данная строчка не найдена. Попробуйте еще раз!");
                            goto START;
                        }

                        Actions.MaterialProductAction.DeleteDataMaterial(PathData.pathToMaterialProduct, stringNumber);
                    }
                    #endregion
                    break;
                case 3:
                    #region CRUD над типами изделия.
                    if (_choice == 1)
                    {
                        using (var sR = new StreamReader(Other.PathData.pathToProductType))
                        {
                            Console.WriteLine(sR.ReadToEnd());
                        }
                        Thread.Sleep(5000);
                        Console.Clear();
                    }
                    if (_choice == 2)
                    {
                        Actions.ProductTypeAction.AddProductType(PathData.pathToProductType);
                    }
                    if (_choice == 3)
                    {
                        START:
                        int stringNumber = Other.Validator.GetPrintNumberOnConsole("Введите номер строчки, которую хотите изменить: ");

                        if ((stringNumber < 1) ||
                            (stringNumber > PathData.pathToProductType.Length))
                        {
                            Console.WriteLine("Данная строчка не найдена. Попробуйте еще раз!");
                            goto START;
                        }

                        Actions.ProductTypeAction.UpdateProductType(PathData.pathToProductType, stringNumber);
                    }
                    if (_choice == 4)
                    {
                        START:
                        int stringNumber = Other.Validator.GetPrintNumberOnConsole("Введите номер строчки, которую хотите изменить: ");

                        if ((stringNumber < 1) ||
                            (stringNumber > PathData.pathToProductType.Length))
                        {
                            Console.WriteLine("Данная строчка не найдена. Попробуйте еще раз!");
                            goto START;
                        }

                        Actions.ProductTypeAction.DeleteProductType(PathData.pathToProductType, stringNumber);
                    }
                    #endregion
                    break;
                case 4:
                    #region CRUD над клиентами.
                    if (_choice == 1)
                    {
                        using (var sR = new StreamReader(Other.PathData.pathToClient))
                        {
                            Console.WriteLine(sR.ReadToEnd());
                        }
                        Thread.Sleep(5000);
                        Console.Clear();
                    }
                    if (_choice == 2)
                    {
                        Console.WriteLine("Вы не можете добавить клиента в нашу систему!");
                        Thread.Sleep(3000);
                        Console.Clear();
                    }
                    if (_choice == 3)
                    {
                        START:
                        int stringNumber = Other.Validator.GetPrintNumberOnConsole("Введите номер строчки, которую хотите изменить: ");

                        if ((stringNumber < 1) ||
                            (stringNumber > PathData.pathToClient.Length))
                        {
                            Console.WriteLine("Данная строчка не найдена. Попробуйте еще раз!");
                            goto START;
                        }
                        START1:
                        var action = Validator.GetStringOnConsole("Введите то, что Вы хотите изменить (Фамилия, Имя, Отчество, Дата рождения): ");

                        if ((action != "Фамилия") ||
                            (action != "Имя") ||
                            (action != "Отчество") ||
                            (action != "Дата рождения"))
                        {
                            Console.WriteLine("Введена неверная команда. Попробуйте еще раз!");
                            goto START1;
                        }
                        Actions.ClientAction.UpdateDataClient(PathData.pathToClient, stringNumber, action);
                    }
                    if (_choice == 4)
                    {
                        START:
                        int stringNumber = Other.Validator.GetPrintNumberOnConsole("Введите номер строчки, которую хотите изменить: ");

                        if ((stringNumber < 1) ||
                            (stringNumber > PathData.pathToClient.Length))
                        {
                            Console.WriteLine("Данная строчка не найдена. Попробуйте еще раз!");
                            goto START;
                        }
                        Actions.ClientAction.DeleteDataClient(PathData.pathToClient, stringNumber);
                    }
                    #endregion
                    break;
                case 5:
                    #region CRUD над заказами.
                    if (_choice == 1)
                    {
                        using (var sR = new StreamReader(Other.PathData.pathToProductSale))
                        {
                            Console.WriteLine(sR.ReadToEnd());
                        }
                        Thread.Sleep(5000);
                        Console.Clear();
                    }
                    if (_choice == 2)
                    {
                        Console.WriteLine("Вы не можете добавить заказ в нашу систему!");
                        Thread.Sleep(3000);
                        Console.Clear();
                    }
                    if (_choice == 3)
                    {
                        Console.WriteLine("Вы не можете изменить заказ в нашей систему!");
                        Thread.Sleep(3000);
                        Console.Clear();
                    }
                    if (_choice == 4)
                    {
                        START:
                        int stringNumber = Other.Validator.GetPrintNumberOnConsole("Введите номер строчки, которую хотите изменить: ");

                        if ((stringNumber < 1) ||
                            (stringNumber > PathData.pathToProductSale.Length))
                        {
                            Console.WriteLine("Данная строчка не найдена. Попробуйте еще раз!");
                            goto START;
                        }

                        Actions.ProductSaleAction.DeleteDataOrder(PathData.pathToProductSale, stringNumber);
                    }
                    #endregion
                    break;
                case 6:
                    #region CRUD над пользователями.
                    if (_choice == 1)
                    {
                        using (var sR = new StreamReader(Other.PathData.pathToUsers))
                        {
                            Console.WriteLine(sR.ReadToEnd());
                        }
                        Thread.Sleep(5000);
                        Console.Clear();
                    }
                    if (_choice == 2)
                    {
                        var login = Validator.GetStringOnConsole("Пожалуйста, введите логин: ");
                        var password = Validator.GetStringOnConsole("Пожалуйста, введите пароль: ");

                        UserAction.AddUser(PathData.pathToUsers, login, password, "Client");
                        START:
                        var answer = Validator.GetStringOnConsole("Хотите просмотреть всех пользователей? Ваш ответ: ");
                        if (answer.ToLower() == "да")
                        {
                            using (var sR = new StreamReader(PathData.pathToUsers))
                            {
                                Console.WriteLine(sR.ReadToEnd());
                            }
                            Thread.Sleep(3000);
                            Console.Clear();
                        }
                        else if (answer.ToLower() == "нет")
                        {
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("Введена неверная команда. Попробуйте еще раз!");
                            goto START;
                        }
                    }

                    if (_choice == 3)
                    {

                        START:
                        var stringNumber = Validator.GetPrintNumberOnConsole("Введите номер пользователя, данные которого Вы хотите изменить: ");

                        if (stringNumber < 1 || stringNumber > PathData.pathToUsers.Length)
                        {
                            Console.WriteLine("Данный пользователь не найден. Введите данные еще раз!");
                            goto START;
                        }
                        START1:
                        Console.Write("Какие данные (Логин / Пароль) Вы хотите изменить? ");
                        var action = Validator.GetStringOnConsole("Ваш ответ: ");
                        Console.WriteLine(action.ToLower());
                        if ((action.ToLower() != "логин".ToLower()) &&
                            (action.ToLower() != "пароль".ToLower()))
                        {
                            Console.WriteLine("Введена неверная команда. Попробуйте еще раз!");
                            goto START1;
                        }    

                        UserAction.UpdateDataUser(PathData.pathToUsers, stringNumber, action);

                        START2:
                        var answer = Validator.GetStringOnConsole("Хотите просмотреть всех пользователей? Ваш ответ: ");
                        if (answer.ToLower() == "да")
                        {
                            using (var sR = new StreamReader(PathData.pathToUsers))
                            {
                                Console.WriteLine(sR.ReadToEnd());
                            }
                            Thread.Sleep(3000);
                            Console.Clear();
                        }
                        else if (answer.ToLower() == "нет")
                        {
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("Введена неверная команда. Попробуйте еще раз!");
                            goto START2;
                        }
                    }

                    if (_choice == 4)
                    {
                        START:
                        var stringNumber = Validator.GetPrintNumberOnConsole("Введите номер пользователя, данные которого Вы хотите изменить: ");

                        if (stringNumber < 1 || stringNumber > PathData.pathToUsers.Length)
                        {
                            Console.WriteLine("Данный пользователь не найден. Введите данные еще раз!");
                            goto START;
                        }
                        UserAction.DeleteDataUser(PathData.pathToUsers, stringNumber);

                        START1:
                        var answer = Validator.GetStringOnConsole("Хотите просмотреть всех пользователей? Ваш ответ: ");
                        if (answer.ToLower() == "да")
                        {
                            using (var sR = new StreamReader(PathData.pathToUsers))
                            {
                                Console.WriteLine(sR.ReadToEnd());
                            }
                            Thread.Sleep(3000);
                            Console.Clear();
                        }
                        else if (answer.ToLower() == "нет")
                        {
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("Введена неверная команда. Попробуйте еще раз!");
                            goto START1;
                        }
                    }
                    #endregion
                    break;
            }
        }
    }
}

