using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster.ECS
{
	public class Animation
	{
		public int index;
		public int frame;
		public int speed;
		public Animation(int i, int f, int s)
		{
			index= i;
			frame= f;
			speed= s;
		}
		public Animation()
		{

		}
	}
}
