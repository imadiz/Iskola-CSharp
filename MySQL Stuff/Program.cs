﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace MySQL_stuff
{
    internal class Program
    {
        public class Product
        {
            public string Name { get; set; }
            public string Type { get; set; }
            public int Quantity { get; set; }
            public double Price { get; set; }
            public Product(string name, string type, int quantity, double price)
            {
                this.Name = name;
                this.Type = type;
                this.Quantity = quantity;
                this.Price = price;
            }
        }
        static MySqlConnection conn;
        static MySqlConnectionStringBuilder ConnBuilder = new MySqlConnectionStringBuilder()
        {
            Server = "127.0.0.1",
            Database = "classicmodels",
            Password = "password",
            UserID = "root",
        };
        static string TableName;
        static Stopwatch timer = new Stopwatch();

        static List<Product> AllProducts = new List<Product>();

        static void Main(string[] args)
        {
            Init_Connection();
            InputTable();

            ReadProducts();

            IEnumerable<Product> Tipusonkent_Legdragabb = AllProducts.GroupBy(x => x.Type, (key, x) => x.OrderByDescending(y => y.Price).First());

            Console.WriteLine("Típusonként legdrágább termékek:");
            foreach (Product item in Tipusonkent_Legdragabb)
            {
                Console.WriteLine($"{item.Name} | {item.Price}$ | {item.Type} | {item.Quantity}");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        static void InputTable()
        {
            Console.Write("Kérek egy táblanevet a classicmodels adatbázisból: ");
            TableName = Console.ReadLine();
        }
        static void Init_Connection()
        {
            Console.WriteLine("Kapcsolódás megkezdése...");
            conn = new MySqlConnection(ConnBuilder.ConnectionString);
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                WriteError(ex.ToString());
            }
        }
        static void ReadProducts()
        {
            MySqlCommand cmd = new MySqlCommand($"SELECT productName, productLine, quantityInStock, buyPrice FROM {TableName}", conn);
            MySqlDataReader reader;

            try
            {
                reader = cmd.ExecuteReader();
                Console.WriteLine($"Lekérdezés a(z) classicmodels.{TableName} táblából...");

                while (reader.Read())
                {
                    AllProducts.Add(new Product(reader[0].ToString(), reader[1].ToString(), reader.GetInt32(2), reader.GetDouble(3)));
                }
                reader.Close();
            }
            catch (MySqlException myex)
            {
                if (myex.Message.Contains($"Table 'classicmodels.{TableName}' doesn't exist"))
                {
                    WriteError("Nincs ilyen tábla az adatbázisban!");
                    InputTable();
                    ReadProducts();
                }
            }
        }
        static void WriteError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
