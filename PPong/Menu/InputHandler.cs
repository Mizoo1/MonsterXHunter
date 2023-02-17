using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monster;
using SDL2;

namespace MenuMonster.Menu
{
    public class InputHandler
    {
        public static void HandleInput()
        {
            Logic();
        }

        private static void HandleKeyboardInput()
        {
            if (App.Keyboard == null)
            {
                App.Keyboard = new bool[(int)SDL.SDL_Scancode.SDL_NUM_SCANCODES];
            }
            if (App.Keyboard[(int)SDL.SDL_Scancode.SDL_SCANCODE_UP])
            {
                App.Keyboard[(int)SDL.SDL_Scancode.SDL_SCANCODE_UP] = false;
                Menu.app.ActiveWidget = Menu.app.ActiveWidget.Prev;
                if (Menu.app.ActiveWidget == null)
                {
                    Menu.app.ActiveWidget = Menu.widgetTail;
                }
            }

            if (App.Keyboard[(int)SDL.SDL_Scancode.SDL_SCANCODE_DOWN])
            {
                App.Keyboard[(int)SDL.SDL_Scancode.SDL_SCANCODE_DOWN] = false;
                Menu.app.ActiveWidget = Menu.app.ActiveWidget.Next;
                if (Menu.app.ActiveWidget == null)
                {
                    Menu.app.ActiveWidget = Menu.widgetHead.Next;
                }
            }
                
            if (App.Keyboard[(int)SDL.SDL_Scancode.SDL_SCANCODE_F])
            {
                App.Keyboard[(int)SDL.SDL_Scancode.SDL_SCANCODE_F] = false;
                int flags = (int)SDL.SDL_GetWindowFlags(Menu.app.Window);
                if ((flags & (int)SDL.SDL_WindowFlags.SDL_WINDOW_FULLSCREEN_DESKTOP) == (int)SDL.SDL_WindowFlags.SDL_WINDOW_FULLSCREEN_DESKTOP)
                {
                    SDL.SDL_SetWindowFullscreen(Menu.app.Window, 0);
                }
                else
                {
                    SDL.SDL_SetWindowFullscreen(Menu.app.Window, (int)SDL.SDL_WindowFlags.SDL_WINDOW_FULLSCREEN_DESKTOP);
                }
            }
        }
        private static void HandleMenuNavigation()
        {
            if (App.Keyboard[(int)SDL.SDL_Scancode.SDL_SCANCODE_RETURN] && Menu.app.ActiveWidget.Label == "Start")
            {
                App.Keyboard[(int)SDL.SDL_Scancode.SDL_SCANCODE_RETURN] = false;
                //Console.WriteLine("Start Menu");
                const int FPS = 60;
                const int frameDelay = 1000 / FPS;
                UInt32 frameStart;
                int frameTime;
                Game game = new Game();
                game.init("Monster", SDL.SDL_WINDOWPOS_CENTERED, SDL.SDL_WINDOWPOS_CENTERED, 800, 600, true);
                while (game.running())
                {
                    frameStart = SDL.SDL_GetTicks();
                    // Handle input
                    game.handleEvent();
                    // Update the game state
                    game.Update();
                    // Display the game state
                    game.render();
                    frameTime = (int)(SDL.SDL_GetTicks() - frameStart);
                    if (frameDelay > frameTime)
                    {
                        SDL.SDL_Delay((uint)(frameDelay - frameTime));
                    }
                }
                game.clean();
            }
            if (App.Keyboard[(int)SDL.SDL_Scancode.SDL_SCANCODE_RETURN] && Menu.app.ActiveWidget.Label == "Options")
            {
                App.Keyboard[(int)SDL.SDL_Scancode.SDL_SCANCODE_RETURN] = false;
                Menu.DrawSubMenu();
            }
            if (App.Keyboard[(int)SDL.SDL_Scancode.SDL_SCANCODE_RETURN] && Menu.app.ActiveWidget.Label == "Back")
            {
                App.Keyboard[(int)SDL.SDL_Scancode.SDL_SCANCODE_RETURN] = false;
                Menu.InitWidgets();
                Menu.InitDemo();
            }
            if (App.Keyboard[(int)SDL.SDL_Scancode.SDL_SCANCODE_RETURN] && Menu.app.ActiveWidget.Label == "Sound")
            {
                App.Keyboard[(int)SDL.SDL_Scancode.SDL_SCANCODE_RETURN] = false;
                Menu.DrawSubsubMenu();
                Menu.ClearAndDrawSubmenu(Menu.DrawSubsubMenu);
            }
            if (App.Keyboard[(int)SDL.SDL_Scancode.SDL_SCANCODE_RETURN] && Menu.app.ActiveWidget.Label == "Back")
            {
                App.Keyboard[(int)SDL.SDL_Scancode.SDL_SCANCODE_RETURN] = false;
                if (Menu.app.ActiveWidget.Index == 1)
                {
                    Menu.DrawSubMenu();
                }
                else if (Menu.app.ActiveWidget.Index == 2)
                {
                    Menu.ClearAndDrawSubmenu(Menu.DrawSubMenu);
                }
            }
            if (App.Keyboard[(int)SDL.SDL_Scancode.SDL_SCANCODE_RETURN] && Menu.app.ActiveWidget.Label == "Exit")
            {
                Environment.Exit(0);
            }
        }
        public  static void Logic()
        {
            HandleKeyboardInput();
            HandleMenuNavigation();
        }
        public static void DoInput()
        {
            SDL.SDL_Event e;
            while (SDL.SDL_PollEvent(out e) != 0)
            {
                if (e.type == SDL.SDL_EventType.SDL_QUIT)
                {
                    Environment.Exit(0);
                }
                else if (e.type == SDL.SDL_EventType.SDL_KEYDOWN)
                {
                    App.Keyboard[(int)e.key.keysym.scancode] = true;
                }
                else if (e.type == SDL.SDL_EventType.SDL_KEYUP)
                {
                    App.Keyboard[(int)e.key.keysym.scancode] = false;
                }
            }
        }
    }
}
