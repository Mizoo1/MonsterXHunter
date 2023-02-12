using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDL2;

namespace Monster
{
	public class Game
	{
		private bool isRunning;
		private IntPtr window;
		public IntPtr renderer;
		private GameObject player;
		private GameObject enemy;
		private Map map;
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
		
			player = new GameObject("Assest\\hero01.png", renderer,0,0);
			enemy  = new GameObject("Assest\\enemy.png", renderer, 50,50);
			map = new Map(renderer);
		}
		public void handleEvent()
		{
			SDL.SDL_Event e;
			SDL.SDL_PollEvent(out e);
			switch (e.type)
			{
				case SDL.SDL_EventType.SDL_QUIT:
					isRunning= false;
					break;
				default:
					break;

			}
		}
		public void Update ()
		{
			player.Update();
			enemy.Update();
			
		}
		public void render () 
		{
			SDL.SDL_RenderClear(renderer);
			map.DrawMap();
			// add stuff to render
			player.Render();
			enemy.Render();
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
