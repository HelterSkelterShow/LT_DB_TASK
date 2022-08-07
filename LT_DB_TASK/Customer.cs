using System;
using System.Data;
using System.Data.SqlClient;

namespace LT_DB_TASK
{
    internal class Customer:ICrud
    {
        private const string connection_string = "Server=localhost\\sqlexpress;Database=BookStoreDB;Trusted_Connection=True";

        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public void Create()
        {
            SqlConnection connection = new SqlConnection(connection_string);
            connection.Open();

            Customer customer = new Customer();
            Console.Write("Введите имя клиента или Exit: ");
            customer.FirstName = Console.ReadLine();

            if (FirstName == "Exit")
            {
                return;
            }

            Console.WriteLine();
            Console.Write("Введите фамилию клиента или Exit: ");
            customer.LastName = Console.ReadLine();

            if (LastName == "Exit")
            {
                return;
            }

            //Добавить считывание ID
            string SQLquery = $"INSERT INTO Customers VALUES (NEWID(),'{customer.FirstName}', '{customer.LastName}')";
            using(SqlCommand command = new SqlCommand(SQLquery, connection))
            {
                command.ExecuteNonQuery();
            }
        }

        public void Read()
        {
            SqlConnection connection = new SqlConnection(connection_string);
            connection.Open();

            string SQLquery = $"SELECT *FROM Customers";
            using (SqlCommand command = new SqlCommand(SQLquery, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["ID"]}: {reader["FirstName"]} {reader["LastName"]}");
                    }
                }
            }
            Console.WriteLine("Нажмите любую кнопку");
            Console.ReadKey();
        }

        public void Update()
        {
            SqlConnection connection = new SqlConnection(connection_string);
            connection.Open();

            Guid ID;
            while (true)
            {
                Console.WriteLine("Введите корректный ID для изменения или Exit");
                if (Guid.TryParse(Console.ReadLine(), out ID))
                {
                    break;
                }
            }

            Console.WriteLine("Введите новую фамилию");
           string newLastName = Console.ReadLine();
           string SQLquery = $"UPDATE Customers SET LastName = '{newLastName}' WHERE ID = '{ID}'";

            using (SqlCommand command = new SqlCommand(SQLquery, connection))
            {
                command.ExecuteNonQuery();
            }
        }

        public void Delete()
        {
            SqlConnection connection = new SqlConnection(connection_string);
            connection.Open();

            Guid ID;
            while (true)
            {
                Console.WriteLine("Введите ID для удаления");
                if(Guid.TryParse(Console.ReadLine(), out ID))
                {
                    break;
                }
            }
            string SQLquery = $@"DELETE FROM Customers WHERE ID = '{ID}'";

            using (SqlCommand command = new SqlCommand(SQLquery, connection))
            {
                command.ExecuteNonQuery();
            }
        }
    }
}
