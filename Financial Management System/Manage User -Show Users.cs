using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Financial_Management_System
{
    partial class Manage_Users
    {
        public static List<User> LoadUsers(string filePath)
        {


            if (!File.Exists(filePath))
                return new List<User>(); // اگه فایل وجود نداشت، یه لیست خالی برگردون

            string json = File.ReadAllText(filePath); // محتوای فایل رو بخون
            return JsonSerializer.Deserialize<List<User>>(json); // تبدیل به لیست User
        }

        private void ContorolShowUsers(string filePath)
        {
            List<User> users = LoadUsers(filePath); // بازیابی لیست کاربران

            if (users.Count == 0)
            {
                Console.WriteLine("There is no user");
                return;
            }


            Console.WriteLine("users list:");

            for (int i = 0; i < users.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {users[i].Username}");
            }
        }

        public void ShowUsers()
        {
            ContorolShowUsers(jsonfilePath);
        }



    }
}
