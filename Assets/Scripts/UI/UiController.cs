using System;
using Hero.Interfaces;
using JetBrains.Annotations;
using UI.Interfaces;
using UniRx;

namespace UI
{
	[UsedImplicitly]
	public class UiController : IDisposable
	{
		private readonly CompositeDisposable _lifetimeDisposables = new();

		public UiController(IUiView uiView, IHeroFacade heroFacade)
		{
			heroFacade.Health
				.Subscribe( h => uiView.SetHealth( h, heroFacade.MaxHealth ) )
				.AddTo( _lifetimeDisposables );

			heroFacade.Score
				.Subscribe( uiView.SetScore )
				.AddTo( _lifetimeDisposables );
		}

		public void Dispose()
		{
			_lifetimeDisposables.Dispose();
		}
	}
}