using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financial_Management_System
{
    internal class Categories
    {
        public string[] Category;




        public void ShowCategories()
        {

            ObjectJson.ShowCategory(0, 14);

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


        public void AddCategories()
        {
            bool Add = true;
            while (Add)
            {
                Console.Write("enter your custom category name:");
                string CustonCategory = Console.ReadLine();


                foreach (Char letter in CustonCategory)
                {
                    if (letter == Convert.ToChar(" "))
                    {
                        Add = false;

                        Console.Clear();
                        Console.WriteLine("your can not use space \" \" in your category name ");
                        Console.WriteLine();
                        break;
                    }
                }

                if (CustonCategory.Length > 0 && !int.TryParse(CustonCategory, out int wrongcategory) && Add)
                {
                    while (true)
                    {
                        Console.Write($"Do you want to add a category ({CustonCategory}) 1=yes 2=no?");
                        string add = Console.ReadLine();
                        if (int.TryParse(add, out int addUser) && Convert.ToInt32(add) == 1)
                        {
                            ObjectJson.AddCategory(CustonCategory);
                            break;
                        }
                        if (int.TryParse(add, out int back) && Convert.ToInt32(add) == 2)
                        {
                            Console.Clear();
                            break;

                        }
                        else
                        {
                            Console.WriteLine("your input is wrong !!!");
                        }

                    }
                }
                else
                {
                    Console.WriteLine("your input in null OR not string");
                }

                break;

            }


            
            Console.WriteLine("CATEGORIES:");
            ObjectJson.ShowCategory(0, 3);
            Console.WriteLine();

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
