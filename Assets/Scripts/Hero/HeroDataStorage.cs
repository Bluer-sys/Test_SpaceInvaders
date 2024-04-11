using System;
using Enemy.Interfaces;
using Hero.Interfaces;
using JetBrains.Annotations;
using UniRx;

namespace Hero
{
	[UsedImplicitly]
	public class HeroDataStorage : IDisposable, IHeroDataStorage
	{
		public IntReactiveProperty Score { get; } = new();
		
		private readonly CompositeDisposable _lifetimeDisposables = new();

		public HeroDataStorage(IEnemySpawner enemySpawner)
		{
			enemySpawner.OnEnemyDead
				.Subscribe( enemy => Score.Value += enemy.Reward )
				.AddTo( _lifetimeDisposables );
		}

		public void Dispose()
		{
			_lifetimeDisposables.Dispose();
		}
	}
}