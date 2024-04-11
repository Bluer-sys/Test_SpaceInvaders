using UnityEngine;

namespace Hero
{
	public class HeroFacade : MonoBehaviour, IHeroFacade
	{
		[SerializeField]
		private Transform _muzzle;
		
		public Transform Transform => transform;
		
		public Transform Muzzle => _muzzle;

		public void TakeDamage(int damage)
		{
		}

		public void Kill()
		{
			Destroy( gameObject );
		}
	}
}