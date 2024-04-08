using UnityEngine;

namespace Hero
{
	public class HeroFacade : MonoBehaviour, IHeroFacade
	{
		public Transform Transform => transform;

		public void TakeDamage(int damage)
		{
			
		}
	}
}