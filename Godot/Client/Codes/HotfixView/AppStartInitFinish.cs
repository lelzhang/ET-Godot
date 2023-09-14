using Godot;
using GodotUtils;

namespace ET
{
    public class AppStartInitFinish : AEvent<EventType.AppStartInitFinish>
    {
        protected override void Run(EventType.AppStartInitFinish args)
        {
            GD.Print("AppStartInitFinish!");
            SceneManager.Instance.SwitchScene("UILogin");
        }
    }
}
