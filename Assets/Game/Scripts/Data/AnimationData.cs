using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "CharacterAnimationData", menuName = "Data/Character/CharacterAnimationData")]
    public class AnimationData : ScriptableObject
    {
        public string AnimationName;
        public Sprite[] SpriteSequence;
        public float FrameTime;
        public bool Looping = true;
    }
}