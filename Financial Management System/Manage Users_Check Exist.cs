using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Channels;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Financial_Management_System
{

    partial class Manage_Users
    {
        public bool enterPanel=false;
        


        public void CheckAdmin(string username, string email)
        {
            // اگه فایل وجود نداره، چیزی بررسی نکن
            if (!File.Exists(jsonfilePath))
            {
                Console.WriteLine("datebade not found");
                return;
            }

            // خوندن محتوای فایل و تبدیل به لیست یوزر
            string jsonData = File.ReadAllText(jsonfilePath);
            List<User> users = JsonConvert.DeserializeObject<List<User>>(jsonData) ?? new List<User>();



            // بررسی وجود یوزر با نام admin و ایمیل مشخص
            foreach (var user in users)
            {
                if (user.Username == username && user.Email == email)
                {

                    enterPanel = true;
                    EnteranlUser=username;

                    return;
                }
            }

            Console.WriteLine("user not found");
            enterPanel=false;

        }
    }
}
