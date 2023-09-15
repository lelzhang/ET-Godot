using Godot;

namespace ET
{
    [Event]
    public class ChangePosition_NotifyAOI: AEventClass<EventType.ChangePosition>
    {
        protected override void Run(object changePosition)
        {
            EventType.ChangePosition args = changePosition as EventType.ChangePosition;
            Vector3 oldPos = args.OldPos;
            Unit unit = args.Unit;
            int oldCellX = (int) (oldPos.X * 1000) / AOIManagerComponent.CellSize;
            int oldCellY = (int) (oldPos.Z * 1000) / AOIManagerComponent.CellSize;
            int newCellX = (int) (unit.Position.X * 1000) / AOIManagerComponent.CellSize;
            int newCellY = (int) (unit.Position.Z * 1000) / AOIManagerComponent.CellSize;
            if (oldCellX == newCellX && oldCellY == newCellY)
            {
                return;
            }

            AOIEntity aoiEntity = unit.GetComponent<AOIEntity>();
            if (aoiEntity == null)
            {
                return;
            }

            unit.Domain.GetComponent<AOIManagerComponent>().Move(aoiEntity, newCellX, newCellY);
        }
    }
}