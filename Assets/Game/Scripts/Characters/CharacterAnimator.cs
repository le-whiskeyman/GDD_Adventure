using Game;
using UnityEngine;

namespace Game {
    public class CharacterAnimator : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;

        private string state;
        private Sprite[] sprites;
        private int spriteIndex = 0;
        private float delay = 1;
        private float frameTime;
        private bool looping;

		private void Update()
		{
            delay -= Time.deltaTime;
            if (delay <= 0)
            {
				delay = frameTime;
                spriteIndex++;
                if(spriteIndex >= sprites.Length)
                {
                    if (looping)
                    {
                        spriteIndex = 0;
                    }
                    else
                    {
                        delay = Mathf.Infinity;
                        return;
                    }
                }
                spriteRenderer.sprite = sprites[spriteIndex];
            }
		}

		public void SetAnimation(AnimationData aniData)
        {
            if (state == aniData.AnimationName) return;
            state = aniData.AnimationName;
            sprites = aniData.SpriteSequence;
			frameTime = aniData.FrameTime;
			delay = aniData.FrameTime;
            spriteRenderer.sprite = sprites[0];
            spriteIndex = 0;
            looping = aniData.Looping;
        }
    }
}