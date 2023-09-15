using Godot;
using System;

namespace ET
{
	[ComponentOf(typeof(UI))]
	public class UILoginComponent: Entity, IAwake
	{
		public TextEdit account;
		public TextEdit password;
		public Button loginBtn;
	}
}
