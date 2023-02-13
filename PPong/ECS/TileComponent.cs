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
		private TransformComponent transform;
		private SpriteComponent sprite;
		private SDL.SDL_Rect tileRect;
		private int titledID;
		private LoadContent lo;
		private IntPtr renderer;
		private IntPtr path;
		public TileComponent()
		{

		}
		public TileComponent(int x, int y,int w ,int h ,int id, IntPtr renderer)
		{
			lo = new LoadContent(renderer);
			this.renderer = renderer;
			this.tileRect.x= x;
			this.tileRect.y= y;
			this.tileRect.w= w;
			this.tileRect.h= h;
			this.titledID = id;
			switch (titledID)
			{
				case 0:
					path =lo.water ;
					break;
				case 1:
					path =lo.dirt;
					break;
				case 2:
					path =lo.grass;
					break;
				default: break;
			}
		}
		public override void Init()
		{
			Entity.AddComponent<TransformComponent>((float)tileRect.x, (float)tileRect.y, tileRect.w, tileRect.h, 1);
			transform=Entity.GetComponent<TransformComponent>();
			Entity.AddComponent<SpriteComponent>(path, renderer);
			sprite=Entity.GetComponent<SpriteComponent>();
		}
	}
}
