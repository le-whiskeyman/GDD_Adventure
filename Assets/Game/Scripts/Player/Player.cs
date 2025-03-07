using UnityEngine;

namespace Game
{
	public class Player : Character
	{
		private Vector3 movement;
		private Tile onTile;

		protected override void Start()
		{
			base.Start();
			transform.position = WorldController.Instance.GetWalkablePosition(new Vector2(0.5f, 0.5f));
			position = transform.position;
		}

		protected override void Move()
		{
			if (health <= 0 || QuestController.Active)
			{				
				return;
			}

			if (onTile)
			{
				if (onTile.Effect == ETileEffect.Walkable)
					movement = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0).normalized * data.WalkSpeed * Time.deltaTime;
				else if (onTile.Effect == ETileEffect.Slide)
					movement = Vector3.Lerp(movement, new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0).normalized * walkSpeed * Time.deltaTime,data.IceFrictionMultiplier * Time.deltaTime);
				else if (onTile.Effect == ETileEffect.Slow)
					movement = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0).normalized * walkSpeed * data.SlowSpeedMultiplier * Time.deltaTime;
			}
			

			// l/r tile
			Collider2D[] hits = Physics2D.OverlapBoxAll(position + new Vector3(movement.x,0,0), Vector2.one * 0.1f, 0);
			for(int i = 0; i < hits.Length; i++)
			{
				Tile t = hits[i].GetComponent<Tile>();
                if (t)
                {
					if(t.Effect == ETileEffect.Kill)
					{
						TakeDamage(Mathf.Infinity, TypeEnum.Fire);
						return;
					}
					if (t.Effect == ETileEffect.Blocking)
					{
						movement.x = 0;
					}
				}
			}
			// u/d tile
			hits = Physics2D.OverlapBoxAll(position + new Vector3(0, movement.y, 0), Vector2.one * 0.1f, 0);
			for (int i = 0; i < hits.Length; i++)
			{
				Tile t = hits[i].GetComponent<Tile>();
				if (t)
				{
					if (t.Effect == ETileEffect.Kill)
					{
						TakeDamage(Mathf.Infinity, TypeEnum.Fire);
						return;
					}
					if (t.Effect == ETileEffect.Blocking)
					{
						movement.y = 0;
					}
				}
			}

			// move
			position += movement;
			transform.position = new Vector3(Mathf.Round(position.x), Mathf.Round(position.y), 0);

			// get onTile
			hits = Physics2D.OverlapBoxAll(transform.position, Vector2.one * 0.1f, 0);
			for (int i = 0; i < hits.Length; i++)
			{
				Tile t = hits[i].GetComponent<Tile>();
				if (t)
				{
					onTile = t;
					break;
				}

				ITriggerable trigger = hits[i].GetComponent<ITriggerable>();
				if (trigger != null)
				{
					trigger.TriggerEnter(this);
				}
			}

			// animate
			if(movement.sqrMagnitude > 0f)
			{
				animator.SetAnimation(data.WalkAnimationData);
			}
			else
			{
				animator.SetAnimation(data.IdleAnimationData);
			}
		}

		protected override void Die()
		{
			Debug.Log("Player:: Player died!");
			animator.SetAnimation(data.DeathAnimationData);
		}
	}
}