using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "GoToLocation", menuName = "Data/Quests/GoToLocation")]
    public class QuestEvent_GoToLocation : QuestEvent
    {
        [Tooltip("The location the player needs to go to on the map, as a " +
            "value between 0 - 1 on each axis")]
        [Range(0f, 1f)] public float PositionX;
		
        [Tooltip("The location the player needs to go to on the map, as a " +
			"value between 0 - 1 on each axis")]
        [Range(0f, 1f)] public float PositionY;

        [Tooltip("List of text to show player at event")]
        [TextArea()] public string[] EventText;

		[Tooltip("Quest Trigger prefab player needs to find")]
		public GameObject QuestTriggertPrefab;

	}
}