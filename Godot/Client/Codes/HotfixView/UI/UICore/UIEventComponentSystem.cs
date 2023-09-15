using System;
using System.Collections.Generic;
using Godot;

namespace ET
{
	[ObjectSystem]
	public class UIEventComponentAwakeSystem : AwakeSystem<UIEventComponent>
	{
		public override void Awake(UIEventComponent self)
		{
			UIEventComponent.Instance = self;

			Node uiRoot = GlobalComponent.Instance.UI;
			
			self.UILayers.Add((int)UILayer.Normal, GlobalComponent.Instance.NormalLayer);
			self.UILayers.Add((int)UILayer.PopUp, GlobalComponent.Instance.PopUpLayer);
			self.UILayers.Add((int)UILayer.Loading, GlobalComponent.Instance.LoadingLayer);
			

			var uiEvents = Game.EventSystem.GetTypes(typeof (UIEventAttribute));
			foreach (Type type in uiEvents)
			{
				object[] attrs = type.GetCustomAttributes(typeof(UIEventAttribute), false);
				if (attrs.Length == 0)
				{
					continue;
				}

				UIEventAttribute uiEventAttribute = attrs[0] as UIEventAttribute;
				AUIEvent aUIEvent = Activator.CreateInstance(type) as AUIEvent;
				self.UIEvents.Add(uiEventAttribute.UIType, aUIEvent);

				//Log.Debug(type.ToString());
            }		
		}
	}
	
	/// <summary>
	/// 管理所有UI GameObject 以及UI事件
	/// </summary>
	[FriendClass(typeof(UIEventComponent))]
	public static class UIEventComponentSystem
	{
		public static async ETTask<UI> OnCreate(this UIEventComponent self, UIComponent uiComponent, string uiType, UILayer uiLayer)
		{
			try
			{
				UI ui = await self.UIEvents[uiType].OnCreate(uiComponent, uiLayer);
				return ui;
			}
			catch (Exception e)
			{
				throw new Exception($"on create ui error: {uiType}", e);
			}
		}
		
		public static void OnRemove(this UIEventComponent self, UIComponent uiComponent, string uiType)
		{
			try
			{
				self.UIEvents.Remove(uiType);
			}
			catch (Exception e)
			{
				throw new Exception($"on remove ui error: {uiType}", e);
			}
			
		}
	}
}