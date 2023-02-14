using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Monster.ECS;
using SDL2;

namespace Monster
{
	public class Game
	{
        public static SDL.SDL_Rect camera;
        public static bool isRunning;
		private IntPtr window;
		public static IntPtr renderer;
		private Map map;
        private static Manager manager;
        private Entity Player;
        private LoadContent lo;
        private List<ColliderComponent> colliders;
        public enum GroupLabels : int
        {
            groupMap,
            groupPlayers,
            groupEnemies,
            groupColliders
        }
        private List<Entity> players;
        private List<Entity> tiles;
        private List<Entity> enemies;
        public Game() {
			
		}
		public void init(String title ,int xpos,int ypos,int width,int height, bool fullscreen)
		{
            camera.x = camera.y = 0;
            camera.w = 800; camera.h = 640;
            /*var flags= SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN;
			if (fullscreen)
			{
				flags = SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN;// fullscrean
			}*/
            if (SDL.SDL_Init(SDL.SDL_INIT_EVERYTHING) == 0)
			{
				Console.WriteLine("Subsystem Inititalised");
				window = SDL.SDL_CreateWindow(title, xpos,ypos,width,height, SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN);
				if (window!=IntPtr.Zero)
				{
					Console.WriteLine("Window created");
				}
				renderer = SDL.SDL_CreateRenderer(window, - 1, 0);
				if (renderer != IntPtr.Zero)
				{
					SDL.SDL_SetRenderDrawColor(renderer, 255, 255, 255, 255);
					Console.WriteLine("Renderer created");
				}
				isRunning= true;
			}
			else
			{
				isRunning= false;
			}

            colliders = new List<ColliderComponent>();
            manager = new Manager();
            lo = new LoadContent(renderer);
            map = new Map(renderer, lo);
            map.LoadMap("Assest\\map01.txt", 50, 50);
            // Entity
            Player = manager.AddEntity();
            // player Component
            Player.AddComponent<TransformComponent>(2);
            Player.AddComponent<SpriteComponent>(lo.player_idle, renderer, true);
            Player.AddComponent<KeyboardController>();
            Player.AddComponent<ColliderComponent>("Player", colliders);
            Player.AddGroup(GroupLabels.groupPlayers);
            // Entity List 
            players = manager.GetGroup(GroupLabels.groupPlayers);
            tiles = manager.GetGroup(GroupLabels.groupMap);
            enemies = manager.GetGroup(GroupLabels.groupEnemies);
        }
		public void handleEvent()
		{

		}
		public void Update ()
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
            tile0.AddComponent<TileComponent>(srcX, srcY, x, y, s, renderer);
            tile0.AddGroup(GroupLabels.groupMap);

        }
        public void render () 
		{
            SDL.SDL_RenderClear(renderer);
            foreach (var t in tiles)
                t.Draw();
            foreach (var p in players)
                p.Draw();
            foreach (var e in enemies)
                e.Draw();
            SDL.SDL_RenderPresent(renderer);
        }
		public void clean () 
		{
			SDL.SDL_DestroyRenderer(renderer);
			SDL.SDL_DestroyWindow(window);
			SDL.SDL_Quit();
			Console.WriteLine("Game cleaned");
		}
		public bool running() { return isRunning; }


	}
}
