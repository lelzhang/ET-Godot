using System.Collections.Generic;
using Godot;

namespace ET
{
	[FriendClass(typeof(UI))]
	public static class UISystem
	{
		[ObjectSystem]
		public class UIAwakeSystem : AwakeSystem<UI, string, Node>
		{
			public override void Awake(UI self, string name, Node gameObject)
			{
				self.nameChildren.Clear();
				self.Name = name;
				self.GameObject = gameObject;
			}
		}
		
		[ObjectSystem]
		public class UIDestroySystem : DestroySystem<UI>
		{
			public override void Destroy(UI self)
			{
				foreach (UI ui in self.nameChildren.Values)
				{
					ui.Dispose();
				}
			    //self.GameObject.Dispose();
				self.GameObject.Free();
                self.GameObject.Dispose();
                //ResourceLoader.
                //Object.Destroy(self.GameObject);
                self.nameChildren.Clear();
			}
		}

		public static void Add(this UI self, UI ui)
		{
			self.nameChildren.Add(ui.Name, ui);
		}

		public static void Remove(this UI self, string name)
		{
			UI ui;
			if (!self.nameChildren.TryGetValue(name, out ui))
			{
				return;
			}
			self.nameChildren.Remove(name);
			ui.Dispose();
		}

		public static UI Get(this UI self, string name)
		{
			UI child;
			if (self.nameChildren.TryGetValue(name, out child))
			{
				return child;
			}
            Node childGameObject = self.GameObject.GetNode(name);
			if (childGameObject == null)
			{
				return null;
			}
			child = self.AddChild<UI, string, Node>(name, childGameObject);
			self.Add(child);
			return child;
		}
	}
	
	public sealed class UI: Entity, IAwake<string, Node>, IDestroy
	{
		public Node GameObject { get; set; }
		
		public string Name { get; set; }

		public Dictionary<string, UI> nameChildren = new Dictionary<string, UI>();
	}
}