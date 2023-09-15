using Godot;

namespace ET
{
    public class AfterCreateZoneScene_AddViewComponent : AEvent<EventType.AfterCreateZoneScene>
    {
        protected override void Run(EventType.AfterCreateZoneScene args)
        {
            args.ZoneScene.AddComponent<UIComponent>();
            args.ZoneScene.AddComponent<UIEventComponent>();
        }
    }
}
