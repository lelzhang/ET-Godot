using System;
using System.Collections.Generic;

namespace ET
{
    public static class Game
    {
        public static string str => "Game";
        public static ThreadSynchronizationContext ThreadSynchronizationContext => ThreadSynchronizationContext.Instance;

        public static TimeInfo TimeInfo => TimeInfo.Instance;

        public static EventSystem EventSystem => EventSystem.Instance;

        private static Scene scene;
        public static Scene Scene
        {
            get
            {
                if (scene != null)
                {
                    return scene;
                }
                scene = EntitySceneFactory.CreateScene(IdGenerater.Instance.GenerateInstanceId(), 0, SceneType.Process, "Process");
                return scene;
            }
        }

        public static ObjectPool ObjectPool => ObjectPool.Instance;

        public static IdGenerater IdGenerater => IdGenerater.Instance;

        public static Options Options => Options.Instance;

        public static ILog ILog;

        public static List<Action> FrameFinishCallback = new List<Action>();
        public static void Start()
        {
            Options.Instance = new Options();
            scene = EntitySceneFactory.CreateScene(IdGenerater.Instance.GenerateInstanceId(), 0, SceneType.Process, "Process");
#if !NOT_UNITY
            EventSystem.Init();
#endif
            //queue = new Queue<int>();
            //queue2 = new Queue<int>();
            //foreach (var item in new List<int>() { 1, 2, 3, 4, 5 })
            //{


            //    queue.Enqueue(item);
            //}
        }


        //public static void TestUpdate()
        //{
        //    while (queue.Count > 0)
        //    {
        //        int i = queue.Dequeue();
        //        queue2.Enqueue(i);
        //    }
        //    ObjectHelper.Swap(ref queue, ref queue2);
        //}
        public static void Update()
        {
            ThreadSynchronizationContext.Update();
            TimeInfo.Update();
            EventSystem.Update();
        }
       
        public static void LateUpdate()
        {
            EventSystem.LateUpdate();
        }


        //Server使用
        public static void FrameFinish()
        {
            foreach (Action action in FrameFinishCallback)
            {
                action.Invoke();
            }
            FrameFinishCallback.Clear();
        }

        public static void Close()
        {
            scene?.Dispose();
            scene = null;
            MonoPool.Instance.Dispose();
            EventSystem.Instance.Dispose();
            IdGenerater.Instance.Dispose();
        }
    }
}