using UnityEngine;

namespace Game
{
    
    public abstract class QuestEvent : ScriptableObject
    {
        [Tooltip("Name of this Quest Event")]
        public string Name;
        [Tooltip("The type of event")]
        public EQuestEventType QuestType;
    }
}