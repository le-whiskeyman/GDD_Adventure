using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "CharacterData", menuName = "Data/Character/CharacterData")]
    public class CharacterData : ScriptableObject
    {
        [Header("Movement")]
        [Tooltip("How fast the character should walk.")]
        public float WalkSpeed;
        [Tooltip("How fast movement should correct on SLIDE tiles.")]
        [Range(0.01f, 100f)] public float IceFrictionMultiplier;
		[Tooltip("Movement multiplier on SLOW tiles.")]
		[Range(0.01f, 1f)] public float SlowSpeedMultiplier;

		[Header("Combat")]
        [Tooltip("Maximum health, also starting health.")]
        public float MaxHealth;

        [Header("Animation")]
        public AnimationData IdleAnimationData;
        public AnimationData WalkAnimationData;
		public AnimationData DeathAnimationData;

	}
}
