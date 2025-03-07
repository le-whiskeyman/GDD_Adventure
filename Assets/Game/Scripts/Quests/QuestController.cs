using TMPro;
using UnityEngine;

namespace Game
{
	public class QuestController : MonoBehaviour
	{
		public static QuestController Instance => instance;
		public static bool Active => instance.active;

		private static QuestController instance;

		[SerializeField] private RectTransform questTextContainer;
		[SerializeField] private TMP_Text txtSignTitle;
		[SerializeField] private TMP_Text txtSignText;
		[SerializeField] private Transform activeQuestContainer;
		[SerializeField] private TMP_Text activeQuestPrefab;

		private QuestData data;
		private bool active;
		private Vector2 questTextContainerPosition;
		private int eventTextIndex;
		private string[] activeDialog;  // Current set of text to cycle through
		private int questEventsIndex = 0; // Current Quest's quest event 

		private void Awake()
		{
			instance = this;
			questTextContainer.gameObject.SetActive(true);
		}

		private void Start()
		{
			questTextContainer.position = new Vector3(questTextContainer.position.x, -questTextContainer.rect.height, 0);
			questTextContainerPosition = questTextContainer.position;
		}

		public void AddQuest(QuestData newData)
		{
			data = newData;
			active = true;
			eventTextIndex = 0;
			txtSignTitle.text = data.Name;
			activeDialog = data.EventText;
			questEventsIndex = 0;
			if (activeDialog.Length > 0)
			{
				txtSignText.text = activeDialog[0];
			}

			// Add quest event trigger
			if (data.QuestEvents[questEventsIndex].QuestType == EQuestEventType.GoToLocation) 
			{
				QuestEvent_GoToLocation e = (QuestEvent_GoToLocation)data.QuestEvents[questEventsIndex];
				Debug.Log($"QuestController:: Adding event {questEventsIndex} : " + e.Name);
				GameObject t = Instantiate(e.QuestTriggertPrefab, WorldController.Instance.GetPositionOfType(new Vector2(e.PositionX, e.PositionY), new ETileEffect[] { ETileEffect.Walkable}), Quaternion.identity);
				t.GetComponent<QuestEventTrigger>().SetEvent(data.QuestEvents[questEventsIndex]);
			}

			// Add UI label
			TMP_Text label = Instantiate(activeQuestPrefab, activeQuestContainer);
			label.text = data.Name;
			label.gameObject.name = data.Name;
		}

		public void EventTriggered(QuestEvent questEvent)
		{
			if (data.QuestEvents[questEventsIndex].QuestType == EQuestEventType.GoToLocation)
			{
				QuestEvent_GoToLocation e = (QuestEvent_GoToLocation)data.QuestEvents[questEventsIndex];
				active = true;
				eventTextIndex = 0;
				txtSignTitle.text = e.Name;
				activeDialog = e.EventText;
				
				if (activeDialog.Length > 0)
				{
					txtSignText.text = activeDialog[0];
				}
				Debug.Log($"QuestController:: Adding event {questEventsIndex} : " + e.Name);
				questEventsIndex++;
				e = (QuestEvent_GoToLocation)data.QuestEvents[questEventsIndex];
				GameObject t = Instantiate(e.QuestTriggertPrefab, WorldController.Instance.GetPositionOfType(new Vector2(e.PositionX, e.PositionY), new ETileEffect[] { ETileEffect.Walkable }), Quaternion.identity);
				t.GetComponent<QuestEventTrigger>().SetEvent(data.QuestEvents[questEventsIndex]);
				
			}
			else if(data.QuestEvents[questEventsIndex].QuestType == EQuestEventType.CompleteQuest)
			{
				QuestEvent_GoToLocation e = (QuestEvent_GoToLocation)data.QuestEvents[questEventsIndex];
				Debug.Log("QuestController:: Complete event: " + e.Name);
				active = true;
				eventTextIndex = 0;
				txtSignTitle.text = e.Name;
				activeDialog = e.EventText;
				questEventsIndex = 0;
				if (activeDialog.Length > 0)
				{
					txtSignText.text = activeDialog[0];
				}
				// Add UI label
				Destroy(activeQuestContainer.Find(data.Name).gameObject);

			}
		}

		private void Update()
		{
			if (!active)
			{
				questTextContainerPosition = Vector3.Lerp(questTextContainerPosition, new Vector3(questTextContainerPosition.x, -questTextContainer.rect.height,0 ), Time.deltaTime * 4);
			}
			else
			{
				if(activeDialog.Length <= 0)
				{
					return;
				}

				questTextContainerPosition = Vector3.Lerp(questTextContainerPosition, new Vector3(questTextContainerPosition.x, 0, 0), Time.deltaTime * 4);

				if (Input.GetButtonDown("Jump"))
				{
					eventTextIndex++;
					if(eventTextIndex >= activeDialog.Length)
					{
						active = false;
						return;
					}
					txtSignText.text = activeDialog[eventTextIndex];
				}
			}
			questTextContainer.position = new Vector3(Mathf.Round(questTextContainerPosition.x / 15f) * 15, Mathf.Round(questTextContainerPosition.y / 15f) * 15);
		}
	}
}