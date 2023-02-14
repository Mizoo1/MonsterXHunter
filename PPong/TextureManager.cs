using SDL2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SDL2.SDL;

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
		public static void Draw(IntPtr tex, SDL.SDL_Rect srcRect, SDL.SDL_Rect desRect, IntPtr renderer, SDL_RendererFlip flip)
		{
            double angle = 30.0;
            SDL.SDL_Point center = new SDL.SDL_Point { x = 50, y = 50 };
            SDL.SDL_RenderCopyEx(renderer, tex, ref srcRect, ref desRect, 0, ref center, flip);
        }
	}
}
