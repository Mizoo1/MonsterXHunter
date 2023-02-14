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

	public Map(IntPtr renderer, LoadContent lo) 
		{
           
        }
		public void LoadMap(string path, int sizeX, int sizeY) 
		{
            using (var mapFile = new StreamReader(path))
            {
                string line;
                int y = 0;
                while ((line = mapFile.ReadLine()) != null && y < sizeY)
                {
                    for (int x = 0; x < sizeX && x * 2 < line.Length; x++)
                    {
                        if (int.TryParse(line.Substring(x * 2, 1), out int srcY) &&
                            int.TryParse(line.Substring(x * 2 + 1, 1), out int srcX))
                        {
                            Game.AddTile(srcX * 32, srcY * 32, x * 24, y * 24);
                        }
                    }
                    y++;
                }
            }
        }
	

    }
}
