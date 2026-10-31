using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ExpenseModel
{
    private string iname;
    private float icost;
    private string icat;

    public ExpenseModel(string name, float cost, string cat)
    {
        iname = name;
        icost = cost;
        icat = cat;
    }

   
    public string GetName() => iname;
    public void SetName(string name) => iname = name;

    public float GetCost() => icost;
    public void SetCost(float cost) => icost = cost;

    public string GetCat() => icat;
    public void SetCat(string cat) => icat = cat;

    public override string ToString()
    {
        return $"{iname},{icost},{icat}";
    }
}
