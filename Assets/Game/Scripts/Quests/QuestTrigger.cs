using UnityEngine;

namespace Game
{
    public class QuestTrigger : MonoBehaviour, ITriggerable
    {
        [SerializeField] private QuestData questData;
		[Tooltip("The location the player needs to go to on the map, as a " +
			"value between 0 - 1 on each axis")]
		[Range(0f, 1f)] public float PositionX;

		[Tooltip("The location the player needs to go to on the map, as a " +
			"value between 0 - 1 on each axis")]
		[Range(0f, 1f)] public float PositionY;

		private void Awake()
		{
			WorldController.OnWorldGenerate += MoveTrigger;
		}

		private void MoveTrigger()
		{
			WorldController.OnWorldGenerate -= MoveTrigger;
			transform.position = WorldController.Instance.GetPositionOfType(new Vector2(PositionX, PositionY), new ETileEffect[] { ETileEffect.Walkable });
		}

		public void TriggerEnter(Character character)
		{
			Debug.Log("QuestTrigger:: Entered trigger for " + questData.Name);
			QuestController.Instance.AddQuest(questData);
			GetComponent<Collider2D>().enabled = false;
		}
	}
}