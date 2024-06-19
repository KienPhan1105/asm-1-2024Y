using System.Diagnostics;

namespace _1_test_asm_function
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {

                Console.Write("Customer Name: ");
                string CustomerName = Console.ReadLine();

                double consumption = CustomerInformation();
              

                ShowMenu();
                int CustomerType = choice();

                double price = CalculatePrice(CustomerType, consumption);


                // Environmental protection fee
                double EnF = price * 0.10;

                // VAT
                double VAT = (EnF + price) * 0.10;

                // Total bill
                double TotalBill = price + EnF + VAT;

                //  Print invoices to the screen for customers (bill)
                Console.Clear();
                Console.WriteLine("Customer Name: " + CustomerName);
                Console.WriteLine("Consumption: " + consumption + "m3");
                Console.WriteLine("TotalBill: " + TotalBill + " VND");

            }
        }

        static double CustomerInformation()
        {


            double lastmonth;
            double thismonth;
            do
            {
                Console.Write("Last month's water meter reading: ");
                while (!double.TryParse(Console.ReadLine(), out lastmonth))
                {
                    Console.Write("The data is incorrect, please re-enter: ");
                }

                Console.Write("This month's water meter reading: ");
                while (!double.TryParse(Console.ReadLine(), out thismonth))
                {
                    Console.Write("The data is incorrect, please re-enter: ");
                }
                if (lastmonth > thismonth)
                {
                    Console.WriteLine("Error");
                }

            }

            while (lastmonth > thismonth);
            {
                Console.Clear();
            }
            double consumption = thismonth - lastmonth;
            

            return consumption;
        }

        static void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("----------MENU----------");
            Console.WriteLine("CustomerType:");
            Console.WriteLine("\t 1. Household.");
            Console.WriteLine("\t 2. Government administrative agency, public services.");
            Console.WriteLine("\t 3. Production unit.");
            Console.WriteLine("\t 4. Business services.");

        }

        static int choice()
        {
            
            int CustomerType;
            while (true)
            {
                CustomerType = Convert.ToInt32(Console.ReadLine());
                if (CustomerType >= 1 && CustomerType <= 4)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid selection, please re-enter: ");
                }
            }
            return CustomerType;
        }
        static double CalculatePrice(int CustomerType, double consumption)
        {
            
            double prices = 0;
            switch (CustomerType)
            {
                case 1:
                    Console.WriteLine("HouseHold");
                    Console.Write("Enter the number of people: ");
                    int numberofusers = Convert.ToInt32(Console.ReadLine());

                    if (consumption >= 1 || consumption <= 10)
                    {
                        prices = 5973;
                    }
                    else if (consumption > 10 || consumption <= 20)
                    {
                        prices = 7052;
                    }
                    else if (consumption > 20 || consumption <= 30)
                    {
                        prices = 8669;
                    }
                    else
                        prices = 15929;
                    break;

                case 2:
                    Console.WriteLine("Government administrative agency, public services");
                    prices = 9955;
                    break;
                case 3:
                    Console.WriteLine("Production unit");
                    prices = 11615;
                    break;
                case 4:
                    Console.WriteLine("Business services");
                    prices = 22068;
                    break;
                default:
                    Console.WriteLine("Invalid selection, please re-enter");
                    Environment.Exit(0);
                    break;
                //Console.ReadLine();
            }

            double household1 = 5973;
            double household2 = 7052;
            double household3 = 8099;
            double household4 = 15929;
            double price = 0;
            if (CustomerType == 1)
            {
                if (consumption <= 10)
                {
                    price = consumption * household1;
                }
                else if (consumption <= 20)
                {
                    price = 10 * household1 + (consumption - 10) * household2;
                }
                else if (consumption <= 30)
                {
                    price = 10 * household1 + 10 * household2 + (consumption - 20) * household3;
                }
                else
                {
                    price = 10 * household1 + 10 * household2 + 10 * household3 + (consumption - 30) * household4;
                }
            }
            else
            {
                price = consumption * prices;
            }

            return price;
        }
      
       
    }

}
