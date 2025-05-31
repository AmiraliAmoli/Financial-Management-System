
using System.Runtime.CompilerServices;
using Financial_Management_System;
using static Financial_Management_System.Manage_Users;





Manage_Users manageUsers = new Manage_Users();
Categories categories = new Categories();
Reporting reporting = new Reporting();
Transactions transactions = new Transactions();

int start = 2;
string user;
string input_number="";







while (true)
{
    if (start==2)
    {
        Console.Clear();

        Console.WriteLine("┌--Enter Panel---------------------┐");
        Console.WriteLine("|                                  |");
        Console.WriteLine("|1:user name:                      |");
        Console.WriteLine("|                                  |");
        Console.WriteLine("|2:Email:                          |");
        Console.WriteLine("|                                  |");
        Console.WriteLine("└----------------------------------┘");
        Console.WriteLine();
        Console.WriteLine();

        Console.SetCursorPosition(13, 2);
        string Username = Console.ReadLine();

        Console.SetCursorPosition(9, 4);
        string Email = Console.ReadLine();

        Console.SetCursorPosition(1, 8);

        manageUsers.CheckAdmin(Username, Email);


        if (manageUsers.enterPanel)
        {
            start = 1;
            user = Username;
            Console.Clear();

        }
        if (!manageUsers.enterPanel)
        {
            start = 2;
            Console.Clear();

        }
    }




    if (start == 1)
    {
        Console.WriteLine("┌--Financial Management System--┐");
        Console.WriteLine("|                               |");
        Console.WriteLine("|1:Manage users                 |");
        Console.WriteLine("|                               |");
        Console.WriteLine("|2:Transactions                 |");
        Console.WriteLine("|                               |");
        Console.WriteLine("|3:Categories                   |");
        Console.WriteLine("|                               |");
        Console.WriteLine("|4:Reporting                    |");
        Console.WriteLine("|                               |");
        Console.WriteLine("|5:Exit                         |");
        Console.WriteLine("└-------------------------------┘");

        Console.Write("enter number of menu item:");
        input_number = Console.ReadLine();
        start = 0;
        Console.Clear();

    }






    if (int.TryParse(input_number, out int number_item) && Convert.ToInt32(input_number) >= 1 && Convert.ToInt32(input_number) <= 5)
    {
        if (number_item == 1)
        {
            Console.WriteLine("┌--Manage users----------┐");
            Console.WriteLine("|                        |");
            Console.WriteLine("|1:inser new user        |");
            Console.WriteLine("|2:change active user    |");
            Console.WriteLine("|3:show users            |");
            Console.WriteLine("|4:back to main menu     |");
            Console.WriteLine("└------------------------┘");

            Console.WriteLine();
            Console.Write("number of menu item:");
            string sub_menu = Console.ReadLine();

            if (int.TryParse(sub_menu, out int sub_num) && Convert.ToInt32(sub_menu) >= 1 && Convert.ToInt32(sub_menu) <= 4 && sub_menu.Length > 0)
            {
                if (sub_num == 1)
                {
                    manageUsers.enter_user();

                    Console.Clear();
                    start = 1;
                }
                else if (Convert.ToInt32(sub_menu) == 2)
                {
                    manageUsers.ChangeUser();

                    if (manageUsers.restart)
                    { 
                        start = 1;
                    }

                    if (manageUsers.restart)
                    {
                        start = 2;
                    }
                }
                else if (sub_num == 3)
                {
                    manageUsers.ShowUsers();
                }
                else if (sub_num == 4)
                {
                    Console.Clear();
                    start = 1;
                }
            }
            else
            {
                Console.WriteLine("input is invlide OR input in out of range");
            }



        }
        if (number_item == 2)
        {
            Console.WriteLine("┌--Transactions--------------┐");
            Console.WriteLine("|                            |");
            Console.WriteLine("|1:Record income             |");
            Console.WriteLine("|2:Cost registration         |");
            Console.WriteLine("|3:Edit/Delete Transaction   |");
            Console.WriteLine("|4:View transaction list     |");
            Console.WriteLine("|5:back to main menu         |");
            Console.WriteLine("└----------------------------┘");

            Console.WriteLine();
            Console.Write("number of menu item:");
            string sub_menu = Console.ReadLine();

            if (int.TryParse(sub_menu, out int sub_num) && Convert.ToInt32(sub_menu) >= 1 && Convert.ToInt32(sub_menu) <= 5)
            {
                if (sub_num == 1)
                {
                }
                if (sub_num == 2)
                {
                }
                if (sub_num == 3)
                {
                }
                if (sub_num == 4)
                {
                }
                if (sub_num == 5)
                {
                    Console.Clear();
                    start = 1;
                }
            }
            else
            {
                Console.WriteLine("input is invlide OR input in out of range");
            }

        }
        if (number_item == 3)
        {
            Console.WriteLine("┌--Categories-------------------┐");
            Console.WriteLine("|                               |");
            Console.WriteLine("|1:View categories              |");
            Console.WriteLine("|                               |");
            Console.WriteLine("|2:Add custom categories        |");
            Console.WriteLine("|                               |");
            Console.WriteLine("|3:back to main menu            |");
            Console.WriteLine("└-------------------------------┘");

            Console.WriteLine();
            Console.Write("number of menu item:");
            string sub_menu = Console.ReadLine();

            if (int.TryParse(sub_menu, out int sub_num) && Convert.ToInt32(sub_menu) >= 1 && Convert.ToInt32(sub_menu) <= 3)
            {
                if (sub_num == 1)
                {
                }
                if (sub_num == 2)
                {
                }
                if (sub_num == 3)
                {
                    Console.Clear();
                    start = 1;
                }

            }
            else
            {
                Console.WriteLine("input is invlide OR input in out of range");
            }
        }
        if (number_item == 4)
        {
            Console.WriteLine("┌--Reporting------------------┐");
            Console.WriteLine("|                             |");
            Console.WriteLine("|1:Monthly summary            |");
            Console.WriteLine("|2:Categories report          |");
            Console.WriteLine("|3:daily balance              |");
            Console.WriteLine("|4:back to main menu          |");
            Console.WriteLine("└-----------------------------┘");

            Console.WriteLine();
            Console.Write("number of menu item:");
            string sub_menu = Console.ReadLine();

            if (int.TryParse(sub_menu, out int sub_num) && Convert.ToInt32(sub_menu) >= 1 && Convert.ToInt32(sub_menu) <= 5)
            {
                if (sub_num == 1)
                {
                }
                if (sub_num == 2)
                {
                }
                if (sub_num == 3)
                {
                }
                if (sub_num == 4)
                {
                    Console.Clear();
                    start = 1;
                }

            }
            else
            {
                Console.WriteLine("input is invlide OR input in out of range");
            }
        }
        if (number_item == 5)
        {
            Console.WriteLine("Program is closeing....");
            Environment.Exit(0);
        }


    }


    else
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("input is invlide OR input in out of range \n");
        Console.ForegroundColor = ConsoleColor.White;
        start = 1;
    }



}

