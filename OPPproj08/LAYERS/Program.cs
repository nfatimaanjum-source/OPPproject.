using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Program
{
    public static void Main(string[] args)
    {
        ExpenseService service = new ExpenseService();
        int choice = 0;

        while (choice != 10)
        {
            Console.Clear();
            ExpenseUI.ShowMenu();

            string input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input))
            {
                choice = int.Parse(input);
            }
            else
            {
                choice = 0;
            }

            switch (choice)
            {
                case 1:
                    ExpenseUI.AddUI(service);
                    break;
                case 2:
                    ExpenseUI.ViewUI(service);
                    break;
                case 3:
                    ExpenseUI.SearchUI(service);
                    break;
                case 4:
                    ExpenseUI.UpdateUI(service);
                    break;
                case 5:
                    ExpenseUI.DeleteUI(service);
                    break;
                case 6:
                    ExpenseUI.TotalUI(service);
                    break;
                case 7:
                    ExpenseUI.BudgetUI(service);
                    break;
                case 8:
                    ExpenseUI.ForecastUI(service);
                    break;
                case 9:
                    ExpenseUI.CatBudgetUI(service);
                    break;
                case 10:
                    ExpenseUI.ExitUI();
                    break;
                default:
                    Console.WriteLine("\n\t ---------------------------------------");
                    Console.WriteLine("\n\t Invalid selection. Please try again.");
                    Console.WriteLine("\n\t ---------------------------------------");
                    Console.Write("\n\n\t Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
        }
    }
}
