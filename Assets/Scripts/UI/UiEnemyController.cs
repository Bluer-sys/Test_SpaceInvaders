using System;
using Enemy.Interfaces;
using JetBrains.Annotations;
using UniRx;

namespace UI
{
	[UsedImplicitly]
	public class UiEnemyController : IDisposable
	{
		private readonly CompositeDisposable _lifetimeDisposable = new();

		public UiEnemyController(IUiEnemyView uiEnemyView, IEnemyHealth enemyHealth)
		{
			enemyHealth.IsDead
				.Subscribe( isDead => uiEnemyView.SetActive( !isDead ) )
				.AddTo( _lifetimeDisposable );

			enemyHealth.Health
				.Subscribe( hp => uiEnemyView.SetHealth( hp, enemyHealth.MaxHealth ) )
				.AddTo( _lifetimeDisposable );
		}

		public void Dispose()
		{
			_lifetimeDisposable.Dispose();
		}
	}
}