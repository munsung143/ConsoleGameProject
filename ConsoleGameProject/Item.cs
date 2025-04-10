using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Item
{
    private string name;
    public string Name { get { return name; } }

    public Item(string name)
    {
        this.name = name;
    }
}