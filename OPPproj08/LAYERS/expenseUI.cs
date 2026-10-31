using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class ExpenseUI
{
    public static void ShowMenu()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n\t\t================================");
        Console.WriteLine("\t\t          .---.   ");
        Console.WriteLine("\t\t          |   |   ");
        Console.WriteLine("\t\t       ___|___|___");
        Console.WriteLine("\t\t      |           |");
        Console.WriteLine("\t\t      |    [#]    |");
        Console.WriteLine("\t\t      |___________|");
        Console.WriteLine("\n\t\t================================");

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("\t\t|      POCKET-VAULT SYSTEM      |");

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\t\t================================");

        Console.WriteLine("\n\t 1.  Log New Expense");
        Console.WriteLine("\t 2.  View Ledger");
        Console.WriteLine("\t 3.  Search Transaction");
        Console.WriteLine("\t 4.  Update Cost Entry");
        Console.WriteLine("\t 5.  Delete Entry");
        Console.WriteLine("\t 6.  Total Spending");
        Console.WriteLine("\t 7.  Total Budget Check");
        Console.WriteLine("\t 8.  Yearly Forecast");
        Console.WriteLine("\t 9.  Category Budget Check");
        Console.WriteLine("\t 10. Exit System");
        Console.WriteLine("\t\t================================");

        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.Write("\n\t Selection > ");
        Console.ResetColor();
    }

    public static void AddUI(ExpenseService service)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("\n\t ------------ LOG NEW EXPENSES ------------");
        Console.ResetColor();

        if (service.GetList().Count >= service.max)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\t --- VAULT FULL! ---");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\n\t Enter item name  : ");
            Console.ResetColor();
            string name = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\n\t Enter total cost : ");
            Console.ResetColor();
            float cost = float.Parse(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\n\t Enter category   : ");
            Console.ResetColor();
            string cat = Console.ReadLine();

            bool added = service.AddExpense(name, cost, cat);
            if (added)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n\t --- Successfully added! ---");
                Console.ResetColor();
            }
        }
        Console.Write("\n\n\t Press any key to continue...");
        Console.ReadKey();
    }

    public static void ViewUI(ExpenseService service)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("\n\t --- VIEW LEDGER ---\n");
        Console.ResetColor();

        var list = service.GetList();
        if (list.Count == 0)
        {
            Console.WriteLine("\n\t No entries found.");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\t ID\t ITEM NAME\t\t COST\t\t CATEGORY");
            Console.ResetColor();
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"\t {i + 1}\t\t {list[i].GetName()}\t\t {list[i].GetCost()}\t\t {list[i].GetCat()}");
            }
        }
        Console.Write("\n\t Press any key to continue...");
        Console.ReadKey();
    }

    public static void SearchUI(ExpenseService service)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("\n\t --- SEARCH TRANSACTION ---");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("\n\t Enter name to search : ");
        Console.ResetColor();
        string name = Console.ReadLine();

        List<int> ids = service.SearchExpense(name);
        var list = service.GetList();

        if (ids.Count > 0)
        {
            foreach (int i in ids)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n\t Found : {list[i].GetName()} at ID: {i + 1}");
                Console.ResetColor();
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\t Not found!");
            Console.ResetColor();
        }
        Console.Write("\n\n\t Press any key to continue...");
        Console.ReadKey();
    }

    public static void UpdateUI(ExpenseService service)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("\n\t --- UPDATE ENTRY ---");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("\n\t Enter ID to update : ");
        Console.ResetColor();

        int id = int.Parse(Console.ReadLine());
        var list = service.GetList();

        if (id > 0 && id <= list.Count)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"\n\t Enter new cost for {list[id - 1].GetName()} : ");
            Console.ResetColor();

            float cost = float.Parse(Console.ReadLine());
            service.UpdateExpense(id, cost);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\t !UPDATED!");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\t INVALID ID.");
            Console.ResetColor();
        }
        Console.Write("\n\n\t Press any key to continue...");
        Console.ReadKey();
    }

    public static void DeleteUI(ExpenseService service)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("\n\t --- DELETE ENTRY ---");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("\n\t Enter ID to delete : ");
        Console.ResetColor();

        int id = int.Parse(Console.ReadLine());
        bool deleted = service.DeleteExpense(id);

        if (deleted)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\t !DELETED!");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\t INVALID ID.");
            Console.ResetColor();
        }
        Console.Write("\n\n\t Press any key to continue...");
        Console.ReadKey();
    }

    public static void TotalUI(ExpenseService service)
    {
        Console.Clear();
        float total = service.GetTotalSpending();

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("\n\t --- TOTAL SPENDING ---");
        Console.ResetColor();
        Console.WriteLine($"\n\t Total Spending : Rs. {total}");
        Console.Write("\n\n\t Press any key to continue...");
        Console.ReadKey();
    }

    public static void BudgetUI(ExpenseService service)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("\n\t --- BUDGET CHECK ---");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("\n\t Enter your total limited budget: ");
        Console.ResetColor();
        float limit = float.Parse(Console.ReadLine());

        bool under = service.CheckTotalBudget(limit);

        if (under)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" \n\t  GOOD JOB : You are under budget! :D");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" \n\t WARNING ! : You are over budget! :C");
        }
        Console.ResetColor();
        Console.Write("\n\n\t Press any key to continue...");
        Console.ReadKey();
    }

    public static void ForecastUI(ExpenseService service)
    {
        Console.Clear();
        float total = service.GetYearlyForecast();

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("\n\t --- YEARLY FORECAST ---");
        Console.ResetColor();
        Console.WriteLine($"\n\t Yearly estimate (based on current entries): Rs. {total}");
        Console.Write("\n\n\t Press any key to continue...");
        Console.ReadKey();
    }

    public static void CatBudgetUI(ExpenseService service)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("\n\t --- CATEGORY BUDGET CHECK ---");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("\n\t Enter category (e.g., Food, Fees): ");
        Console.ResetColor();
        string cat = Console.ReadLine();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write($"\t Enter your budget limit for {cat}: Rs. ");
        Console.ResetColor();
        float limit = float.Parse(Console.ReadLine());

        var res = service.CheckCategoryBudget(cat, limit);

        Console.WriteLine($"\n\t Total spent on {cat}: Rs. {res.spent}");
        if (res.under)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n\t GOOD JOB: You are under budget for {cat}! :D");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n\t WARNING: You overspent on {cat}! :C");
        }
        Console.ResetColor();
        Console.Write("\n\n\t Press any key to continue...");
        Console.ReadKey();
    }

    public static void ExitUI()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("\n\t Exiting system... Goodbye!");
        Console.ResetColor();
    }
}

