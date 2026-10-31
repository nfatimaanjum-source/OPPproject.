using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

public class ExpenseRepo
{
    private readonly string path = "ledger.txt";

    public void SaveToFile(ExpenseModel exp)
    {
        using (StreamWriter writer = new StreamWriter(path, true))
        {
            writer.WriteLine(exp.ToString());
        }
    }

    public List<ExpenseModel> LoadFromFile()
    {
        List<ExpenseModel> list = new List<ExpenseModel>();
        if (File.Exists(path))
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 3)
                    {
                        string name = parts[0];
                        float cost = float.Parse(parts[1]);
                        string cat = parts[2];
                        list.Add(new ExpenseModel(name, cost, cat));
                    }
                }
            }
        }
        return list;
    }

    public void SaveAllData(List<ExpenseModel> list)
    {
        File.WriteAllText(path, string.Empty); 
        foreach (var exp in list)
        {
            SaveToFile(exp);
        }
    }
}
