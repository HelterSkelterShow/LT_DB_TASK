using System;

namespace LT_DB_TASK
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                switch (Menu.GetMainMenu())
                {
                    case 1:
                        Customer customer = new Customer();
                        switch (Menu.DoSubmenu())
                        {
                            case 1:
                                customer.Create();
                                break;
                            case 2:
                                customer.Read();
                                break;
                            case 3:
                                customer.Update();
                                break;
                            case 4:
                                customer.Delete();
                                break;
                            case 5:
                                break;
                        }
                        break;

                    case 2:
                        Books book = new Books();
                        switch (Menu.DoSubmenu())
                        {
                            case 1:
                                book.Create();
                                break;
                            case 2:
                                book.Read();
                                break;
                            case 3:
                                book.Update();
                                break;
                            case 4:
                                book.Delete();
                                break;
                            case 5:
                                break;
                        }
                        break;
                    case 3:
                        return;

                }
                Console.Clear();

            }
        }
    }
}
