namespace DemoConsole
{
    /// <summary>
    /// 垂钓者 订阅者
    /// </summary>
    public class FishingMan
    {
        public FishingMan(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public int FishCount { get; set; }

        public FishingRod FishingRod { get; set; }

        public void Fishing()
        {
            this.FishingRod.ThrowHook(this);
        }
    }
}
