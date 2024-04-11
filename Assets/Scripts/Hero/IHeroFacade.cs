using UnityEngine;

namespace Hero
{
	public interface IHeroFacade : IDamagable
	{
		Transform Transform { get; }
		Transform Muzzle { get; }
	}
}