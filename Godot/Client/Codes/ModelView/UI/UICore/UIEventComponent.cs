using System;
using System.Collections.Generic;
using Godot;

namespace ET
{
	/// <summary>
	/// 管理所有UI GameObject
	/// </summary>
	[ComponentOf(typeof(Scene))]
	public class UIEventComponent: Entity, IAwake
	{
		public static UIEventComponent Instance;
		
		public Dictionary<string, AUIEvent> UIEvents = new Dictionary<string, AUIEvent>();
		
		public Dictionary<int, Node> UILayers { get; set;}= new Dictionary<int, Node>();
	}
}