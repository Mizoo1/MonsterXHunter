using SDL2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster.ECS
{
	public  class ColliderComponent: Component
	{
		public SDL.SDL_Rect collider;
		private String tag;
		private TransformComponent transform;
		private List<ColliderComponent> colliders;
		public ColliderComponent()
		{
			
		}
		public ColliderComponent(String tag, List<ColliderComponent> colliders)
		{
			this.tag = tag;
			this.colliders = colliders;
		}
		public override void Init()
		{
			if (!Entity.HasComponent<TransformComponent>())
			{
				Entity.AddComponent<TransformComponent>();
			}
			transform= Entity.GetComponent<TransformComponent>();
			colliders.Add(this);
		}
		public override void Update() 
		{
			collider.x = (int)transform.position.x;
			collider.y = (int)transform.position.y; 
			collider.w = transform.width*transform.scale;
			collider.h = transform.height*transform.scale;
		}
	}
}
