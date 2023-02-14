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
        private SpriteComponent sprite;
        private SDL.SDL_Event e;
		public KeyboardController()
		{

		}
		public override void Init()
		{
			transform = Entity.GetComponent<TransformComponent>();
            sprite = Entity.GetComponent<SpriteComponent>();
        }
		public override void Update()
		{
			SDL.SDL_PollEvent(out e);
			if(e.type==SDL.SDL_EventType.SDL_QUIT)
                Game.isRunning = false;
            if (e.type == SDL.SDL_EventType.SDL_KEYDOWN)
            {

                switch (e.key.keysym.sym)
                {
                    case SDL.SDL_Keycode.SDLK_w:
                        transform.velocity.y = -1;
                        sprite.Play("Walk");
                        break;
                    case SDL.SDL_Keycode.SDLK_s:
                        transform.velocity.y = 1;
                        sprite.Play("Walk");
                        break;
                    case SDL.SDL_Keycode.SDLK_a:
                        transform.velocity.x = -1;
                        sprite.Play("Walk");
                        sprite.flip = SDL.SDL_RendererFlip.SDL_FLIP_HORIZONTAL;
                        break;
                    case SDL.SDL_Keycode.SDLK_d:
                        transform.velocity.x = 1;
                        sprite.Play("Walk");
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
                        sprite.Play("Idle");
                        break;
                    case SDL.SDL_Keycode.SDLK_s:
                        transform.velocity.y = 0;
                        sprite.Play("Idle");
                        break;
                    case SDL.SDL_Keycode.SDLK_a:
                        transform.velocity.x = 0;
                        sprite.Play("Idle");
                        sprite.flip = SDL.SDL_RendererFlip.SDL_FLIP_NONE;
                        break;
                    case SDL.SDL_Keycode.SDLK_d:
                        transform.velocity.x = 0;
                        sprite.Play("Idle");
                        break;
                    default: break;
                }
            }

        }
	}
}
