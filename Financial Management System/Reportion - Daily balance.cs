using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Financial_Management_System
{
    partial class Reporting
    {

        public void DailyBalance()
        {

            decimal CostSummery = 0;
            decimal IncomSummery = 0;


            List<RepCost> transactionsCost = new List<RepCost>();

            if (File.Exists(CostMonthlySummeryFilePath))
            {
                string json = File.ReadAllText(CostMonthlySummeryFilePath);
                transactionsCost = JsonConvert.DeserializeObject<List<RepCost>>(json) ?? new List<RepCost>();
            }

            if (transactionsCost.Count == 0)
            {
                Console.WriteLine("no found any Cost");
            }


            List<RepIncom> transactionsIncom = new List<RepIncom>();

            if (File.Exists(IncomMonthlySummeryFilePath))
            {
                string json = File.ReadAllText(IncomMonthlySummeryFilePath);
                transactionsIncom = JsonConvert.DeserializeObject<List<RepIncom>>(json) ?? new List<RepIncom>();
            }

            if (transactionsIncom.Count == 0)
            {
                Console.WriteLine("no found any Incom");
            }




            string NowDate = DateTime.Now.ToString("yyyy/MM/dd");
            string oneDayAgo = DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd");

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Summery:{NowDate} to {oneDayAgo}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("┌------------------------------------------------------------------------------------------------------┐");
            Console.WriteLine("|         CostSummery         |        IncomSummery        |        Balance (income - expense)         |");
            Console.WriteLine("|------------------------------------------------------------------------------------------------------|");
            Console.WriteLine("|                             |                            |                                           |");
            Console.WriteLine("└------------------------------------------------------------------------------------------------------┘");








            foreach (var item in transactionsCost)
            {
                string CostDate = item.Date.Substring(0, 10);
                if (CostDate == NowDate)
                {
                    CostSummery += item.Amount;

                }
            }








            foreach (var item in transactionsIncom)
            {
                string IncomDate = item.Date.Substring(0, 10);
                if (IncomDate == NowDate)
                {
                    IncomSummery += item.Amount;

                }
            }


            Console.SetCursorPosition(10, 4);
            Console.Write(CostSummery);
            Console.SetCursorPosition(39, 4);
            Console.Write(IncomSummery);

            decimal Summery = IncomSummery - CostSummery;
            Console.SetCursorPosition(80, 4);
            Console.Write(Summery);

            Console.SetCursorPosition(80, 6);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("100|");
            Console.WriteLine("95 |");
            Console.WriteLine("90 |");
            Console.WriteLine("85 |");
            Console.WriteLine("80 |");
            Console.WriteLine("75 |");
            Console.WriteLine("70 |");
            Console.WriteLine("65 |");
            Console.WriteLine("60 |");
            Console.WriteLine("55 |");
            Console.WriteLine("50 |");
            Console.WriteLine("45 |");
            Console.WriteLine("40 |");
            Console.WriteLine("35 |");
            Console.WriteLine("30 |");
            Console.WriteLine("25 |");
            Console.WriteLine("20 |");
            Console.WriteLine("15 |");
            Console.WriteLine("10 |");
            Console.WriteLine(" 5 |");
            Console.WriteLine("   └-------");
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;


            decimal BigesNumber = 0;

            if (BigesNumber < CostSummery)
            {
                BigesNumber = CostSummery;
            }
            if (BigesNumber < IncomSummery)
            {
                BigesNumber = IncomSummery;
            }
            if (BigesNumber < Summery)
            {
                BigesNumber = Summery;
            }


            double Avg = Convert.ToDouble(BigesNumber) / 20;

            double CostBarChart = Convert.ToInt32(CostSummery) / Convert.ToInt32(Avg);
            double IncomBarChart = Convert.ToInt32(IncomSummery) / Convert.ToInt32(Avg);
            double SummeryBarChart = Convert.ToInt32(Summery) / Convert.ToInt32(Avg);


            int BarPlace = 26;



            if (CostSummery > 0)
            {
                Console.SetCursorPosition(11, 27);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Cost");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("----");


                for (int j = 0; j < CostBarChart; j++)
                {
                    if (BarPlace == 6)
                    {
                        break;
                    }
                    Console.SetCursorPosition(13, BarPlace);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("█");
                    Console.ForegroundColor = ConsoleColor.White;
                    BarPlace--;

                }
            }






            if (IncomSummery > 0)
            {
                Console.SetCursorPosition(19, 27);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Incom");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("----");


                BarPlace = 26;
                for (int j = 0; j < IncomBarChart; j++)
                {
                    if (BarPlace == 6)
                    {
                        break;
                    }
                    Console.SetCursorPosition(21, BarPlace);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("█");
                    Console.ForegroundColor = ConsoleColor.White;

                    BarPlace--;

                }
            }


            if (Summery > 0)
            {


                Console.SetCursorPosition(27, 27);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Summery");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("----");

                BarPlace = 26;
                for (int j = 0; j < SummeryBarChart; j++)
                {
                    if (BarPlace == 6)
                    {
                        break;
                    }
                    Console.SetCursorPosition(30, BarPlace);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("█");
                    Console.ForegroundColor = ConsoleColor.White;
                    BarPlace--;

                }

            }




            Console.SetCursorPosition(0, 28);

            while (true)
            {
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
                }
            }


        }

    }
}
