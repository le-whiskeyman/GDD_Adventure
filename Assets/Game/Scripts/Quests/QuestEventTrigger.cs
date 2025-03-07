using UnityEngine;

namespace Game
{
    public class QuestEventTrigger : MonoBehaviour, ITriggerable
    {
		private QuestEvent questEvent;

		public void TriggerEnter(Character character)
		{
			Debug.Log("QuestEventTrigger:: Entered trigger for " + questEvent.Name);
			QuestController.Instance.EventTriggered(questEvent);
			GetComponent<Collider2D>().enabled = false;
		}

		public void SetEvent(QuestEvent newEvent) 
		{ 
			questEvent = newEvent;
		}
	}
}