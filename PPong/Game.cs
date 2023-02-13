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
		private bool isRunning;
		private IntPtr window;
		public IntPtr renderer;
		private Map map;
        private Manager manager;
        private Entity Player;
        private Entity wall;
        private Entity tile0, tile1, tile2;
        private LoadContent lo;
        private List<ColliderComponent> colliders;
        public Game() {
			
		}
		public void init(String title ,int xpos,int ypos,int width,int height, bool fullscreen)
		{
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
            // Entity
            Player = manager.AddEntity();
            wall = manager.AddEntity();
            tile0 = manager.AddEntity();
            tile1 = manager.AddEntity();
            tile2 = manager.AddEntity();
            // Tile Component
            tile0.AddComponent<TileComponent>(200, 200, 32, 32, 0, renderer);
            tile1.AddComponent<TileComponent>(250, 250, 32, 32, 1, renderer);
            tile1.AddComponent<ColliderComponent>("dirt", colliders);
            tile2.AddComponent<TileComponent>(150, 150, 32, 32, 2, renderer);
            tile2.AddComponent<ColliderComponent>("grass", colliders);
            // player Component
            Player.AddComponent<TransformComponent>(2);
            Player.AddComponent<SpriteComponent>(lo.player, renderer);
            Player.AddComponent<KeyboardController>();
            Player.AddComponent<ColliderComponent>("Player", colliders);
            //wall Component
            wall.AddComponent<TransformComponent>(300.0f, 300.0f, 300, 20, 1);
            wall.AddComponent<SpriteComponent>(lo.dirt, renderer);
            wall.AddComponent<ColliderComponent>("Wall", colliders);
        }
		public void handleEvent()
		{

		}
		public void Update ()
		{
            Collision c = new Collision();
            manager.Refresh();
            manager.Update();
            foreach (var v in colliders)
            {
                if (c.AABB(Player.GetComponent<ColliderComponent>(), v))
                {
                    Player.GetComponent<TransformComponent>().position = new Vector2D(0, 0);
                }
            }

        }
		public void render () 
		{
            SDL.SDL_RenderClear(renderer);
            //map.DrawMap();
            manager.Draw();
            // add stuff to render
            SDL.SDL_RenderPresent(renderer);
        }
		public void clean () 
		{
			SDL.SDL_DestroyRenderer(renderer);
			SDL.SDL_DestroyWindow(window);
			SDL.SDL_Quit();
			Console.WriteLine("Game cleaned");
		}
		public bool running() { return Player.GetComponent<KeyboardController>().isRunning; }


	}
}
