using Godot;
using GodotUtils;

namespace ET
{
    public class AppStartInitFinish_ShowLoginUI : AEvent<EventType.AppStartInitFinish>
    {
        protected override void Run(EventType.AppStartInitFinish args)
        {
            //    GD.Print("AppStartInitFinish!");        
            UIHelper.Create(args.ZoneScene, UIType.UILogin, UILayer.Normal).Coroutine();
        }
    }
}
