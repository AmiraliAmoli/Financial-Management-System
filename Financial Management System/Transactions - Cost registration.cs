using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;



namespace Financial_Management_System
{

    partial class Transactions
    {

        Categories MyCategory = new Categories();
        private decimal costamount;
        public decimal CostAmount
        {
            get { return costamount; }
            set { costamount = value; }
        }

        private string costcategory;
        public string CostCategory
        {
            get { return costcategory; }
            set { costcategory = value; }
        }
        private string costdate;
        public string CostDate
        {
            get { return costdate; }
            set { costdate = value; }
        }

        private string csotdescription;
        public string CsotDescription
        {
            get { return csotdescription; }
            set { csotdescription = value; }
        }
        private int TrueInputCost = 0;
        private int FalseInputCost = 0;
        public void CostRegistration()
        {


            CostDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            int LengthOfCategory = ObjectJson.CategoriesCounter();

            while (true)
            {

                if (TrueInputCost >= 3)
                {
                    TrueInputCost = 0;
                    Console.SetCursorPosition(0, LengthOfCategory+ 10);

                    Console.WriteLine($"your amount:{costamount}  category:{costcategory} date:{CostDate} description:{csotdescription}");
                    Console.Write("do yo sure to enter this value 1=YES 2=NO:");
                    string EnterValue = Console.ReadLine();

                    if (int.TryParse(EnterValue, out int input1) && Convert.ToInt32(EnterValue) == 1)
                    {
                        ObjectJson.Addcost(costamount, costcategory, CostDate, csotdescription);
                        break;

                    }
                    if (int.TryParse(EnterValue, out int input2) && Convert.ToInt32(EnterValue) == 2)
                    {
                        Console.Clear();
                        break;
                    }

                }



                

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
                Console.WriteLine($"|date:{CostDate}          |");
                Console.WriteLine("|Description:                      |");
                Console.WriteLine("|                                  |");
                Console.WriteLine("└----------------------------------┘");



                ObjectJson.ShowCategory(8, 5);



                Console.SetCursorPosition(8, 4);
                string inputAmount = Console.ReadLine();
                if (decimal.TryParse(inputAmount, out decimal amount))
                {

                    CostAmount = Convert.ToDecimal(inputAmount);
                    TrueInputCost++;
                }
                else
                {
                    FalseInputCost++;
                }


                Console.SetCursorPosition(10, 5);
                string NumberOfCat = Console.ReadLine();
                if (int.TryParse(NumberOfCat, out int numCat) && Convert.ToInt32(NumberOfCat) >= 1 && Convert.ToInt32(NumberOfCat) <= LengthOfCategory)
                {
                    string NameOfCat= ObjectJson.NameofCategory(numCat); 
                    CostCategory = NameOfCat;

                    Console.Write(CostCategory);
                    TrueInputCost++;
                }
                else
                {
                    FalseInputCost++;
                }


                Console.SetCursorPosition(13, LengthOfCategory + 7);
                string InputDescription = Console.ReadLine();
                if (InputDescription.Length >= 1)
                {
                    CsotDescription = InputDescription;
                    TrueInputCost++;
                }
                else if (InputDescription.Length < 1)
                {
                    CsotDescription = "";
                    TrueInputCost++;
                }
                else
                {
                    FalseInputCost++;
                }


                if (FalseInputCost >= 1)
                {
                    TrueInputCost = 0;
                    FalseInputCost = 0;
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
