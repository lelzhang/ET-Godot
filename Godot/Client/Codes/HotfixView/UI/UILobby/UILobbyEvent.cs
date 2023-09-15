using System;
using Godot;

namespace ET
{
    [UIEvent(UIType.UILobby)]
    public class UILobbyEvent: AUIEvent
    {
        public override async ETTask<UI> OnCreate(UIComponent uiComponent, UILayer uiLayer)
        {
            var res = GD.Load<PackedScene>("res://Scenes/UILobby.tscn");
            Control lobby = res.Instantiate() as Control;
            UIEventComponent.Instance.UILayers[(int)uiLayer].AddChild(lobby);
            UI ui = uiComponent.AddChild<UI, string, Node>(UIType.UILobby, lobby);
            ui.AddComponent<UILobbyComponent>();
            await ETTask.CompletedTask;
            return ui;
        }

        public override void OnRemove(UIComponent uiComponent)
        {
            uiComponent.Remove(UIType.UILobby);
        }
    }
}