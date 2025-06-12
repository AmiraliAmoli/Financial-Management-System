using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;

namespace Financial_Management_System
{
    partial class Manage_Users
    {
        private const string UserFilePath = @"C:\Users\amir\source\repos\Financial Management System\Financial Management System\obj\Debug\net8.0\user.json";




        public void ShowUsers()
        {
            if (!File.Exists(UserFilePath))
            {
                Console.WriteLine("users datebase not found");
                return;
            }

            string json = File.ReadAllText(UserFilePath);
            List<User> users = JsonConvert.DeserializeObject<List<User>>(json) ?? new List<User>();

            if (users.Count == 0)
            {
                Console.WriteLine("No user found");
                return;
            }

            Console.WriteLine("users list:");
            foreach (var user in users)
            {
                Console.WriteLine($"- username:{user.Username}  email:{user.Email}");
            }

            while (true)
            {
                Console.Write("enter 1 to back menu:");
                string Backmenu = Console.ReadLine();
                if (int.TryParse(Backmenu, out int back) && Convert.ToInt32(Backmenu) == 1)
                {
                    Console.Clear();
                    break;
                }
                else
                {
                    Console.WriteLine("your input in wrong!!");
                }
            }
        }






    }
}
