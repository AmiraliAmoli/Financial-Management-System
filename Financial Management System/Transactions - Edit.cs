using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using static Financial_Management_System.Manage_Users;

namespace Financial_Management_System
{
    partial class Transactions
    {
        private string FinalDate;
        bool ValidDateState = false;
        private void ValidDate(string year, string month, string day)
        {


            int CurrentYeat = DateTime.Now.Year;

            if (year.Length == 4 && month.Length == 2 && day.Length == 2 && int.TryParse(year, out int sal) && int.TryParse(month, out int mah) && int.TryParse(day, out int roz))
            {
                if (Convert.ToInt32(year) > 2023 && Convert.ToInt32(year) <= CurrentYeat)
                {
                    if (Convert.ToInt32(month) > 0 && Convert.ToInt32(month) <= 12)
                    {
                        if (Convert.ToInt32(day) > 0 && Convert.ToInt32(day) <= 31)
                        {
                            FinalDate = year + "/" + month + "/" + day;
                            ValidDateState = true;
                        }
                        else
                        {
                            Console.Clear();
                            Console.SetCursorPosition(0, 0);
                            Console.WriteLine("your day input out of range !!");
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.SetCursorPosition(0, 0);
                        Console.WriteLine("your month input out of range !!");
                    }
                }
                else
                {
                    Console.Clear();
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("your year input out of range !!");
                }
            }
            else
            {
                Console.Clear();
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("your input format or type is worng!!");

            }



        }





        public void InitializeIncom(out decimal Amount, out string source, out string date, out string description, out bool notenter)
        {
            Amount = 0;
            source = "";
            date = "";
            description = "";
            notenter = false;

            decimal EditAmount = 0;
            string EditSourseOfIncome = "";
            string EditDescription = "";
            int EditTrueInputIncom = 0;
            int EditFalseInputIncom = 0;



            string DateOfTrancactions = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

            while (true)
            {
                if (EditTrueInputIncom >= 3)
                {
                    EditTrueInputIncom = 0;
                    Console.SetCursorPosition(0, 11);
                    Console.WriteLine($"your amount: {EditAmount}  source: {EditSourseOfIncome} date: {DateOfTrancactions} description: {EditDescription}");
                    Console.Write("Do you want to enter this value? 1=YES  2=NO: ");
                    string EnterValue = Console.ReadLine();
                    Console.Clear();

                    if (int.TryParse(EnterValue, out int input) && input == 1)
                    {
                        Amount = EditAmount;
                        source = EditSourseOfIncome;
                        date = DateOfTrancactions;
                        description = EditDescription;
                        notenter = false;
                        Console.WriteLine("Value entered successfully.");
                        break;
                    }
                    else if (input == 2)
                    {

                        notenter = true;
                        break;
                    }
                }


                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("┌--Record income-------------------┐");
                Console.WriteLine("|                                  |");
                Console.WriteLine("|amount:                           |");
                Console.WriteLine("|source of income:                 |");
                Console.WriteLine($"|date:{DateOfTrancactions}          |");
                Console.WriteLine("|Description:                      |");
                Console.WriteLine("|                                  |");
                Console.WriteLine("└----------------------------------┘");
                Console.WriteLine();

                Console.SetCursorPosition(8, 3);
                string InputAmount = Console.ReadLine();
                if (decimal.TryParse(InputAmount, out decimal amount))
                {
                    EditAmount = amount;
                    EditTrueInputIncom++;
                }
                else { EditFalseInputIncom++; }

                Console.SetCursorPosition(18, 4);
                string InputSourceOfIncome = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(InputSourceOfIncome))
                {
                    EditSourseOfIncome = InputSourceOfIncome;
                    EditTrueInputIncom++;
                }
                else { EditFalseInputIncom++; }

                Console.SetCursorPosition(13, 6);
                string InputDescription = Console.ReadLine();
                if (!string.IsNullOrEmpty(InputDescription))
                {
                    EditDescription = InputDescription;
                }
                else
                {
                    EditDescription = "";
                }
                EditTrueInputIncom++;

                if (EditFalseInputIncom >= 1)
                {
                    EditTrueInputIncom = 0;
                    EditFalseInputIncom = 0;
                    Amount = 0;
                    source = "";
                    date = "";
                    description = "";
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Your inputs are wrong!");
                    Console.ForegroundColor = ConsoleColor.White;
                    notenter = true;
                    break;
                }
            }
        }








        public void InitializeCost(out decimal Amount, out string Category, out string date, out string description, out bool notenter)
        {
            Amount = 0;
            Category = "";
            date = "";
            description = "";
            notenter = false;

            decimal EditAmount = 0;
            string EditCategory = "";
            string EditDescription = "";
            int EditTrueInputCost = 0;
            int EditFalseInputCost = 0;

            Categories MyCategory = new Categories();


            string DateOfTrancactions = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            int LengthOfCategory = ObjectJson.CategoriesCounter();

            while (true)
            {
                if (EditTrueInputCost >= 3)
                {
                    EditTrueInputCost = 0;
                    Console.SetCursorPosition(0, LengthOfCategory+10);
                    Console.WriteLine($"your amount: {EditAmount}  Category: {EditCategory} date: {DateOfTrancactions} description: {EditDescription}");
                    Console.Write("Do you want to enter this value? 1=YES  2=NO: ");
                    string EnterValue = Console.ReadLine();
                    Console.Clear();

                    if (int.TryParse(EnterValue, out int input) && input == 1)
                    {
                        Amount = EditAmount;
                        Category = EditCategory;
                        date = DateOfTrancactions;
                        description = EditDescription;
                        notenter = false;
                        Console.WriteLine("Value entered successfully.");
                        break;
                    }
                    else if (input == 2)
                    {

                        notenter = true;
                        break;
                    }
                }


                
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("┌--cost registration---------------┐");
                Console.WriteLine("|                                  |");
                Console.WriteLine("|amount:                           |");
                Console.WriteLine("|category:                         |");
                for (int i = 0; i < LengthOfCategory; i++)
                {
                    Console.WriteLine("|                                  |");
                }
                Console.WriteLine($"|date:{DateOfTrancactions}          |");
                Console.WriteLine("|Description:                      |");
                Console.WriteLine("|                                  |");
                Console.WriteLine("└----------------------------------┘");

                ObjectJson.ShowCategory(8, 5);




                Console.SetCursorPosition(8, 4);
                string inputAmount = Console.ReadLine();
                if (decimal.TryParse(inputAmount, out decimal amount))
                {

                    EditAmount = Convert.ToDecimal(inputAmount);
                    EditTrueInputCost++;
                }
                else
                {
                    EditFalseInputCost++;
                }


                Console.SetCursorPosition(10, 5);
                string NumberOfCat = Console.ReadLine();
                if (int.TryParse(NumberOfCat, out int numCat) && Convert.ToInt32(NumberOfCat) >= 1 && Convert.ToInt32(NumberOfCat) <= LengthOfCategory)
                {
                    string NameOfCat = ObjectJson.NameofCategory(numCat);
                    EditCategory = NameOfCat;

                    Console.Write(EditCategory);
                    EditTrueInputCost++;
                }
                else
                {
                    EditFalseInputCost++;
                }


                Console.SetCursorPosition(13, LengthOfCategory + 7);
                string InputDescription = Console.ReadLine();
                if (InputDescription.Length >= 1)
                {
                    EditDescription = InputDescription;
                    EditTrueInputCost++;
                }
                else if (InputDescription.Length < 1)
                {
                    CsotDescription = "";
                    EditTrueInputCost++;
                }
                else
                {
                    EditFalseInputCost++;
                }


                if (EditFalseInputCost >= 1)
                {
                    EditTrueInputCost = 0;
                    EditFalseInputCost = 0;
                    Console.Clear();
                    Console.SetCursorPosition(0, 0);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("your inputs is wrong!!");
                    Console.ForegroundColor = ConsoleColor.White;
                    notenter = true;
                    break;

                }
            }
        }





















        public void EditAndDelet()
        {
            bool Incom = false;
            bool cost = false;

            while (true)
            {
                Console.Write("wich ont would you change? (1=incom 2=cost):");
                string choise = Console.ReadLine();

                if (int.TryParse(choise, out int option) && choise.Length > 0)
                {
                    if (option == 1)
                    {
                        Incom = true;
                        Console.Clear();
                        break;
                    }
                    if (option == 2)
                    {
                        cost = true;
                        Console.Clear();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("your input is out of range!!");
                    }

                }
                else
                {
                    Console.WriteLine("your input is wrong!!");
                }
            }

            bool ExitDate = false;
            bool EnterDate = true;
            while (true)
            {
                if (ExitDate)
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
                        Console.Clear();
                    }
                }
                ExitDate = true;



                Console.SetCursorPosition(0, 0);
                Console.WriteLine();
                Console.WriteLine("┌--Enter Date----------------------┐");
                Console.WriteLine("|                                  |");
                Console.WriteLine("|year:                             |");
                Console.WriteLine("|                                  |");
                Console.WriteLine("|month:                            |");
                Console.WriteLine("|                                  |");
                Console.WriteLine("|day:                              |");
                Console.WriteLine("|                                  |");
                Console.WriteLine("└----------------------------------┘");

                Console.SetCursorPosition(6, 3);
                string year = Console.ReadLine();

                Console.SetCursorPosition(7, 5);
                string month = Console.ReadLine();

                Console.SetCursorPosition(5, 7);
                string day = Console.ReadLine();


                ValidDate(year, month, day);

                if (ValidDateState)
                {
                    if (Incom)
                    {
                        ObjectJson.EditIncom(FinalDate);
                    }
                    if (cost)
                    {
                        ObjectJson.EditCost(FinalDate);
                    }
                }
                else { break; }
                ValidDateState = false;


            }

        }
    }
}
