using SDL2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster.ECS
{
	public  class SpriteComponent: Component
	{
        private TransformComponent transform;
        private IntPtr tex;
		private SDL.SDL_Rect srcRect, desRect;
		private IntPtr renderer;

		public SpriteComponent()
		{
			
		}
		public SpriteComponent(IntPtr src, IntPtr renderer)
		{
			this.renderer = renderer;
			setTex(src);
		}
		public void setTex(IntPtr src)
		{
			tex = src;
		}
		public override void Init()
		{
            transform = Entity.GetComponent<TransformComponent>();
            srcRect.x= srcRect.y= 0;
			srcRect.w= srcRect.h= 32;
			desRect.w= desRect.h= 64;
		}
		public override void Update()
		{
            desRect.x = (int)(transform.position.x);
            desRect.y = (int)(transform.position.y);
            desRect.w = transform.width * transform.scale;
            desRect.h = transform.height * transform.scale;
        }
		public override void Draw()
		{
			TextureManager.Draw(tex, srcRect, desRect, renderer);
		}
        public override void OnDestroy()
        {
            SDL.SDL_DestroyTexture(tex);
        }
    }
}
