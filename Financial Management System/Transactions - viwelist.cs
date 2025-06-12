using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using static Financial_Management_System.Manage_Users;
using static Financial_Management_System.ObjectJson;

namespace Financial_Management_System
{
    partial class Transactions
    {
        private const string TransactionIncomFilepath = @"C:\Users\amir\source\repos\Financial Management System\Financial Management System\obj\Debug\net8.0\transaction_icom.json";
        private const string TransactionCostFilepath = @"C:\Users\amir\source\repos\Financial Management System\Financial Management System\obj\Debug\net8.0\transaction_cost.json";

        public void ShowIcom()
        {
            if (!File.Exists(TransactionIncomFilepath))
            {
                Console.WriteLine("incom datebase not found");
                return;
            }

            string json = File.ReadAllText(TransactionIncomFilepath);
            List<EnterIncom> incoms = JsonConvert.DeserializeObject<List<EnterIncom>>(json) ?? new List<EnterIncom>();

            if (incoms.Count == 0)
            {
                Console.WriteLine("incom list in null !!!");
                return;
            }

            Console.WriteLine();
            Console.WriteLine("incom list:");
            foreach (var incom in incoms)
            {
                Console.WriteLine($"-  date={incom.Date} | amount={incom.Amount} | Source={incom.Source} | description={incom.Description}");
            }

           
        }


        public void ShowCost()
        {
            if (!File.Exists(TransactionCostFilepath))
            {
                Console.WriteLine("cost datebase not found");
                return;
            }

            string json = File.ReadAllText(TransactionCostFilepath);
            List<EnterCost> costs = JsonConvert.DeserializeObject<List<EnterCost>>(json) ?? new List<EnterCost>();

            if (costs.Count == 0)
            {
                Console.WriteLine("cost list in null !!!");
                return;
            }

            Console.WriteLine();
            Console.WriteLine("cost list:");
            foreach (var cost in costs)
            {
                Console.WriteLine($"-  date={cost.Date} | amount={cost.Amount} | category={cost.Category} | description={cost.Description}");
            }

            while (true)
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
                }
            }
        }
    }
}
