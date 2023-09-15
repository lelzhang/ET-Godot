using Godot;
namespace ET
{
    [ObjectSystem]
    public class GlobalComponentAwakeSystem: AwakeSystem<GlobalComponent>
    {
        public override void Awake(GlobalComponent self)
        {
            GlobalComponent.Instance = self;

            self.Global = Init.Instance.Node;
            self.Unit = self.Global.GetNode<Node3D>("UnitRoot");
            self.UI = self.Global.GetNode<Node2D>("UIRoot");
            //self.NormalLayer = self.Global.GetNode<CanvasLayer>("UIRoot/Normal");
            self.NormalLayer = self.UI.GetNode<CanvasLayer>("Normal");
            self.PopUpLayer = self.Global.GetNode<CanvasLayer>("UIRoot/PopUp");
            self.LoadingLayer = self.Global.GetNode<CanvasLayer>("UIRoot/Loading");
        }
    }
}