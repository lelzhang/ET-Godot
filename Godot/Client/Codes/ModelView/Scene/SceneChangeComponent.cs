using Godot;
using System.ComponentModel;

namespace ET
{
    [ComponentOf(typeof(Scene))]
    public class SceneChangeComponent: Entity, IAwake, IUpdate, IDestroy
    {
        public AsyncOperation loadMapOperation;
        public ETTask tcs;
    }
}