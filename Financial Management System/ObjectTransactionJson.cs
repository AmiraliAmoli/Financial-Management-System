using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Transactions;
using Newtonsoft.Json;
using static Financial_Management_System.Manage_Users;

namespace Financial_Management_System
{
    class ObjectJson
    {
        private const string TransactionIncomFilepath = @"C:\Users\amir\source\repos\Financial Management System\Financial Management System\obj\Debug\net8.0\transaction_icom.json";
        private const string TransactionCostFilepath = @"C:\Users\amir\source\repos\Financial Management System\Financial Management System\obj\Debug\net8.0\transaction_cost.json";
        private const string ManageUsersFilepath = @"C:\Users\amir\source\repos\Financial Management System\Financial Management System\obj\Debug\net8.0\user.json";
        private const string CategoriesFilepath = @"C:\Users\amir\source\repos\Financial Management System\Financial Management System\obj\Debug\net8.0\categories.json";

        public class EnterIncom
        {
            public decimal Amount { get; set; }
            public string Source { get; set; }
            public string Date { get; set; }
            public string Description { get; set; }
        }
        public class EnterCost
        {
            public decimal Amount { get; set; }
            public string Category { get; set; }
            public string Date { get; set; }
            public string Description { get; set; }
        }
        public class EnterUser
        {
            public string Username { get; set; }
            public string Email { get; set; }
        }
        public class EnterCategoris
        {
            public string CategoryName { get; set; }

        }

        public static string NameofCategory(int numOfCategory)
        {
            string Result = "";

            List<EnterCategoris> CategorisDatebase = new List<EnterCategoris>();


            if (File.Exists(CategoriesFilepath))
            {
                string json = File.ReadAllText(CategoriesFilepath);
                CategorisDatebase = JsonConvert.DeserializeObject<List<EnterCategoris>>(json) ?? new List<EnterCategoris>();
            }

            if (CategorisDatebase.Count == 0)
            {
                Console.WriteLine("no found any category");
            }


            string[] Categories = new string[CategorisDatebase.Count];

            int Counter = 1;
            foreach (var item in CategorisDatebase)
            {

                Categories[Counter - 1] = CategorisDatebase[Counter - 1].CategoryName;
                Counter++;
            }

            for (int i = 0; i < Categories.Length; i++)
            {
                if (i + 1 == numOfCategory)
                {
                    Console.SetCursorPosition(10, 5);

                    Result = Categories[i];
                }
            }

            return Result;
        }


        public static void AddCategory(string category)
        {

            List<EnterCategoris> Categoris = new List<EnterCategoris>();

            if (File.Exists(CategoriesFilepath))
            {
                string json = File.ReadAllText(CategoriesFilepath);
                Categoris = JsonConvert.DeserializeObject<List<EnterCategoris>>(json) ?? new List<EnterCategoris>();
            }



            bool ValidCat = true;
            foreach (var item in Categoris)
            {
                if (item.CategoryName.ToLower() == category)
                {
                    Console.Clear();
                    Console.WriteLine("this Category there are !!!");
                    Console.WriteLine();
                    Console.WriteLine();
                    ValidCat = false;
                    break;
                }
            }

            if (ValidCat)
            {
                EnterCategoris newCategort = new EnterCategoris
                {
                    CategoryName = category

                };
                Categoris.Add(newCategort);

                string updatedJson = JsonConvert.SerializeObject(Categoris, Formatting.Indented);
                File.WriteAllText(CategoriesFilepath, updatedJson);



                Console.Clear();
                Console.WriteLine("The category was successfully recorded");
                Console.WriteLine();
                Console.WriteLine();
            }

            
        }

        public static int CategoriesCounter()
        {
            List<EnterCategoris> CategorisDatebase = new List<EnterCategoris>();


            if (File.Exists(CategoriesFilepath))
            {
                string json = File.ReadAllText(CategoriesFilepath);
                CategorisDatebase = JsonConvert.DeserializeObject<List<EnterCategoris>>(json) ?? new List<EnterCategoris>();
            }

            if (CategorisDatebase.Count == 0)
            {
                Console.WriteLine("no found any category");
            }

            return CategorisDatebase.Count;




        }

        public static void ShowCategory(int left, int top)
        {
            List<EnterCategoris> CategorisDatebase = new List<EnterCategoris>();


            if (File.Exists(CategoriesFilepath))
            {
                string json = File.ReadAllText(CategoriesFilepath);
                CategorisDatebase = JsonConvert.DeserializeObject<List<EnterCategoris>>(json) ?? new List<EnterCategoris>();
            }

            if (CategorisDatebase.Count == 0)
            {
                Console.WriteLine("no found any category");
            }


            string[] Categories = new string[CategorisDatebase.Count];

            int Counter = 1;
            foreach (var item in CategorisDatebase)
            {
                Console.SetCursorPosition(left, Counter + top);

                Console.WriteLine($"{Counter}= {CategorisDatebase[Counter - 1].CategoryName}");
                Categories[Counter - 1] = CategorisDatebase[Counter - 1].CategoryName;
                Counter++;
            }






        }


        public static void AddIncom(decimal amount, string source, string date, string description)
        {
            List<EnterIncom> transactions = new List<EnterIncom>();

            // اگر فایل موجود بود، تراکنش‌های قبلی رو بخون
            if (File.Exists(TransactionIncomFilepath))
            {
                string json = File.ReadAllText(TransactionIncomFilepath);
                transactions = JsonConvert.DeserializeObject<List<EnterIncom>>(json) ?? new List<EnterIncom>();
            }

            // ساختن تراکنش جدید
            EnterIncom newEnterTransaction = new EnterIncom
            {
                Amount = amount,
                Source = source,
                Date = date,
                Description = description
            };

            // افزودن به لیست و ذخیره دوباره
            transactions.Add(newEnterTransaction);

            string updatedJson = JsonConvert.SerializeObject(transactions, Formatting.Indented);
            File.WriteAllText(TransactionIncomFilepath, updatedJson);

            Console.WriteLine("The transaction was successfully recorded");
        }





        public static void Addcost(decimal amount, string category, string date, string description)
        {
            List<EnterCost> transactions = new List<EnterCost>();

            // اگر فایل موجود بود، تراکنش‌های قبلی رو بخون
            if (File.Exists(TransactionCostFilepath))
            {
                string jsonCost = File.ReadAllText(TransactionCostFilepath);
                transactions = JsonConvert.DeserializeObject<List<EnterCost>>(jsonCost) ?? new List<EnterCost>();
            }

            // ساختن تراکنش جدید
            EnterCost newEnterTransaction = new EnterCost
            {
                Amount = amount,
                Category = category,
                Date = date,
                Description = description
            };

            if (!File.Exists(TransactionIncomFilepath))
            {
                Console.WriteLine("incom datebase not found");
                return;
            }

            string jsonIncom = File.ReadAllText(TransactionIncomFilepath);
            List<EnterIncom> incoms = JsonConvert.DeserializeObject<List<EnterIncom>>(jsonIncom) ?? new List<EnterIncom>();

            if (incoms.Count == 0)
            {
                Console.WriteLine("you have not incom so can enter any cost");
                return;
            }





            double Cost = 0;
            double incom = 0;

            foreach (var item in transactions)
            {
                Cost += Convert.ToDouble(item.Amount);
            }

            foreach (var item in incoms)
            {
                incom += Convert.ToDouble(item.Amount);
            }
            Console.WriteLine(incom);

            double FinalCost = Cost + Convert.ToDouble(amount);
            Console.WriteLine(FinalCost);

            if (incom > FinalCost)
            {
                Console.Clear();
                Console.SetCursorPosition(0, 0);
                transactions.Add(newEnterTransaction);
                Console.WriteLine("The transaction was successfully recorded");

            }
            if (incom < FinalCost)
            {
                Console.Clear();
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("your incom is less than your cost so you can not enter incom");

            }

            string updatedJson = JsonConvert.SerializeObject(transactions, Formatting.Indented);
            File.WriteAllText(TransactionCostFilepath, updatedJson);


        }


        public static void Adduser(string username, string email)
        {
            List<EnterUser> users = new List<EnterUser>();

            // اگر فایل موجود بود، تراکنش‌های قبلی رو بخون
            if (File.Exists(ManageUsersFilepath))
            {
                string json = File.ReadAllText(ManageUsersFilepath);
                users = JsonConvert.DeserializeObject<List<EnterUser>>(json) ?? new List<EnterUser>();
            }

            // ساختن تراکنش جدید
            EnterUser newEnterUser = new EnterUser
            {
                Username = username,
                Email = email,

            };

            // افزودن به لیست و ذخیره دوباره
            users.Add(newEnterUser);

            string updatedJson = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText(ManageUsersFilepath, updatedJson);

            Console.WriteLine("The user was successfully recorded");

        }




        public static void EditIncom(string date)
        {
            decimal OldAmount = 0;
            string OldDescription = "";
            string OldDate = "";
            string OldSource = "";
            bool NotEnter = false;


            decimal EditAmoun = 0;
            string EditeDate = "";
            string Editesource = "";
            string EditeDescription = "";



            if (!File.Exists(TransactionIncomFilepath))
            {
                Console.WriteLine("incom datebase not found");
                return;
            }

            string json = File.ReadAllText(TransactionIncomFilepath);
            List<EnterIncom> transactions = JsonConvert.DeserializeObject<List<EnterIncom>>(json) ?? new List<EnterIncom>();



            if (transactions.Count == 0)
            {
                Console.SetCursorPosition(0, 11);
                Console.WriteLine("No incom found");
                return;
            }



            string[,] incoms = new string[transactions.Count, 4];

            int i = 0;
            foreach (var transaction in transactions)
            {
                for (int h = 0; h < 4;)
                {
                    incoms[i, h] = $"{transaction.Amount}";
                    h++;
                    incoms[i, h] = $"{transaction.Source}";
                    h++;
                    incoms[i, h] = $"{transaction.Date}";
                    h++;
                    incoms[i, h] = $"{transaction.Description}";
                    h++;

                }

                i++;
            }





            Console.SetCursorPosition(0, 11);
            Console.WriteLine("incom list:");

            int r = 0;
            int Counter = 1;
            for (; r < transactions.Count; r++)
            {
                string CutDate = incoms[r, 2].Substring(0, 10);

                if (CutDate == date)
                {
                    Console.WriteLine($"{Counter}={incoms[r, 2]}  {incoms[r, 0]}  {incoms[r, 1]}  {incoms[r, 3]}    ");
                    Counter++;
                }

            }

            if (Counter == 1)
            {
                Console.WriteLine("in this date no foud any incoms");
            }










            bool Edit = false;
            bool Delete = false;
            if (Counter > 1)
            {
                while (true)
                {
                    Console.Write("whta you want to do (1=edit 2=delet):");
                    string Choise = Console.ReadLine();
                    if (int.TryParse(Choise, out int option) && Convert.ToInt32(Choise) > 0 && Convert.ToInt32(Choise) < 3)
                    {
                        if (option == 1)
                        {
                            Edit = true;
                            break;
                        }
                        if (option == 2)
                        {
                            Delete = true;
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("this input is wrong !!!");
                    }
                }
            }

            if (Edit)
            {
                Console.Write("enter number of incom you want to edit:");
                string NumOfEdit = Console.ReadLine();
                if (int.TryParse(NumOfEdit, out int numofedit) && Convert.ToInt32(NumOfEdit) > 0 && Convert.ToInt32(NumOfEdit) <= Counter - 1)
                {
                    int z = 0;
                    int counter = 1;
                    for (; z < transactions.Count; z++)
                    {
                        string CutDate = incoms[z, 2].Substring(0, 10);

                        if (CutDate == date)
                        {
                            if (counter == numofedit)
                            {
                                OldAmount = Convert.ToDecimal(incoms[z, 0]);
                                OldDescription = incoms[z, 3];
                                OldSource = incoms[z, 1];
                                OldDate = incoms[z, 2];
                            }
                            counter++;
                        }

                    }

                    Transactions EditIncom = new Transactions();
                    EditIncom.InitializeIncom(out EditAmoun, out Editesource, out EditeDate, out EditeDescription, out NotEnter);

                }
                else
                {
                    Console.WriteLine("your input is wrong!!!");
                }





            }







            int IncomCounter = 0;
            foreach (var transaction in transactions)
            {
                if (incoms[IncomCounter, 0] == Convert.ToString(OldAmount) && incoms[IncomCounter, 1] == OldSource && incoms[IncomCounter, 2] == OldDate && incoms[IncomCounter, 3] == OldDescription)
                {
                    if (!NotEnter)
                    {
                        incoms[IncomCounter, 0] = Convert.ToString(EditAmoun);
                        incoms[IncomCounter, 1] = Editesource;
                        incoms[IncomCounter, 2] = EditeDate;
                        incoms[IncomCounter, 3] = EditeDescription;
                        break;
                    }
                    if (NotEnter)
                    {
                        incoms[IncomCounter, 0] = Convert.ToString(OldAmount);
                        incoms[IncomCounter, 1] = OldSource;
                        incoms[IncomCounter, 2] = OldDate;
                        incoms[IncomCounter, 3] = OldDescription;
                        break;
                    }

                }
                IncomCounter++;
            }



            int t = 0;
            foreach (var transaction in transactions)
            {
                transaction.Amount = Convert.ToDecimal(incoms[t, 0]);
                transaction.Source = incoms[t, 1];
                transaction.Date = incoms[t, 2];
                transaction.Description = incoms[t, 3];
                t++;

            }








            if (Delete)
            {
                Console.Write("enter number of incom you want to delete:");
                string NumOfDelete = Console.ReadLine();
                if (int.TryParse(NumOfDelete, out int numfordelete) && numfordelete > 0 && numfordelete < Counter)
                {
                    int delIndex = -1;
                    int tempCounter = 1;
                    for (int j = 0; j < transactions.Count; j++)
                    {
                        if (transactions[j].Date.Substring(0, 10) == date)
                        {
                            if (tempCounter == numfordelete)
                            {
                                delIndex = j;
                                break;
                            }
                            tempCounter++;
                        }
                    }

                    if (delIndex != -1)
                    {
                        transactions.RemoveAt(delIndex);
                        Console.WriteLine("Transaction deleted successfully.");
                    }
                }
                else
                {
                    Console.WriteLine("your input is wrong!!!");
                }
            }

            string updatedJson = JsonConvert.SerializeObject(transactions, Formatting.Indented);
            File.WriteAllText(TransactionIncomFilepath, updatedJson);


        }











        public static void EditCost(string date)
        {
            decimal OldAmount = 0;
            string OldDescription = "";
            string OldDate = "";
            string OldCategory = "";
            bool NotEnter = false;


            decimal EditAmoun = 0;
            string EditeDate = "";
            string EditeCategory = "";
            string EditeDescription = "";



            if (!File.Exists(TransactionCostFilepath))
            {
                Console.WriteLine("incom datebase not found");
                return;
            }

            string json = File.ReadAllText(TransactionCostFilepath);
            List<EnterCost> transactions = JsonConvert.DeserializeObject<List<EnterCost>>(json) ?? new List<EnterCost>();



            if (transactions.Count == 0)
            {
                Console.SetCursorPosition(0, 11);
                Console.WriteLine("No incom found");
                return;
            }



            string[,] incoms = new string[transactions.Count, 4];

            int i = 0;
            foreach (var transaction in transactions)
            {
                for (int h = 0; h < 4;)
                {
                    incoms[i, h] = $"{transaction.Amount}";
                    h++;
                    incoms[i, h] = $"{transaction.Category}";
                    h++;
                    incoms[i, h] = $"{transaction.Date}";
                    h++;
                    incoms[i, h] = $"{transaction.Description}";
                    h++;

                }

                i++;
            }





            Console.SetCursorPosition(0, 11);
            Console.WriteLine("Cost list:");

            int r = 0;
            int Counter = 1;
            for (; r < transactions.Count; r++)
            {
                string CutDate = incoms[r, 2].Substring(0, 10);

                if (CutDate == date)
                {
                    Console.WriteLine($"{Counter}={incoms[r, 2]}  {incoms[r, 0]}  {incoms[r, 1]}  {incoms[r, 3]}    ");
                    Counter++;
                }

            }

            if (Counter == 1)
            {
                Console.WriteLine("in this date no foud any Cost");
            }









            bool Edit = false;
            bool Delete = false;
            if (Counter > 1)
            {
                while (true)
                {
                    Console.Write("whta you want to do (1=edit 2=delet):");
                    string Choise = Console.ReadLine();
                    if (int.TryParse(Choise, out int option) && Convert.ToInt32(Choise) > 0 && Convert.ToInt32(Choise) < 3)
                    {
                        if (option == 1)
                        {
                            Edit = true;
                            break;
                        }
                        if (option == 2)
                        {
                            Delete = true;
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("this input is wrong !!!");
                    }
                }
            }

            if (Edit)
            {
                Console.Write("enter number of incom you want to edit:");
                string NumOfEdit = Console.ReadLine();
                if (int.TryParse(NumOfEdit, out int numofedit) && Convert.ToInt32(NumOfEdit) > 0 && Convert.ToInt32(NumOfEdit) <= Counter - 1)
                {
                    int z = 0;
                    int counter = 1;
                    for (; z < transactions.Count; z++)
                    {
                        string CutDate = incoms[z, 2].Substring(0, 10);

                        if (CutDate == date)
                        {
                            if (counter == numofedit)
                            {
                                OldAmount = Convert.ToDecimal(incoms[z, 0]);
                                OldDescription = incoms[z, 3];
                                OldCategory = incoms[z, 1];
                                OldDate = incoms[z, 2];
                            }
                            counter++;
                        }

                    }

                    Transactions EditCost = new Transactions();
                    EditCost.InitializeCost(out EditAmoun, out EditeCategory, out EditeDate, out EditeDescription, out NotEnter);

                }
                else
                {
                    Console.WriteLine("your input is wrong!!!");
                }





            }







            int IncomCounter = 0;
            foreach (var transaction in transactions)
            {
                if (incoms[IncomCounter, 0] == Convert.ToString(OldAmount) && incoms[IncomCounter, 1] == OldCategory && incoms[IncomCounter, 2] == OldDate && incoms[IncomCounter, 3] == OldDescription)
                {
                    if (!NotEnter)
                    {
                        incoms[IncomCounter, 0] = Convert.ToString(EditAmoun);
                        incoms[IncomCounter, 1] = EditeCategory;
                        incoms[IncomCounter, 2] = EditeDate;
                        incoms[IncomCounter, 3] = EditeDescription;
                        break;
                    }
                    if (NotEnter)
                    {
                        incoms[IncomCounter, 0] = Convert.ToString(OldAmount);
                        incoms[IncomCounter, 1] = OldCategory;
                        incoms[IncomCounter, 2] = OldDate;
                        incoms[IncomCounter, 3] = OldDescription;
                        break;
                    }

                }
                IncomCounter++;
            }



            int t = 0;
            foreach (var transaction in transactions)
            {
                transaction.Amount = Convert.ToDecimal(incoms[t, 0]);
                transaction.Category = incoms[t, 1];
                transaction.Date = incoms[t, 2];
                transaction.Description = incoms[t, 3];
                t++;

            }








            if (Delete)
            {
                Console.Write("enter number of incom you want to delete:");
                string NumOfDelete = Console.ReadLine();
                if (int.TryParse(NumOfDelete, out int numfordelete) && numfordelete > 0 && numfordelete < Counter)
                {
                    int delIndex = -1;
                    int tempCounter = 1;
                    for (int j = 0; j < transactions.Count; j++)
                    {
                        if (transactions[j].Date.Substring(0, 10) == date)
                        {
                            if (tempCounter == numfordelete)
                            {
                                delIndex = j;
                                break;
                            }
                            tempCounter++;
                        }
                    }

                    if (delIndex != -1)
                    {
                        transactions.RemoveAt(delIndex);
                        Console.WriteLine("Transaction deleted successfully.");
                    }
                }
                else
                {
                    Console.WriteLine("your input is wrong!!!");
                }
            }

            string updatedJson = JsonConvert.SerializeObject(transactions, Formatting.Indented);
            File.WriteAllText(TransactionCostFilepath, updatedJson);


        }



    }
}
