using System.Collections.Generic;
using Godot;

namespace ET
{
	[MessageHandler]
	public class M2C_PathfindingResultHandler : AMHandler<M2C_PathfindingResult>
	{
		protected override void Run(Session session, M2C_PathfindingResult message)
		{
			Unit unit = session.DomainScene().CurrentScene().GetComponent<UnitComponent>().Get(message.Id);

			float speed = unit.GetComponent<NumericComponent>().GetAsFloat(NumericType.Speed);

			ListComponent<Vector3> list = ListComponent<Vector3>.Create();
			{
				for (int i = 0; i < message.Xs.Count; ++i)
				{
					Log.Debug($"Move pos:{message.Xs[i]}");
					list.Add(new Vector3(message.Xs[i], message.Ys[i], message.Zs[i]));
				}

				unit.GetComponent<MoveComponent>().MoveToAsync(list, speed).Coroutine();
			}
		}
	}
}
