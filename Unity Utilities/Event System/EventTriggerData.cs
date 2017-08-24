using System;
using UnityEngine.EventSystems;

namespace UnityUtilities.Input
{
    public struct EventTriggerData
    {
        public EventTriggerType Type { get; }

        private readonly Action<BaseEventData> eventTrigger;
        public void OnEventTrigger(BaseEventData eventData)
        {
            eventTrigger?.Invoke(eventData);
        }

        public EventTriggerData(EventTriggerType type, Action<BaseEventData> eventTrigger)
        {
            Type = type;
            this.eventTrigger = eventTrigger;
        }
    }
}
