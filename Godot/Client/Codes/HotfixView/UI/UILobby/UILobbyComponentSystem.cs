using Godot;

namespace ET
{
    [ObjectSystem]
    public class UILobbyComponentAwakeSystem: AwakeSystem<UILobbyComponent>
    {
        public override void Awake(UILobbyComponent self)
        {
            Node login = self.GetParent<UI>().GameObject;
            self.startButton = login.GetNode<Button>("StartButton");        

            self.startButton.ButtonDown += () =>
            {
                self.EnterMap().Coroutine();
            };
        }
    }

    public static class UILobbyComponentSystem
    {
        public static async ETTask EnterMap(this UILobbyComponent self)
        {
            await EnterMapHelper.EnterMapAsync(self.ZoneScene());
            await UIHelper.Remove(self.ZoneScene(), UIType.UILobby);
        }
    }
}