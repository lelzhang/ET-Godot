

using Godot;

namespace ET
{
    [ComponentOf(typeof(Scene))]
    public class GlobalComponent: Entity, IAwake
    {
        public static GlobalComponent Instance;
        
        public Node Global { get; set; }
        public Node3D Unit { get; set; }
        public Node2D UI { get; set; }
        public CanvasLayer NormalLayer { get; set; }
        public CanvasLayer PopUpLayer { get; set; }
        public CanvasLayer LoadingLayer { get; set; }
    }
}