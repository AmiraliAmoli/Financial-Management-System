using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Channels;
using System.Threading.Tasks;
using Newtonsoft.Json;
using static Financial_Management_System.ObjectJson
;

namespace Financial_Management_System
{

    partial class Manage_Users
    {
        public bool enterPanel = false;


        private const string ManageUsersFilepath = @"C:\Users\amir\source\repos\Financial Management System\Financial Management System\obj\Debug\net8.0\user.json";

        public class User
        {
            public string Username { get; set; }
            public string Email { get; set; }
        }


        public void CheckAdmin(string username, string email)
        {
            List<User> transactions = new List<User>();
            // اگه فایل وجود نداره، چیزی بررسی نکن
            if (!File.Exists(ManageUsersFilepath))
            {
                Console.WriteLine("datebade not found");
                return;
            }

            // خوندن محتوای فایل و تبدیل به لیست یوزر
            string jsonData = File.ReadAllText(ManageUsersFilepath);
            List<User> users = JsonConvert.DeserializeObject<List<User>>(jsonData) ?? new List<User>();



            // بررسی وجود یوزر با نام admin و ایمیل مشخص
            foreach (var user in users)
            {
                if (user.Username == username && user.Email == email)
                {

                    enterPanel = true;
                    EnteranlUser = username;
                    return;
                }
            }

            Console.SetCursorPosition(0, 0);
            Console.WriteLine("user not found");
            
            enterPanel = false;

        }



    }
}
