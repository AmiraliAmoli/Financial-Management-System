using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using static Financial_Management_System.ObjectJson;


namespace Financial_Management_System
{
    partial class Manage_Users
    {
        private string username;
        public string Username
        {
            get { return username; }
            set { username = value; }
        }


        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        string InputConfirmation;
        string EnteranlUser;
        bool ContorolEnterUser = true;




        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            bool valid = Regex.IsMatch(email, pattern);
            return valid;
        }
        public static bool CheckUserInsert(string username, string email)
        {
            bool enter = true;

            List<User> transactions = new List<User>();
            // اگه فایل وجود نداره، چیزی بررسی نکن
            if (!File.Exists(ManageUsersFilepath))
            {
                Console.WriteLine("datebade not found");
                enter = false;
            }
            if (username.Length <= 0 && email.Length <= 0)
            {
                enter = false;
            }
            foreach (Char letter in username)
            {
                if (letter == Convert.ToChar(" "))
                {
                    enter = false;
                }
            }


            string jsonData = File.ReadAllText(ManageUsersFilepath);
            List<User> users = JsonConvert.DeserializeObject<List<User>>(jsonData) ?? new List<User>();


            foreach (var user in users)
            {
                if (user.Username == username)
                {
                    enter = false;
                }

            }
            foreach (var user in users)
            {
                if (user.Email == email)
                {
                    enter = false;
                }
            }
            foreach (var user in users)
            {
                if (user.Username == username && user.Email == email)
                {
                    enter = false;
                }
            }

            return enter;
        }











        public void enter_user()
        {
            while (ContorolEnterUser)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("┌--Insert User---------------------┐");
                Console.WriteLine("|                                  |");
                Console.WriteLine("|1:username:                       |");
                Console.WriteLine("|                                  |");
                Console.WriteLine("|2:Email:                          |");
                Console.WriteLine("|                                  |");
                Console.WriteLine("└----------------------------------┘");
                Console.WriteLine();
                Console.WriteLine();


                Console.SetCursorPosition(12, 4);
                string username = Console.ReadLine();



                Console.SetCursorPosition(10, 6);
                string email = Console.ReadLine();



                if (CheckUserInsert(username, email) && IsValidEmail(email))
                {
                    Username = username;
                    Email = email;
                    Console.SetCursorPosition(0, 10);
                    Console.WriteLine($"USERNAME:{Username}  EMAIL:{Email}");
                    Console.Write("THIS IS KOEY 1=YES 2=NO:");
                    InputConfirmation = Console.ReadLine();

                    if (int.TryParse(InputConfirmation, out int num) && Convert.ToInt32(InputConfirmation) >= 1 && Convert.ToInt32(InputConfirmation) <= 2 && InputConfirmation.Length > 0)
                    {
                        if (num == 1)
                        {
                            ObjectJson.Adduser(Username, Email);

                            Console.Clear();
                            break;
                        }
                        if (num == 2)
                        {
                            Console.Clear();
                            break;
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("input is invlide OR input in out of range");
                    }
                    ContorolEnterUser = true;
                }
                else
                {
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("this user there are OR your email format is wrong!!");
                    Console.WriteLine();
                    while (true)
                    {
                        Console.SetCursorPosition(0, 10);

                        Console.Write("enter 1 to back menu:");
                        string Backmenu = Console.ReadLine();
                        if (int.TryParse(Backmenu, out int back) && Convert.ToInt32(Backmenu) == 1)
                        {
                            Console.Clear();
                            ContorolEnterUser = false;
                            break; 
                        }
                        else
                        {
                            Console.WriteLine("your input in wrong!!");
                        }
                    }

                }
            }
            ContorolEnterUser = true;
        }
    }
}
