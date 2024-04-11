using Hero.Interfaces;
using UniRx;
using Unit.Interfaces;
using UnityEngine;
using Zenject;

namespace Hero
{
	public class HeroFacade : MonoBehaviour, IHeroFacade
	{
		[SerializeField]
		private Transform _muzzle;

		private IUnitHealth _unitHealth;
		private IHeroDataStorage _heroDataStorage;

		public Transform Transform => transform;
		
		public Transform Muzzle => _muzzle;
		
		public int MaxHealth => _unitHealth.MaxHealth;

		public BoolReactiveProperty IsDead => _unitHealth.IsDead;
		
		public IntReactiveProperty Score => _heroDataStorage.Score;

		public IntReactiveProperty Health => _unitHealth.Health;

		[Inject]
		private void Construct(IUnitHealth unitHealth, IHeroDataStorage heroDataStorage)
		{
			_unitHealth = unitHealth;
			_heroDataStorage = heroDataStorage;
		}
		
		public void TakeDamage(int damage)
		{
			_unitHealth.TakeDamage( damage );
		}
	}
}