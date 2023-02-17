using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDL2;
using Monster.ECS;
using System.Numerics;
using static Monster.Game;
using MenuMonster.Menu;

namespace Monster
{
    public class Game
    {
        public static SDL.SDL_Rect camera;
        public static bool isRunning;
        //private IntPtr window;
        public App app = new App();
        //public static IntPtr renderer;
        private Map map;
        private static Manager manager;
        private Entity Player;
        public static LoadContent lo;
        private List<ColliderComponent> colliders;
        public enum GroupLabels : int
        {
            groupMap,
            groupPlayers,
            groupEnemies,
            groupColliders,
            groupShoots
        }
        private List<Entity> players;
        private List<Entity> tiles;
        private List<Entity> enemies;
        private List<Entity> Shoots;
        public Game()
        {

        }
        public void init(String title, int xpos, int ypos, int width, int height, bool fullscreen)
        {
            camera.x = camera.y = 0;
            camera.w = 800; camera.h = 640;
            /*var flags= (uint)SDL.SDL_WindowFlags.SDL_WINDOW_FULLSCREEN;
			if (fullscreen)
			{
				SDL.SDL_SetWindowFullscreen(window, (uint)SDL.SDL_WindowFlags.SDL_WINDOW_FULLSCREEN);// fullscrean
			}*/
            if (SDL.SDL_Init(SDL.SDL_INIT_EVERYTHING) == 0)
            {
                Console.WriteLine("Subsystem Inititalised");
                app.Window = Menu.app.Window;

                {
                    Console.WriteLine("Window created");
                }
                App.Renderer = App.Renderer;
                if (App.Renderer != IntPtr.Zero)
                {
                    SDL.SDL_SetRenderDrawColor(App.Renderer, 255, 255, 255, 255);
                    Console.WriteLine("Renderer created");
                }
                isRunning = true;
            }
            else
            {
                isRunning = false;
            }
            colliders = new List<ColliderComponent>();
            manager = new Manager();
            lo = new LoadContent(App.Renderer);
            map = new Map(App.Renderer, lo);
            map.LoadMap("Assest\\map01.txt", 70, 70);
            // Entity
            Player = manager.AddEntity();
            // player Component
            Player.AddComponent<TransformComponent>(2, 50, 300);
            Player.AddComponent<SpriteComponent>(lo.player_idle, App.Renderer, true);
            Player.AddComponent<KeyboardController>();
            Player.AddComponent<ColliderComponent>("Player", colliders);
            Player.AddGroup(GroupLabels.groupPlayers);
            // Enemy Component 
            Entity enemy = manager.AddEntity();
            enemy.AddComponent<TransformComponent>(2, 500, 200);
            enemy.AddComponent<SpriteComponent>(lo.enemy, App.Renderer, true);
            enemy.AddComponent<EnemyComponent>(enemy.GetComponent<TransformComponent>(), Player);
            enemy.AddGroup(GroupLabels.groupEnemies);

            Entity enemy1 = manager.AddEntity();
            enemy1.AddComponent<TransformComponent>(2, 450, 50);
            enemy1.AddComponent<SpriteComponent>(lo.enemy, App.Renderer, true);
            enemy1.AddComponent<EnemyComponent>(enemy1.GetComponent<TransformComponent>(), Player);
            enemy1.AddGroup(GroupLabels.groupEnemies);

            Entity enemy2 = manager.AddEntity();
            enemy2.AddComponent<TransformComponent>(2, 700, 30);
            enemy2.AddComponent<SpriteComponent>(lo.enemy, App.Renderer, true);
            enemy2.AddComponent<EnemyComponent>(enemy2.GetComponent<TransformComponent>(), Player);
            enemy2.AddGroup(GroupLabels.groupEnemies);

            Entity enemy3 = manager.AddEntity();
            enemy3.AddComponent<TransformComponent>(2, 700, 500);
            enemy3.AddComponent<SpriteComponent>(lo.enemy, App.Renderer, true);
            enemy3.AddComponent<EnemyComponent>(enemy3.GetComponent<TransformComponent>(), Player);
            enemy3.AddGroup(GroupLabels.groupEnemies);

            Entity enemy4 = manager.AddEntity();
            enemy4.AddComponent<TransformComponent>(2, 700, 1000);
            enemy4.AddComponent<SpriteComponent>(lo.enemy, App.Renderer, true);
            enemy4.AddComponent<EnemyComponent>(enemy4.GetComponent<TransformComponent>(), Player);
            enemy4.AddGroup(GroupLabels.groupEnemies);

            //Entity List 
            players = manager.GetGroup(GroupLabels.groupPlayers);
            tiles = manager.GetGroup(GroupLabels.groupMap);
            enemies = manager.GetGroup(GroupLabels.groupEnemies);
            Shoots = manager.GetGroup(GroupLabels.groupShoots);

        }

        public void handleEvent()
        {
            if (App.Keyboard[(int)SDL.SDL_Scancode.SDL_SCANCODE_F])
            {
                App.Keyboard[(int)SDL.SDL_Scancode.SDL_SCANCODE_F] = false;
                int flags = (int)SDL.SDL_GetWindowFlags(app.Window);
                if ((flags & (int)SDL.SDL_WindowFlags.SDL_WINDOW_FULLSCREEN_DESKTOP) == (int)SDL.SDL_WindowFlags.SDL_WINDOW_FULLSCREEN_DESKTOP)
                {
                    SDL.SDL_SetWindowFullscreen(app.Window, 0);
                }
                else
                {
                    SDL.SDL_SetWindowFullscreen(app.Window, (int)SDL.SDL_WindowFlags.SDL_WINDOW_FULLSCREEN_DESKTOP);
                }
            }
        }

        public void Update()
        {
            Collision c = new Collision();
            manager.Refresh();
            manager.Update();


            camera.x = (int)Player.GetComponent<TransformComponent>().position.x - 400;
            camera.y = (int)Player.GetComponent<TransformComponent>().position.y - 320;
            if (camera.x < 0)
                camera.x = 0;
            if (camera.y < 0)
                camera.y = 0;
            if (camera.x > camera.w)
                camera.x = camera.w;
            if (camera.y > camera.h)
                camera.y = camera.h;



        }
        public static void AddTile(int srcX, int srcY, int x, int y)
        {
            String s = "Assest\\terrain_ss.png";
            Entity tile0 = manager.AddEntity();
            tile0.AddComponent<TileComponent>(srcX, srcY, x, y, s, App.Renderer);
            tile0.AddGroup(GroupLabels.groupMap);

        }
        public void render()
        {
            SDL.SDL_RenderClear(App.Renderer);
            foreach (var t in tiles)
                t.Draw();
            foreach (var p in players)
                p.Draw();
            foreach (var e in enemies)
                e.Draw();
            foreach (var s in Shoots)
                s.Draw();
            SDL.SDL_RenderPresent(App.Renderer);
        }
        public void clean()
        {
            SDL.SDL_DestroyRenderer(App.Renderer);
            SDL.SDL_DestroyWindow(app.Window);
            SDL.SDL_Quit();
            Console.WriteLine("Game cleaned");
        }
        public bool running() { return isRunning; }
    }
}
