using System;
using JetBrains.Annotations;
using UI.Interfaces;
using UniRx;
using Unit.Interfaces;

namespace UI
{
	[UsedImplicitly]
	public class UiEnemyController : IDisposable
	{
		private readonly CompositeDisposable _lifetimeDisposable = new();

		public UiEnemyController(IUiEnemyView uiEnemyView, IUnitHealth unitHealth)
		{
			unitHealth.IsDead
				.Subscribe( isDead => uiEnemyView.SetActive( !isDead ) )
				.AddTo( _lifetimeDisposable );

			unitHealth.Health
				.Subscribe( hp => uiEnemyView.SetHealth( hp, unitHealth.MaxHealth ) )
				.AddTo( _lifetimeDisposable );
		}

		public void Dispose()
		{
			_lifetimeDisposable.Dispose();
		}
	}
}