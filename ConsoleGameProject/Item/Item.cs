using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Item
{
    protected string name;
    public string Name { get { return name; } }
    protected bool consumable = false;
    public bool Counsumable { get { return consumable; } }
    public abstract void Effect();
}