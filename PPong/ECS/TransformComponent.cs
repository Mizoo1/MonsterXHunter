using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Monster.ECS
{
	class TransformComponent : Component
	{
		public Vector2D position;
		public Vector2D velocity;
		public int speed  =3;
		public int height =32;
		public int width  =32;
		public int scale  =1;
		public TransformComponent(float x, float y)
		{
			position= new Vector2D(x,y);
			velocity = new Vector2D(0f,0f);
		}
		public TransformComponent()
		{
			position = new Vector2D(0f, 0f);
			velocity = new Vector2D(0f, 0f);
		}
		public TransformComponent(int sc)
		{
			position = new Vector2D(0f, 0f);
			velocity = new Vector2D(0f, 0f);
			speed = sc;
		}
		public TransformComponent(float x, float y,int h,int w,int sc)
		{
			position = new Vector2D(x, y);
			height= h;
			width= w;
			scale = sc;
			velocity = new Vector2D(0f, 0f);
		}

		public override void Init()
		{
			velocity.x=velocity.y=0f;
		}
		public override void Update()
		{
			position.x+=velocity.x*speed;
			position.y+=velocity.y*speed;
		}
		
	}
}
