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
		private readonly IUiEnemyView _uiEnemyView;
		private readonly IUnitHealth _unitHealth;
		
		private readonly CompositeDisposable _lifetimeDisposable = new();

		public UiEnemyController(IUiEnemyView uiEnemyView, IUnitHealth unitHealth)
		{
			_uiEnemyView = uiEnemyView;
			_unitHealth = unitHealth;
			unitHealth.IsDead
				.Subscribe( isDead => uiEnemyView.SetActive( !isDead ) )
				.AddTo( _lifetimeDisposable );

			unitHealth.Health
				.Subscribe( OnHealthChanged )
				.AddTo( _lifetimeDisposable );
		}

		private void OnHealthChanged(int hp)
		{
			_uiEnemyView.SetHealth( hp, _unitHealth.MaxHealth );
			_uiEnemyView.SetActive( hp != _unitHealth.MaxHealth );
		}

		public void Dispose()
		{
			_lifetimeDisposable.Dispose();
		}
	}
}