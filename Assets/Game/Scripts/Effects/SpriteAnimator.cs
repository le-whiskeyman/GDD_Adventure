using UnityEngine;

namespace Game
{
    [RequireComponent (typeof (SpriteRenderer))]
    public class SpriteAnimator : MonoBehaviour
    {
		[SerializeField] private float frameTime;
		[SerializeField] private Sprite[] sprites;
		[SerializeField] private bool loop;

		private SpriteRenderer spriteRenderer;
		private float delay;
		private int spriteIndex;

		private void Awake()
		{
			spriteRenderer = GetComponent<SpriteRenderer> ();
		}

		private void Update()
		{
			delay -= Time.deltaTime;
			if (delay >= 0)
			{
				delay = frameTime;
				spriteIndex += 1;
				if(spriteIndex >= sprites.Length) spriteIndex = 0;
				spriteRenderer.sprite = sprites[spriteIndex];
			}
		}
	}
}
