using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

// 인벤토리 클래스입니다.
public static class Inventory
{
    private static Item[] inven;
    private static Choice choice;
    private static int input;
    private static int offsetX = 60;
    private static int offsetY = 7;
    private static int next;
    private static bool close;


    // 인벤토리에는 최대 10개의 아이템을 담을 수 있습니다.
    // offsetX는 인벤토리가 좌측으로 60만큼 이동한 위치에서 열릴 것을 의미합니다.
    public static void Init()
    {
        inven = new Item[10];
        choice = new Choice(offsetX);
        next = 0;
    }

    // 인벤토리에 아이템을 추가합니다.
    public static void AddItem(Item item)
    {
        if (next < inven.Length - 1)
        {
            inven[next++] = item;
        }
    }

    // 인벤토리 특정 위치 뒤의 아이템들을 한 칸 씩 앞으로 당겨와서 그 위치의 아이템이 지워집니다.
    // 이후, 맨 뒤에 있던 아이템을 지웁니다.
    public static void DelItemAt(int index)
    {
        for (int i = index + 1; i < next; i++)
        {
            inven[i - 1] = inven[i];
        }
        inven[next - 1] = null;
        next--;
    }

    // 인벤토리 내의 선택 결과에 따른 다음 행동을 결정합니다.
    public static void Next()
    {
        // esc를 눌렀을 경우 인벤토리를 나갑니다.
        if (input == 0)
        {
            close = true;
            Clear();
            return;
        }
        // 아무 아이템이 없을 경우 아무 행동을 안합니다.
        if (inven[input - 1] == null)
        {
            return;
        }
        inven[input - 1].Effect();
        if (inven[input - 1].Counsumable == true)
        {
            DelItemAt(input - 1);
            ClearChoice();
        }
        // 플레이어 정보를 재출력하여 반영된 효과를 확인합니다.
        Game.Me.PrintInfo();

    }

    // 인벤토리가 출력될 위치를 비웁니다.
    public static void Clear()
    {
        for (int i = 0; i < inven.Length + 1; i++)
        {
            Console.SetCursorPosition(offsetX, offsetY + i);
            Console.WriteLine("                         ");
        }

    }
    
    // 인벤토리 선택지를 갱신합니다.
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

    // 인벤토리를 엽니다.
    public static void Open()
    {
        close = false;
        ClearChoice();
        while (!close)
        {
            Clear();
            Console.SetCursorPosition(offsetX, 7);
            Console.WriteLine("[인벤토리]");
            input = choice.Start();
            Next();
        }

    }
}
