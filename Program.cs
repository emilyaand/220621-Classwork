using System;
using System.Collections.Generic;
using System.Linq;

namespace Classwork
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            List<User> users = new List<User>();
            users.Add(new User { Username = "Superadmin", Password = "sdfghj"});
            Menu:
            string answer = ShowMenuAndGetAnswer();

            switch(answer)
            {
                case "1":
                    AddUser(users);
                    goto Menu;
                    
                case "2":
                    Login(users);
                    break;
            }
        }
        static string ShowMenuAndGetAnswer()
        {
            Console.WriteLine("1. Register ");
            Console.WriteLine("2. Login ");
            return Console.ReadLine();
        }
        static void AddUser(List<User> users)
        {
            Console.WriteLine("Insert ur Name: ");
            string Name = Console.ReadLine();

            Console.WriteLine("Insert ur Surname: ");
            string Surname = Console.ReadLine();

            username:
            Console.WriteLine("Insert ur Username: ");
            string Username = Console.ReadLine();

            Console.WriteLine("Insert ur Password: ");
            string Password = Console.ReadLine();

            bool exist = users.Any(u => u.Username == Username);
            if (exist)
            {
                Console.WriteLine("Such user already exists");
                goto username;
            }


            User user = new User {Name = Name, Surname = Surname, Password = Password, Username = Username };
            users.Add(user);
        }

        static void Login(List<User> users)
        {
            Console.WriteLine("Insert ur Username: ");
            string Username = Console.ReadLine();

            Console.WriteLine("Insert ur Password: ");
            string Password = Console.ReadLine();

            User user = users.Find(u => u.Username == Username && u.Password == Password);
            if (user == null)
            {
                Console.WriteLine("The wromg Username or Password. Please try again");
                Login(users);
            }
            Console.WriteLine("Welcome!");
        }
    }
}
