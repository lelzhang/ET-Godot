using Godot;

namespace ET
{
    public class ChangeRotation_SyncGameObjectRotation: AEventClass<EventType.ChangeRotation>
    {
        protected override void Run(object changeRotation)
        {
            EventType.ChangeRotation args = changeRotation as EventType.ChangeRotation;
            GameObjectComponent gameObjectComponent = args.Unit.GetComponent<GameObjectComponent>();
            if (gameObjectComponent == null)
            {
                return;
            }
            Node3D transform = gameObjectComponent.GameObject;
            transform.Quaternion = args.Unit.Rotation;
        }
    }
}
