using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Financial_Management_System
{
    partial class Manage_Users
    {
        private string Username;
        private string Email;
        string InputConfirmation;
        string EnteranlUser;
        bool ContorolEnterUser = true;

        private string jsonfilePath = @"C:\Users\amir\source\repos\Financial Management System\Financial Management System\obj\Debug\net8.0\user.json";

        public class User
        {
            public string Username { get; set; }
            public string Email { get; set; }
        }



        public void AddUser(User newUser)
        {
            List<User> users = new List<User>();

            // اگر فایل وجود داشته باشه، اطلاعات قبلی رو بخون
            if (File.Exists(jsonfilePath))
            {
                string jsonData = File.ReadAllText(jsonfilePath);
                users = JsonConvert.DeserializeObject<List<User>>(jsonData) ?? new List<User>();
            }

            // اضافه کردن یوزر جدید
            users.Add(newUser);

            // ذخیره لیست جدید در فایل
            string updatedJson = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText(jsonfilePath, updatedJson);

            Console.WriteLine("User added successfully!");
        }

        public List<User> GetAllUsers()
        {
            if (!File.Exists(jsonfilePath))
                return new List<User>();

            string jsonData = File.ReadAllText(jsonfilePath);
            return JsonConvert.DeserializeObject<List<User>>(jsonData) ?? new List<User>();
        }





        public void enter_user()
        {
            while (ContorolEnterUser)
            {
                Console.WriteLine();

                Console.Write("enter new username:");
                Username = Console.ReadLine();


                Console.Write("enter new email:");
                Email = Console.ReadLine();


                Console.WriteLine($"USERNAME:{Username}  EMAIL:{Email}");

                Console.Write("THIS IS KOEY 1=YES 2=NO:");
                InputConfirmation = Console.ReadLine();

                if (int.TryParse(InputConfirmation, out int num) && Convert.ToInt32(InputConfirmation) >= 1 && Convert.ToInt32(InputConfirmation) <= 2 && InputConfirmation.Length > 0)
                {
                    if (num == 1)
                    {
                        Manage_Users manager = new Manage_Users();

                        User user1 = new User
                        {
                            Username = Username,
                            Email = Email
                        };

                        manager.AddUser(user1);

                        var users = manager.GetAllUsers();
                        foreach (var user in users)
                        {
                            Console.WriteLine($"Username: {user.Username}, Email: {user.Email}");
                        }

                        ContorolEnterUser = false;
                    }
                    if (num == 2)
                    {
                        Console.Clear();
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("input is invlide OR input in out of range");
                }
            }
            ContorolEnterUser = true;

        }
    }
}
