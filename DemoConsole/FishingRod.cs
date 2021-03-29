using System;

namespace DemoConsole
{
    /// <summary>
    /// 鱼竿类 观察者
    /// </summary>
    public class FishingRod
    {
        public void ThrowHook(FishingMan man)
        {
            Console.WriteLine("开始下钩！");

            if (new Random().Next() % 2 == 0)
            {
                var type = (FishType)new Random().Next(0, 9);
                Console.WriteLine("铃铛：叮叮叮，鱼儿咬钩了！");
                var eventData = new FishingEventData() { FishType = type, FishingMan = man };
                EventBus.EventBus.Default.Trigger<FishingEventData>(eventData); //直接通过事件总线触发
            }
        }
    }
}
