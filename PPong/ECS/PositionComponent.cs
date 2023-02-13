using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster.ECS
{
	class PositionComponent : Component
	{
		public int xpos ;
		public int ypos ;
		public PositionComponent(int x, int y)
		{
			xpos = x;
			ypos = y;
		}
		public PositionComponent()
		{
			xpos = 0;
			ypos = 0;

		}
		public int x()
		{ 
			return xpos;
		}
		public int y()
		{
			return ypos;
		}
		public override void Init()
		{
			
		}
		public override void Update()
		{
			xpos++;
			ypos++;
		}
		void setPos(int x, int y)
		{
			xpos = x;
			ypos = y;
		}
	}
}
