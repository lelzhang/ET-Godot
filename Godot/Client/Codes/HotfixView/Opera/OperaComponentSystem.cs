using System;
using Godot;

namespace ET
{
    [ObjectSystem]
    public class OperaComponentAwakeSystem : AwakeSystem<OperaComponent>
    {
        public override void Awake(OperaComponent self)
        {
        }
    }

    [ObjectSystem]
    public class OperaComponentUpdateSystem : UpdateSystem<OperaComponent>
    {
        public override void Update(OperaComponent self)
        {
            self.Update();
        }
    }

    [FriendClass(typeof(OperaComponent))]
    public static class OperaComponentSystem
    {
        public static void Update(this OperaComponent self)
        {
        //    if (Input.IsMouseButtonPressed(MouseButton.Left))
        //    {
        //        InputEventMouse inputEventMouse = Input.mou
        //        inputEventMouse
        //        Vector2 mouseInput = new Vector2(..X, motion.Relative.Y);

        //        Vector3 cameraTarget += new Vector3(-motion.Relative.Y * mouseSensitivity, -motion.Relative.X * mouseSensitivity, 0);
        //        if (Physics.Raycast(ray, out hit, 1000, self.mapMask))
        //        {
        //            self.ClickPoint = hit.point;
        //            self.frameClickMap.X = self.ClickPoint.X;
        //            self.frameClickMap.Y = self.ClickPoint.Y;
        //            self.frameClickMap.Z = self.ClickPoint.Z;
        //            self.ZoneScene().GetComponent<SessionComponent>().Session.Send(self.frameClickMap);
        //        }
        //    }

        //    // KeyCode.R
        //    if (InputHelper.GetKeyDown(114))
        //    {
        //        CodeLoader.Instance.LoadLogic();
        //        Game.EventSystem.Add(CodeLoader.Instance.GetHotfixTypes());
        //        Game.EventSystem.Load();
        //        Log.Debug("hot reload success!");
        //    }

        //    // KeyCode.T
        //    if (InputHelper.GetKeyDown(116))
        //    {
        //        C2M_TransferMap c2MTransferMap = new C2M_TransferMap();
        //        self.ZoneScene().GetComponent<SessionComponent>().Session.Call(c2MTransferMap).Coroutine();
        //    }
        }
    }
}