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
		private PositionComponent position;
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
			position= Entity.GetComponent<PositionComponent>();	
			srcRect.x= srcRect.y= 0;
			srcRect.w= srcRect.h= 32;
			desRect.w= desRect.h= 64;
		}
		public override void Update()
		{
			desRect.x = position.x();
			desRect.y = position.y();	
		}
		public override void Draw()
		{
			TextureManager.Draw(tex, srcRect, desRect, renderer);
		}
	}
}
