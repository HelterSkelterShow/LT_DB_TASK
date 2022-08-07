using System;
using System.Data;
using System.Data.SqlClient;

namespace LT_DB_TASK
{
    internal class Books : ICrud
    {
        private const string connection_string = "Server=localhost\\sqlexpress;Database=BookStoreDB;Trusted_Connection=True";

        public string BooksName { get; set; }

        public string Author { get; set; }

        public void Create()
        {
            SqlConnection connection = new SqlConnection(connection_string);
            connection.Open();

            Books book = new Books();
            Console.Write("Введите название книги: ");
            book.BooksName = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Введите автора книги: ");
            book.Author = Console.ReadLine();

            //Добавить считывание ID
            string SQLquery = $"INSERT INTO Books VALUES (NEWID(),'{book.BooksName}', '{book.Author}')";
            using (SqlCommand command = new SqlCommand(SQLquery, connection))
            {
                command.ExecuteNonQuery();
            }
        }

        public void Read()
        {
            SqlConnection connection = new SqlConnection(connection_string);
            connection.Open();

            string SQLquery = $"SELECT *FROM Books";
            using (SqlCommand command = new SqlCommand(SQLquery, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["ID"]}: {reader["NameOfBook"]} {reader["Author"]}");
                    }
                }
            }
            Console.WriteLine("Нажмите любую кнопку");
            Console.ReadKey();
        }

        public void Update()
        {

        }

        public void Delete()
        {
            SqlConnection connection = new SqlConnection(connection_string);
            connection.Open();

            Guid ID;
            while (true)
            {
                Console.WriteLine("Введите корректный ID для удаления");
                if (Guid.TryParse(Console.ReadLine(), out ID))
                {
                    break;
                }
            }
            string SQLquery = $"DELETE FROM Books WHERE ID = {ID}";
        }
    }
}
