using System;
using Godot;

namespace ET
{
    [UIEvent(UIType.UILogin)]
    public class UILoginEvent: AUIEvent
    {
        public override async ETTask<UI> OnCreate(UIComponent uiComponent, UILayer uiLayer)
        {
            var res = GD.Load<PackedScene>("res://Scenes/UILogin.tscn");
            Control login = res.Instantiate() as Control;
            UIEventComponent.Instance.UILayers[(int)uiLayer].AddChild(login);
            UI ui = uiComponent.AddChild<UI, string, Node>(UIType.UILogin, login);
            ui.AddComponent<UILoginComponent>();

            await ETTask.CompletedTask;
            return ui;
        }

        public override void OnRemove(UIComponent uiComponent)
        {
            uiComponent.Remove(UIType.UILogin);
        }
    }
}