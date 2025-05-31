using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Financial_Management_System
{
    partial class Manage_Users
    {
        public bool restart ;
        public void ChangeUser()
        {
            Console.Write($"your username is ({EnteranlUser}) do you want change it (1=yes 2=no)?");
            string Chang=Console.ReadLine();

            if (int.TryParse(Chang, out int ChangeUser) && Convert.ToInt32(Chang) >= 1 && Convert.ToInt32(Chang) <= 2 && Chang.Length > 0)
            {
                if (ChangeUser == 1)
                {
                    restart = true;
                }
                if (ChangeUser == 2)
                {
                    restart = false;
                    Console.Clear();
                }
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("input is invlide OR input in out of range \n");
                Console.ForegroundColor = ConsoleColor.White;
                
            }
                
        }


    }
}
