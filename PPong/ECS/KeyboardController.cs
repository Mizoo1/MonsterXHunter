using SDL2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace Monster.ECS
{
	public class KeyboardController : Component
	{
		private TransformComponent transform;
		private SDL.SDL_Event e;
		public bool isRunning = true;
		public KeyboardController()
		{

		}
		public override void Init()
		{
			transform = Entity.GetComponent<TransformComponent>();
		}
		public override void Update()
		{
			SDL.SDL_PollEvent(out e);
			if(e.type==SDL.SDL_EventType.SDL_QUIT)
				isRunning = false;
			if (e.type == SDL.SDL_EventType.SDL_KEYDOWN)
			{

				switch (e.key.keysym.sym)
				{
					case SDL.SDL_Keycode.SDLK_w:
						transform.velocity.y = -1;
						break;
					case SDL.SDL_Keycode.SDLK_s:
						transform.velocity.y = 1;
						break;
					case SDL.SDL_Keycode.SDLK_a:
						transform.velocity.x = -1;
						break;
					case SDL.SDL_Keycode.SDLK_d:
						transform.velocity.x = 1;
						break;

					default: break;
				}
			}
			if (e.type == SDL.SDL_EventType.SDL_KEYUP)
			{
				switch (e.key.keysym.sym)
				{
					case SDL.SDL_Keycode.SDLK_w:
						transform.velocity.y = 0;
						break;
					case SDL.SDL_Keycode.SDLK_s:
						transform.velocity.y = 0;
						break;
					case SDL.SDL_Keycode.SDLK_a:
						transform.velocity.x = 0;
						break;
					case SDL.SDL_Keycode.SDLK_d:
						transform.velocity.x = 0;
						break;
					default: break;
				}
			}

		}
	}
}
