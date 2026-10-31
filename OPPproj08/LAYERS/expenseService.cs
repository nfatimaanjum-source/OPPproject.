using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class ExpenseService
{
    private ExpenseRepo repo;
    private List<ExpenseModel> list;
    public int max = 100;

    public ExpenseService()
    {
        repo = new ExpenseRepo();
        list = repo.LoadFromFile();
    }

    public List<ExpenseModel> GetList()
    {
        return repo.LoadFromFile();
    }

    public bool AddExpense(string name, float cost, string cat)
    {
        list = repo.LoadFromFile();
        if (list.Count >= max) return false;

        ExpenseModel newExp = new ExpenseModel(name, cost, cat);
        list.Add(newExp);
        repo.SaveToFile(newExp);
        return true;
    }

    public List<int> SearchExpense(string name)
    {
        list = repo.LoadFromFile();
        List<int> ids = new List<int>();
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].GetName().Equals(name, StringComparison.OrdinalIgnoreCase))
            {
                ids.Add(i);
            }
        }
        return ids;
    }

    public bool UpdateExpense(int id, float newCost)
    {
        list = repo.LoadFromFile();
        if (id > 0 && id <= list.Count)
        {
            list[id - 1].SetCost(newCost);
            repo.SaveAllData(list);
            return true;
        }
        return false;
    }

    public bool DeleteExpense(int id)
    {
        list = repo.LoadFromFile();
        if (id > 0 && id <= list.Count)
        {
            list.RemoveAt(id - 1);
            repo.SaveAllData(list);
            return true;
        }
        return false;
    }

    public float GetTotalSpending()
    {
        list = repo.LoadFromFile();
        float total = 0;
        foreach (var e in list) total += e.GetCost();
        return total;
    }

    public bool CheckTotalBudget(float limit)
    {
        return GetTotalSpending() <= limit;
    }

    public float GetYearlyForecast()
    {
        return GetTotalSpending() * 12;
    }

    public (float spent, bool under) CheckCategoryBudget(string cat, float limit)
    {
        list = repo.LoadFromFile();
        float sum = 0;
        foreach (var e in list)
        {
            if (e.GetCat().Equals(cat, StringComparison.OrdinalIgnoreCase))
            {
                sum += e.GetCost();
            }
        }
        return (sum, sum <= limit);
    }
}

