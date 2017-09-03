using System;
using System.Collections.Generic;
using DbConnection;

namespace crud
{
    class Program
    {
        static void Main(string[] args)
        {   
            Read();
            System.Console.WriteLine("Do you want to insert data?[Y/N] ");
            string option = Console.ReadLine().ToLower();
            while(option == "y"){
                System.Console.WriteLine("Enter First Name: ");
                string firstName = Console.ReadLine();
                System.Console.WriteLine("Enter Last Name: ");
                string lastName = Console.ReadLine();
                System.Console.WriteLine("Enter Favorite Number: ");
                string favNum = Console.ReadLine();
                string queryString = $"INSERT INTO Users (FirstName, LastName, FavoriteNumber) VALUES ({firstName}, {lastName}, {favNum})";
                System.Console.WriteLine(queryString);
                Create(queryString);
                System.Console.WriteLine("Do you want to insert data?[Y/N] ");
                option = Console.ReadLine().ToLower();
            }
        }

        private static void Read(){
            string queryString = "SELECT FirstName, LastName, FavoriteNumber FROM Users";
            List<Dictionary<string,object>> dbInfo = DbConnector.Query(queryString);
            foreach (var dict in dbInfo)
            {
                foreach (KeyValuePair<string,object> entry in dict)
                {
                    System.Console.WriteLine(entry.Key + "-" + entry.Value);
                }
                System.Console.WriteLine("----------------------");
            }
        }

        private static void Create(string queryString){
            DbConnector.Execute(queryString);
            Read();
        }
    }
}
