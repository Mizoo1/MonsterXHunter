using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster.ECS
{
	public class Vector2D
	{
		public float x;
		public float y;

		public Vector2D(float x, float y)
		{
			this.x = x;
			this.y = y;
		}

		public Vector2D Add(Vector2D vec)
		{
			this.x += vec.x;
			this.y += vec.y;
			return this;
		}

		public Vector2D Subtract(Vector2D vec)
		{
			this.x -= vec.x;
			this.y -= vec.y;
			return this;
		}

		public Vector2D Multiply(Vector2D vec)
		{
			this.x *= vec.x;
			this.y *= vec.y;
			return this;
		}

		public Vector2D Divide(Vector2D vec)
		{
			this.x /= vec.x;
			this.y /= vec.y;
			return this;
		}
		public static Vector2D operator +(Vector2D v1, Vector2D v2)
		{
			return v1.Add(v2);
		}

		public static Vector2D operator -(Vector2D v1, Vector2D v2)
		{
			return v1.Subtract(v2);
		}

		public static Vector2D operator *(Vector2D v1, Vector2D v2)
		{
			return v1.Multiply(v2);
		}

		public static Vector2D operator /(Vector2D v1, Vector2D v2)
		{
			return v1.Divide(v2);
		}

		public static Vector2D operator *(Vector2D vec, int i)
		{
			vec.x *= i;
			vec.y *= i;
			return vec;
		}

		public Vector2D Zero()
		{
			this.x = 0;
			this.y = 0;
			return this;
		}
	}
}
