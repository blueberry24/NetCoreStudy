﻿using System;

namespace EventBus
{
    /// <summary>
    /// 事件源：描述事件信息，用于参数传递
    /// </summary>
    public class EventData : IEventData
    {
        /// <summary>
        /// 事件发生的时间
        /// </summary>
        public DateTime EventTime { get; set; }
        /// <summary>
        /// 触发事件的对象
        /// </summary>
        public object EventSource { get; set; }
    }
}
