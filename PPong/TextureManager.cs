using SDL2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster
{
	public class TextureManager
	{
		public static IntPtr loadTexture(String texture, IntPtr renderer)
		{
			IntPtr surface = SDL_image.IMG_Load(texture);
			IntPtr tex = SDL.SDL_CreateTextureFromSurface(renderer, surface);
			SDL.SDL_FreeSurface(surface);
			return tex;
		}
		public static void Draw(IntPtr tex, SDL.SDL_Rect srcRect, SDL.SDL_Rect desRect,IntPtr renderer)
		{
			SDL.SDL_RenderCopy(renderer, tex, ref srcRect, ref desRect);
		}
	}
}
