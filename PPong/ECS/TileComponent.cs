using SDL2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster.ECS
{
	public class TileComponent:Component
	{
        public IntPtr tex;
        public SDL.SDL_Rect srcRect, desRect;
        public Vector2D position;
        private LoadContent lo;
		private IntPtr renderer;
		public TileComponent()
		{

		}
		public TileComponent(int srcX, int srcY, int x, int y, String path, IntPtr renderer)
		{
            lo = new LoadContent(renderer);
            this.renderer = renderer;
            tex = TextureManager.loadTexture(path, renderer);
            position = new Vector2D(x, y);

            srcRect.x = srcX; srcRect.y = srcY;
            srcRect.w = srcRect.h = 32;

            desRect.x = x; desRect.y = y;
            desRect.h = desRect.w = 75;
        }
		public override void Init()
		{
			
		}
        public override void Draw()
        {
            TextureManager.Draw(tex, srcRect, desRect, renderer, SDL.SDL_RendererFlip.SDL_FLIP_NONE);
        }
        public override void Update()
        {
            desRect.x = (int)position.x - Game.camera.x;
            desRect.y = (int)position.y - Game.camera.y;
        }
    }
}
