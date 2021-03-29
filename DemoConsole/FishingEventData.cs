using EventBus;

namespace DemoConsole
{
    /// <summary>
    /// 事件参数
    /// </summary>
    public class FishingEventData : EventData
    {
        public FishType FishType { get; set; }

        public FishingMan FishingMan { get; set; }
    }
}
