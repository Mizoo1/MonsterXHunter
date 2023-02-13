using SDL2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster
{
	public class Map
	{
		private SDL.SDL_Rect srcRect, desRect;
		private IntPtr renderer;
		private IntPtr grass;
		private IntPtr water;
		private IntPtr dirt;
		private int[,] map=new int[20,25];
	public Map(IntPtr renderer, LoadContent lo) 
		{
            this.renderer = renderer;
            dirt = lo.dirt;
            grass = lo.grass;
            water = lo.water;
            LoadMap(lvl1);
            srcRect.x = srcRect.y = 0;
            srcRect.w = desRect.w = 32;
            srcRect.h = desRect.h = 32;
            desRect.x = desRect.y = 0;
        }
		public void LoadMap(int[,] arr) 
		{
			for(int row=0; row < map.GetLength(0); row++)
			{
				for (int colom = 0; colom < map.GetLength(1); colom++)
				{
					map[row,colom] = arr[row,colom];
				}
			}
		}
		public void DrawMap()
		{
			int type = 0;

			for (int row = 0; row < map.GetLength(0); row++)
			{
				for (int colom = 0; colom < map.GetLength(1); colom++)
				{
					type = map[row,colom];
					desRect.x = colom * 32;
					desRect.y = row * 32;
					switch (type)
					{
						case 0:
							TextureManager.Draw(water, srcRect, desRect, renderer);
							break;
						case 1:
							TextureManager.Draw(grass, srcRect, desRect, renderer);
							break;
						case 2:
							TextureManager.Draw(dirt, srcRect, desRect, renderer);
							break;
						default: 
							break;

					}
				}
			}
		}
		public int[,] lvl1 =
		{
			{ 0,0,0,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
			{ 0,0,0,0,1,1,1,2,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
			{ 0,0,0,0,1,1,1,2,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
			{ 0,0,0,0,0,0,1,1,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
			{ 0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
			{ 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
			{ 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
			{ 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
			{ 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
			{ 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
			{ 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
			{ 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
			{ 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
			{ 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
			{ 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
			{ 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
			{ 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
			{ 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
			{ 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0 },
			{ 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
		};
		
		
	}
}
