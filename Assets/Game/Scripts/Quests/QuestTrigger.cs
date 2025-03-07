using UnityEngine;

namespace Game
{
    public class QuestTrigger : MonoBehaviour, ITriggerable
    {
        [SerializeField] private QuestData questData;

		private void Awake()
		{
			WorldController.OnWorldGenerate += MoveTrigger;
		}

		private void MoveTrigger()
		{
			WorldController.OnWorldGenerate -= MoveTrigger;
			transform.position = WorldController.Instance.GetPositionOfType(new Vector2(0.55f, 0.51f), new ETileEffect[] { ETileEffect.Walkable });
		}

		public void TriggerEnter(Character character)
		{
			Debug.Log("QuestTrigger:: Entered trigger for " + questData.Name);
			QuestController.Instance.AddQuest(questData);
			GetComponent<Collider2D>().enabled = false;
		}
	}
}