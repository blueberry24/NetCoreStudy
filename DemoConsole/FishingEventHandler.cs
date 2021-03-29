using EventBus;
using System;

namespace DemoConsole
{
    public class FishingEventHandler : IEventHandler<FishingEventData>
    {
        public void HandleEvent(FishingEventData eventData)
        {
            eventData.FishingMan.FishCount++;
            Console.WriteLine($"{eventData.FishingMan.Name}：钓到一条 [{eventData.FishType}]，一共钓了 {eventData.FishingMan.FishCount} 条啦~");
        }
    }
}
