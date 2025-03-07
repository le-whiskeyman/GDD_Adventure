using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	[RequireComponent(typeof(CharacterAnimator))]
	public abstract class Character : MonoBehaviour, IDamagable
	{
		[SerializeField] protected CharacterData data;
		[SerializeField] protected Inventory inventory = new Inventory();
		protected float walkSpeed;
		protected float health;
		protected Vector3 position;     // Holds position data, actual position is rounded to snap to grid
		protected CharacterAnimator animator;

		protected virtual void Awake()
		{
			health = data.MaxHealth;
			walkSpeed = data.WalkSpeed;
		}

		protected virtual void Start()
		{
			animator = GetComponent<CharacterAnimator>();
			animator.SetAnimation(data.IdleAnimationData);
		}

		private void Update()
		{
			Move();
		}

		public virtual void TakeDamage(float damage, TypeEnum damageType)
		{
			health -= damage;
			if(health < 0 ) { Die(); }
		}

		protected abstract void Die();

		protected abstract void Move();
	}
}