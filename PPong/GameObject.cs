using SDL2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster
{
	
	public class GameObject
	{
		private int xPos;
		private int yPos;
		private IntPtr objTexture;
		private IntPtr renderer;
		SDL.SDL_Rect srcRect, desRect;
		public GameObject(String texturesheet, IntPtr ren,int x,int y) 
		{
			renderer = ren;
			objTexture = TextureManager.loadTexture(texturesheet,renderer);
			xPos = x;
			yPos = y;
		}
		public void Update() 
		{
			xPos++;
			yPos++;
			srcRect.h = 32;
			srcRect.w = 32;
			srcRect.x = 0;
			srcRect.y = 0;

			desRect.x= xPos;
			desRect.y= yPos;
			desRect.w= srcRect.w*2;
			desRect.h= srcRect.h*2;
		}
		public void Render()
		{	
			SDL.SDL_RenderCopy(renderer, objTexture,  ref srcRect,  ref desRect);
			SDL.SDL_RenderPresent(renderer);
		}
	}
}
