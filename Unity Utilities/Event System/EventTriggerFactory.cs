using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityUtilities.Input
{
    public static class EventTriggerFactory
    {
        public static void Create(GameObject gameObject, params EventTriggerData[] eventTriggers)
        {
            EventTrigger eventTrigger = gameObject.AddComponent<EventTrigger>();
            foreach (EventTriggerData eventTriggerData in eventTriggers)
            {
                EventTrigger.Entry entry = new EventTrigger.Entry
                {
                    eventID = eventTriggerData.Type
                };

                entry.callback.AddListener(eventData => { eventTriggerData.OnEventTrigger(eventData); });
                eventTrigger.triggers.Add(entry);
            }
        }
    }
}
