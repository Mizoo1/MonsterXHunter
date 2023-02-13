using Monster;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Net.Mime;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Monster.ECS
{
	public class Component
	{
		public Entity Entity { get; set; }

		public virtual void Init() { }

		public virtual void Update() { }

		public virtual void Draw() { }
        public virtual void OnDestroy() { }
    }

	public class Entity
	{
		private bool active = true;
		private List<Component> components= new List<Component>();
		private Dictionary<Type, Component> componentDictionary= new Dictionary<Type, Component>();

		public void Update()
		{
			foreach (var c in components)
			{
				c.Update();
			}
			
		}

		public void Draw() 
		{
			foreach (var c in components)
			{
				c.Draw();
			}
		}

		public bool IsActive()
		{
			return active;
		}

		public void Destroy()
		{
			active = false;
		}

		public bool HasComponent<T>() where T : Component
		{
			return componentDictionary.ContainsKey(typeof(T));
		}

		public T AddComponent<T>(params object[] args) where T : Component, new()
		{
			T component = (T)Activator.CreateInstance(typeof(T), args);
			component.Entity = this;
			components.Add(component);
			componentDictionary[typeof(T)] = component;
			component.Init();
			return component;
		}

		public T GetComponent<T>() where T : Component
		{
			Console.WriteLine("Keys in componentDictionary:");
			foreach (var key in componentDictionary.Keys)
			{
				Console.WriteLine(key.Name);
			}
			if (!componentDictionary.ContainsKey(typeof(T)))
			{
				throw new KeyNotFoundException("The specified component type is not present in the entity.");
			}
			Component component = componentDictionary[typeof(T)];
			Console.WriteLine("Returned component: " + component.ToString());
			if (!(component is T))
			{
				throw new InvalidCastException("The retrieved component is not of the expected type.");
			}
			return (T)component;
		}
	}

	public class Manager
	{
		private List<Entity> entities= new List<Entity>();

		public void Update()
		{
			foreach (var e in entities)
			{
				e.Update();
			}
		}

		public void Draw()
		{
			foreach (var e in entities)
			{
				e.Draw();
			}
		}

		public void Refresh()
		{
			entities.RemoveAll(e => !e.IsActive());
		}

		public Entity AddEntity()
		{
			Entity entity = new Entity();
			entities.Add(entity);
			return entity;
		}
	}

}

