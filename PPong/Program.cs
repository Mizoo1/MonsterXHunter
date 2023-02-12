using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SDL2;

namespace Monster
{
    static class Program
    {
        static void Main(string[] args)
        {
            const int FPS = 60;
            const int frameDelay = 1000 / FPS;
            UInt32 frameStart;
            int frameTime;
            Game game = new Game();
            game.init("Monster", SDL.SDL_WINDOWPOS_CENTERED, SDL.SDL_WINDOWPOS_CENTERED, 800,600,true);
            while (game.running())
            {
                frameStart=SDL.SDL_GetTicks();
				// Handle input
				game.handleEvent();
				// Update the game state
				game.Update();
				// Display the game state
				game.render();
                frameTime = (int)(SDL.SDL_GetTicks() - frameStart);
                if (frameDelay> frameTime)
                {
                    SDL.SDL_Delay((uint)(frameDelay - frameTime));
                }
			}
            game.clean();
        }
        
    }
}




