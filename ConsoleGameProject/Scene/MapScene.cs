using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class MapScene : Scene
{
    protected string[] map;
    protected List<MapObject> mapObjects;
    protected ConsoleKey key;
    protected PlayerObject player;
    protected MapObject pickedUpObject;
    public abstract void PortalInit();
}
