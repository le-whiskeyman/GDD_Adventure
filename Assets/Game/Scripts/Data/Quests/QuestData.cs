using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "QuestData", menuName = "Data/Quests/QuestData")]
    public class QuestData : ScriptableObject
    {
        [Tooltip("Name of the quest")]
        public string Name;

        [Tooltip("Description of the quest, shown to the player when it begins")]
        [TextArea()] public string Description;

		[Tooltip("Initial text to display when starting this quest")]
		[TextArea()] public string[] EventText;

		[Tooltip("List of Quest Events belonging to this Quest")]
        public List<QuestEvent> QuestEvents = new List<QuestEvent>();
    }
}