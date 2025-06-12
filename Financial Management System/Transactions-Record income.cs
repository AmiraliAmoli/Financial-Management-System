using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32.SafeHandles;

namespace Financial_Management_System
{
    partial class Transactions
    {

        private decimal incomAmount;
        public decimal IncomAmount
        {
            get { return incomAmount; }
            set { incomAmount = value; }
        }
        private string incomDate;
        public string IncomDate
        {
            get { return incomDate; }
            set { incomDate = value; }
        }
        private string incomsourseofincome;
        public string IncomSourseOfIncome
        {
            get { return incomsourseofincome; }
            set { incomsourseofincome = value; }
        }

        private string incomdescription;
        public string IncomDescription
        {
            get { return incomdescription; }
            set { incomdescription = value; }
        }

        private int TrueInputIncom = 0;
        private int FalseInputIncom = 0;




        public void RecordIncome()
        {

            IncomDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");


            while (true)
            {
                if (TrueInputIncom >= 3)
                {
                    TrueInputIncom = 0;
                    Console.SetCursorPosition(0, 11);

                    Console.WriteLine($"your amount:{IncomAmount}  sourse:{IncomSourseOfIncome} date:{IncomDate} description:{IncomDescription}");
                    Console.Write("do yo sure to enter this value 1=YES 2=NO:");
                    string EnterValue = Console.ReadLine();
                    Console.Clear();

                    if (int.TryParse(EnterValue, out int input1) && Convert.ToInt32(EnterValue) == 1)
                    {
                        Console.Clear();
                        ObjectJson.AddIncom(IncomAmount, IncomSourseOfIncome, IncomDate, IncomDescription);
                        Console.SetCursorPosition(0, 0);
                        Console.WriteLine("enter value");
                        break;

                    }
                    if (int.TryParse(EnterValue, out int input2) && Convert.ToInt32(EnterValue) == 2)
                    {

                        break;
                    }

                }
                

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("┌--Record income-------------------┐");
                Console.WriteLine("|                                  |");
                Console.WriteLine("|amount:                           |");
                Console.WriteLine("|source of income:                 |");
                Console.WriteLine($"|date:{IncomDate}          |");
                Console.WriteLine("|Description:                      |");
                Console.WriteLine("|                                  |");
                Console.WriteLine("└----------------------------------┘");
                Console.WriteLine();
                Console.WriteLine();

                Console.SetCursorPosition(8, 4);
                string InputAmount = Console.ReadLine();
                if (decimal.TryParse(InputAmount, out decimal amount))
                {

                    IncomAmount = Convert.ToDecimal(InputAmount);
                    TrueInputIncom++;
                }
                else { FalseInputIncom++; }

                Console.SetCursorPosition(18, 5);
                string InputSourceOfIncome = Console.ReadLine();
                if (InputSourceOfIncome.Length >= 1)
                {

                    IncomSourseOfIncome = InputSourceOfIncome;
                    TrueInputIncom++;
                }
                else { FalseInputIncom++; }

                Console.SetCursorPosition(13, 7);
                string InputDescription = Console.ReadLine();
                if (InputDescription.Length >= 1)
                {
                    TrueInputIncom++;
                    IncomDescription = InputDescription;
                }
                else if (InputDescription.Length < 1)
                {
                    TrueInputIncom++;
                    IncomDescription = "";
                }
                else { FalseInputIncom++; }

                if (FalseInputIncom >= 1)
                {
                    TrueInputIncom = 0;
                    FalseInputIncom = 0;
                    Console.Clear();
                    Console.SetCursorPosition(0, 0);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("your inputs is wrong!!");
                    Console.ForegroundColor = ConsoleColor.White;

                    break;

                }





            }

        }

    }
}





