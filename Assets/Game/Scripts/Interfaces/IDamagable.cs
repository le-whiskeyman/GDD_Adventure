using UnityEngine;

namespace Game
{
	public interface IDamagable
	{
		public void TakeDamage(float damage, TypeEnum damageType = TypeEnum.Basic);
	}
}