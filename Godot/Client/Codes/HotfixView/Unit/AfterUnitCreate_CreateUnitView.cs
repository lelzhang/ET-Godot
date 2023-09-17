using Godot;

namespace ET
{
    public class AfterUnitCreate_CreateUnitView: AEvent<EventType.AfterUnitCreate>
    {
        protected override void Run(EventType.AfterUnitCreate args)
        {
            // Unit View层
            // 这里可以改成异步加载，demo就不搞了
            PackedScene res = GD.Load<PackedScene>("res://Prefabs/unit.tscn");
            Node3D skin = res.Instantiate() as Node3D;
            GlobalComponent.Instance.Unit.AddChild(skin);
            args.Unit.AddComponent<GameObjectComponent>().GameObject = skin;
            skin.Position = args.Unit.Position;

            //Camera3D camera3D = GlobalComponent.Instance.Unit.GetNode<Camera3D>("Map1/CameraRoot/Camera3D");
            //camera3D.Position += skin.Position;
            //args.Unit.AddComponent<GameObjectComponent>().GameObject = skin;
            //args.Unit.AddComponent<AnimatorComponent>();
        }
    }
}