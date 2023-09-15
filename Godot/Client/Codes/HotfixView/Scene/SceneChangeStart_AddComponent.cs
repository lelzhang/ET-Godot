using Godot;

namespace ET
{
    public class SceneChangeStart_AddComponent: AEvent<EventType.SceneChangeStart>
    {
        protected override void Run(EventType.SceneChangeStart args)
        {
            RunAsync(args).Coroutine();
        }
        
        private async ETTask RunAsync(EventType.SceneChangeStart args)
        {
            Scene currentScene = args.ZoneScene.CurrentScene();

            Log.Debug(currentScene.Name);
            // 加载场景资源
            PackedScene res = GD.Load<PackedScene>($"res://Scenes/{currentScene.Name}.tscn");
            Node3D scene = res.Instantiate() as Node3D;
            GlobalComponent.Instance.Unit.AddChild(scene);

            //加载相机
            //PackedScene resCamera = GD.Load<PackedScene>($"res://Scenes/CameraRoot.tscn");
            //Node3D camera = res.Instantiate() as Node3D;
            //GlobalComponent.Instance.Unit.AddChild(camera);

            // 切换到map场景

            //SceneChangeComponent sceneChangeComponent = null;
            //try
            //{
            //    sceneChangeComponent = Game.Scene.AddComponent<SceneChangeComponent>();
            //    {
            //        await sceneChangeComponent.ChangeSceneAsync(currentScene.Name);
            //    }
            //}
            //finally
            //{
            //    sceneChangeComponent?.Dispose();
            //}


            currentScene.AddComponent<OperaComponent>();

            await ETTask.CompletedTask;
        }
    }
}