using System;
using System.Net;
using Godot;
using GodotUtils;


namespace ET
{
	[ObjectSystem]
	public class UILoginComponentAwakeSystem : AwakeSystem<UILoginComponent>
	{
		public override void Awake(UILoginComponent self)
		{
			Node login = self.GetParent<UI>().GameObject;
			self.loginBtn = login.GetNode<Button>("LoginButton");
			self.account = login.GetNode<TextEdit>("Account");
            self.password = login.GetNode<TextEdit>("Password");

            self.loginBtn.ButtonDown += async () =>
            {
                await LoginHelper.Login(self.ZoneScene(), ConstValue.LoginAddress, self.account.Text, self.password.Text);
            };
        }
	}
	
	[FriendClass(typeof(UILoginComponent))]
	public static class UILoginComponentSystem
	{
	
	}
}
