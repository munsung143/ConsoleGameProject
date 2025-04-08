using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class FirstMap : Map
{
    private string[] map;
    private List<MapObject> mapObjects;

    public FirstMap()
    {
        mapObjects = new List<MapObject>();
        map = new string[]
        {
            "wwwwwwwwwwwwwww",
            "w             W",
            "w             W",
            "w             W",
            "w             W",
            "w             W",
            "wwwwwwwwwwwwwwW",
        };
        for (int i = 0; i < map.Length; i++)
        {
            for (int j = 0; j < map[i].Length; j++)
            {
                if (map[i][j] == 'w')
                {
                    mapObjects.Add(new Wall(i, j));
                }
            }
        }
    }

    public override void Render()
    {


    }
    public override void Input()
    {

    }
    public override void Update()
    {

    }

}
