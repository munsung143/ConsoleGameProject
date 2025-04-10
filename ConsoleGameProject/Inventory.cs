using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

public static class Inventory
{
    private static Item[] inven;
    private static Choice choice;
    private static int input;
    private static int offset = 60;
    private static int next;
    private static bool close;

    public static void Init()
    {
        inven = new Item[10];
        choice = new Choice(60);
        next = 0;
    }
    public static void AddItem(Item item)
    {
        inven[next++] = item;
    }
    public static void DelItemAt(int index)
    {
        for (int i = index + 1; i < next; i++)
        {
            inven[i - 1] = inven[i];
        }
        inven[next - 1] = null;
        next--;
    }

    public static void Next()
    {
        if (input == 0)
        {
            close = true;
            Clear();
            return;
        }
        if (inven[input - 1] == null)
        {
            return;
        }
        switch (inven[input - 1].Name)
        {
            case "bb":
                DelItemAt(input - 1);
                ClearChoice();
                break;
            default:
                break;
        }

    }

    public static void Clear()
    {
        for (int i = 0; i < inven.Length + 1; i++)
        {
            Console.SetCursorPosition(offset, 7 + i);
            Console.WriteLine("                   ");
        }

    }
    
    public static void ClearChoice()
    {
        choice.Clear();
        int index;
        for (index = 0; index < inven.Length; index++)
        {
            if (inven[index] != null)
            {
                choice.Add($"     {index + 1}. {inven[index].Name}");
            }
            else
            {
                choice.Add($"     {index + 1}. -");
            }
        }
    }

    public static void Open()
    {
        close = false;
        ClearChoice();
        while (!close)
        {
            Clear();
            Console.SetCursorPosition(offset, 7);
            Console.WriteLine("[인벤토리]");
            input = choice.Start();
            Next();
        }

    }
}
