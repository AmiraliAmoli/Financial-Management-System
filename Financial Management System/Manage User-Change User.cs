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
        public bool restart;

        public void ChangeUser()
        {
            while (true)
            {
                Console.Write($"your username is ({EnteranlUser}) do you want change it (1=yes 2=no)?");
                string Chang = Console.ReadLine();

                if (int.TryParse(Chang, out int chang) && Convert.ToInt32(Chang) >= 1 && Convert.ToInt32(Chang) <= 2 && Chang.Length > 0)
                {
                    if (chang == 1)
                    {
                        restart = true;
                        break;

                    }
                    else if (chang == 2)
                    {
                        restart = false;
                        break;
                    }
                    else
                    {
                        Console.SetCursorPosition(0, 0);
                        Console.WriteLine("your input is out of range");

                    }
                }

                else {

                    
                    Console.WriteLine("your input is wrong!!!");
                }
            }
        }


    }
}
