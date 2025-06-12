using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using static Financial_Management_System.ObjectJson;

namespace Financial_Management_System
{
    partial class Reporting
    {
        private const string CostFilePath = @"C:\Users\amir\source\repos\Financial Management System\Financial Management System\obj\Debug\net8.0\transaction_cost.json";
        private const string CatoryFilePath = @"C:\Users\amir\source\repos\Financial Management System\Financial Management System\obj\Debug\net8.0\categories.json";

        public class RepCost
        {
            public decimal Amount { get; set; }
            public string Category { get; set; }
            public string Date { get; set; }
            public string Description { get; set; }
        }
        public void CategoryReport()
        {
            List<EnterCategoris> CategorisDatebase = new List<EnterCategoris>();

            if (File.Exists(CatoryFilePath))
            {
                string json = File.ReadAllText(CatoryFilePath);
                CategorisDatebase = JsonConvert.DeserializeObject<List<EnterCategoris>>(json) ?? new List<EnterCategoris>();
            }

            if (CategorisDatebase.Count == 0)
            {
                Console.WriteLine("no found any category");
            }



            List<RepCost> transactions = new List<RepCost>();

            if (File.Exists(CostFilePath))
            {
                string json = File.ReadAllText(CostFilePath);
                transactions = JsonConvert.DeserializeObject<List<RepCost>>(json) ?? new List<RepCost>();
            }

            if (transactions.Count == 0)
            {
                Console.WriteLine("no found any category");
            }






            string[] Categories = new string[CategorisDatebase.Count];

            int Counter = 1;
            foreach (var item in CategorisDatebase)
            {
                Categories[Counter - 1] = item.CategoryName;
                Counter++;
            }

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("100|");
            Console.WriteLine("90 |");
            Console.WriteLine("80 |");
            Console.WriteLine("70 |");
            Console.WriteLine("60 |");
            Console.WriteLine("50 |");
            Console.WriteLine("40 |");
            Console.WriteLine("30 |");
            Console.WriteLine("20 |");
            Console.WriteLine("10 |");
            Console.WriteLine("   └-------");
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;

            double BigesAmount = Convert.ToDouble(transactions[0].Amount);
            double amount = 0;
            double Avg = 0;
            int LeftSpaceInChart = 11;

            for (int i = 0; i < CategorisDatebase.Count; i++)
            {
                foreach (var item in transactions)
                {
                    if (Categories[i] == item.Category)
                    {
                        amount = amount + Convert.ToDouble(item.Amount);
                        if (amount >= BigesAmount)
                        {
                            BigesAmount = amount ;
                        }
                    }
                }
                amount = 0;
                Avg = BigesAmount / 100;
            }

            decimal CostInCat = 0;
            for (int i = 0; i < CategorisDatebase.Count; i++)
            {
                foreach (var item in transactions)
                {
                    if (Categories[i] == item.Category)
                    {
                        CostInCat += item.Amount;
                    }

                }

                double BarChart = Convert.ToInt32(CostInCat) / Avg;
                if (CostInCat > 0)
                {
                    Console.SetCursorPosition(LeftSpaceInChart, 10);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($"{Categories[i]}");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("----");
                    LeftSpaceInChart = LeftSpaceInChart + Categories[i].Length;
                    int BarPlace = 9;
                    for (int j = 0; j < BarChart; j++)
                    {
                        if (BarPlace == 0)
                        {
                            break;
                        }
                        Console.SetCursorPosition(LeftSpaceInChart - (Categories[i].Length / 2), BarPlace);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("█");
                        Console.ForegroundColor = ConsoleColor.White;

                        BarPlace--;

                    }
                    Console.WriteLine();
                    LeftSpaceInChart += 4;
                    CostInCat = 0;
                    BarChart = 0;
                }
            }

            Console.SetCursorPosition(0, 12);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"NOTE:any 10 percent={Avg}$");
            Console.ForegroundColor = ConsoleColor.White;

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
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



          
        }


    }
}
