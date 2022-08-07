using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LT_DB_TASK
{
        static class Menu
        {
            private static string[] menuPoints = {"1. Информация о покупателях",
                                   "2. Информация о книгах",
                                   "3. Выход из программы"};

            public static int GetMainMenu()
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Меню \n");

                foreach (string point in menuPoints)
                {
                    Console.WriteLine(point + "\n");
                }

                int choice;

                while (true)
                {
                    Console.Write("Выберите номер пункта, которым вы хотели бы воспользоваться: ");
                    try
                    {
                        choice = int.Parse(Console.ReadLine());

                        if ((choice > menuPoints.Length) || (choice < 1))
                            throw new Exception();
                        break;
                    }
                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Введите корректный номер пункта меню!");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                }

                Console.Clear();
                return choice;
            }
        public static int DoSubmenu()
        {

            Console.WriteLine(
                "1. Добавить\n\n" +
                "2. Читать\n\n" +
                "3. Изменять\n\n" +
                "4. Удалять\n\n" +
                "5. Выйти\n\n");

            int menuItem;

            while (true)
            {
                Console.Write("Выберите пункт: ");
                if (int.TryParse(Console.ReadLine(), out menuItem) & (menuItem < 6) & (menuItem > 0))
                {
                    break;
                }
            }

            return menuItem;
        }



    }
}
