using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MenuMonster.Menu;
using SDL2;

namespace Monster
{
    static class Program
    {
        static void Main(string[] args)
        {
            MenuManager menuManager = new MenuManager();
            menuManager.StartGameLoop();
        }
        
    }
}




