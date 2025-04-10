﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Scene
{
    public abstract void Render();
    public abstract void Input();
    public abstract void Update();

}