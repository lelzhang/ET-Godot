
using Godot;

namespace ET
{
	[ComponentOf(typeof(UI))]
	public class UILobbyComponent : Entity, IAwake
	{
		public Button startButton;
		public TextEdit text;
	}
}
