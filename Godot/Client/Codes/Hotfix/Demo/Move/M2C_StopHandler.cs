using Godot;

namespace ET
{
	[MessageHandler]
	public class M2C_StopHandler : AMHandler<M2C_Stop>
	{
		protected override void Run(Session session, M2C_Stop message)
		{
			Unit unit = session.DomainScene().CurrentScene().GetComponent<UnitComponent>().Get(message.Id);
			if (unit == null)
			{
				return;
			}

			Vector3 pos = new Vector3(message.X, message.Y, message.Z);
			//这里是右手坐标系，-z为正方向，quaternion.w 取负数即可
			Quaternion rotation = new Quaternion(message.A, message.B, message.C, -message.W);

			MoveComponent moveComponent = unit.GetComponent<MoveComponent>();
			moveComponent.Stop();
			var oldPosition = unit.Position;
			unit.Position = pos;
			//距离很近的时候旋转表现不好，但是是服务器权威数据，表现与权威作取舍吧
			if (oldPosition.DistanceSquaredTo(pos) > 0.01f)
			{
				unit.Rotation = rotation;
			}
			unit.GetComponent<ObjectWait>()?.Notify(new WaitType.Wait_UnitStop() {Error = message.Error});
		}
	}
}
