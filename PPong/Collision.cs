using Monster.ECS;
using SDL2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster
{
	
	public class Collision
	{

		public Collision() { }

		// access allay Collision box
		public bool AABB(SDL.SDL_Rect recA , SDL.SDL_Rect recB)
		{
			if (
				recA.x + recA.w >= recB.x &&
				recB.x + recB.w >= recA.x &&
				recA.y + recA.h >= recB.y &&
				recB.y + recB.h >= recA.y
				)
			{
				return true;
			}
			return false;
		}
		public bool AABB(ColliderComponent colA, ColliderComponent colB)
		{
			if (AABB(colA.collider,colB.collider))
			{
				if(colA.collider.Equals(colB.collider))
				{ return false; }
				return true;
			}
			return false;
		}

	}
}
