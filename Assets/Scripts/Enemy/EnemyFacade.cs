using UnityEngine;

namespace Enemy
{
	public class EnemyFacade : MonoBehaviour, IEnemyFacade
	{
		private int _hp = 3;
		
		public void TakeDamage(int damage)
		{
			_hp -= damage;
			
			if (_hp <= 0)
			{
				Destroy(gameObject);
			}
		}
	}
}