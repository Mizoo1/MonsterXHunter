using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster
{
	public class LoadContent
	{
		public IntPtr renderer;
		public IntPtr dirt;
		public IntPtr grass;
		public IntPtr water;
		public IntPtr player;
        public IntPtr player_idle;
        public IntPtr enemy;
		
		public LoadContent(IntPtr renderer)
		{
			this.renderer = renderer;
			dirt   = TextureManager.loadTexture("Assest\\dirt.png",renderer);
			grass  = TextureManager.loadTexture("Assest\\grass.png",renderer);
			water  = TextureManager.loadTexture("Assest\\water.png",renderer);
			player = TextureManager.loadTexture("Assest\\hero01.png",renderer);
            player_idle = TextureManager.loadTexture("Assest\\player_anims.png", renderer);
            enemy  = TextureManager.loadTexture("Assest\\enemy.png",renderer);
		}
		
	}
}
