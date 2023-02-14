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
using static Monster.Game;

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
        private Manager manager;
        private bool Active = true;
		private List<Component> components= new List<Component>();
        private Dictionary<Type, Component> componentArray = new Dictionary<Type, Component>();
        private Dictionary<Type, bool> componentBitSet = new Dictionary<Type, bool>();
        private Dictionary<GroupLabels, bool> groupBitSet = new Dictionary<GroupLabels, bool>();
        public Entity(Manager mManager)
        {
            manager = mManager;
        }

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
			return Active;
		}

		public void Destroy()
		{
			Active = false;
		}
        public bool HasGroup(GroupLabels mGroup)
        {
            return groupBitSet.ContainsKey(mGroup) && groupBitSet[mGroup];
        }
        public void AddGroup(GroupLabels mGroup)
        {

            groupBitSet[mGroup] = true;
            manager.AddToGroup(this, mGroup);
        }
        public void DelGroup(GroupLabels mGroup)
        {
            if (groupBitSet.ContainsKey(mGroup))
                groupBitSet.Remove(mGroup);
        }
        public bool HasComponent<T>() where T : Component
		{
            Type type = typeof(T);
            return componentBitSet.ContainsKey(type) && componentBitSet[type];
        }

		public T AddComponent<T>(params object[] args) where T : Component, new()
		{
            Type type = typeof(T);
            T component = (T)Activator.CreateInstance(type, args);
            component.Entity = this;
            components.Add(component);
            componentArray[type] = component;
            componentBitSet[type] = true;
            component.Init();
			return component;
		}

		public T GetComponent<T>() where T : Component
		{
            Type type = typeof(T);
            return (T)componentArray[type];
        }
	}

	public class Manager
	{
        private List<Entity> entities = new List<Entity>();
        private Dictionary<GroupLabels, List<Entity>> groupedEntities = new Dictionary<GroupLabels, List<Entity>>();

        public void Update()
        {
            foreach (var e in entities)
                e.Update();
        }
        public void Draw()
        {
            foreach (var e in entities)
                e.Draw();
        }
        public void Refresh()
        {
            var groupTypes = groupedEntities.Keys;
            foreach (var group in groupTypes)
            {
                var entitiesInGroup = groupedEntities[group];
                entitiesInGroup.RemoveAll(e => !e.IsActive() || !e.HasGroup(group));
            }

            entities.RemoveAll(e => !e.IsActive());
        }
        public void AddToGroup(Entity mEntity, GroupLabels mGroup)
        {
            if (groupedEntities.ContainsKey(mGroup))
            {
                groupedEntities[mGroup].Add(mEntity);
            }
            else
            {
                groupedEntities.Add(mGroup, new List<Entity> { mEntity });
            }
        }

        public List<Entity> GetGroup(GroupLabels mGroup)
        {
            if (groupedEntities.ContainsKey(mGroup))
            {
                return groupedEntities[mGroup];
            }
            else
            {
                return new List<Entity>();
            }
        }

        public Entity AddEntity()
        {
            Entity e = new Entity(this);
            entities.Add(e);
            return e;
        }
    }

}

