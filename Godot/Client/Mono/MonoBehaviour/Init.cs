using System.Threading;
using Godot;

namespace ET
{
	// 1 mono模式 2 ILRuntime模式 3 mono热重载模式
	public enum CodeMode
	{
		Mono = 1,
		ILRuntime = 2,
		Reload = 3,
	}

	public partial class Init : Node
	{
		public Node Node { get; set; }

		public static Init Instance;

		public CodeMode CodeMode = CodeMode.Mono;

		public InputEvent InputEvent;

		public override void _Ready()
		{
			this.Node = this;

			Instance = this;
#if ENABLE_IL2CPP
			this.CodeMode = CodeMode.ILRuntime;
#endif

			System.AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
			{
				Log.Error(e.ExceptionObject.ToString());
			};

			SynchronizationContext.SetSynchronizationContext(ThreadSynchronizationContext.Instance);


			ETTask.ExceptionHandler += Log.Error;

			Log.ILog = new GodotLogger();

			Game.Start();

			Game.EventSystem.Publish(new ET.EventType.AppStart());
		}

		public override void _Process(double delta)
		{

			Game.Update();
			Game.LateUpdate();
		}


		private void OnApplicationQuit()
		{
			Game.Close();
		}

		public override void _Input(InputEvent inputEvent)
		{
			InputEvent = inputEvent;
			//Vector2 pos = GetViewport().GetMousePosition();
			////GetViewport().GetScreenTransform().
			//Camera3D camera = GetViewport().GetCamera3D();

			//Vector3 worldPos = camera.ProjectRayOrigin(pos) + camera.ProjectRayNormal(pos) * camera.GetZfar();
			//Vector3 ray = camera.ProjectRayNormal(pos) * (worldPos - camera.ProjectRayOrigin(pos)).Length();
			//var intersection = camera.GlobalTransform.IntersectsRay(camera.GlobalPosition, ray);

			//if (intersection != null)
			//{
			//	Vector3 intersectionPoint = intersection.Value.Position;
			//	GD.Print(intersectionPoint);
			//}
		}
	}
}
