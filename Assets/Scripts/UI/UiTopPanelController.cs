using System;
using Hero.Interfaces;
using JetBrains.Annotations;
using UI.Interfaces;
using UniRx;

namespace UI
{
	[UsedImplicitly]
	public class UiTopPanelController : IDisposable
	{
		private readonly CompositeDisposable _lifetimeDisposables = new();

		public UiTopPanelController(IUiTopPanelView uiTopPanelView, IHeroFacade heroFacade, IPauseScreen pauseScreen)
		{
			heroFacade.Health
				.Subscribe( h => uiTopPanelView.SetHealth( h, heroFacade.MaxHealth ) )
				.AddTo( _lifetimeDisposables );

			heroFacade.Score
				.Subscribe( uiTopPanelView.SetScore )
				.AddTo( _lifetimeDisposables );

			uiTopPanelView.OnPause
				.Subscribe( _ => pauseScreen.Show() )
				.AddTo( _lifetimeDisposables );
		}

		public void Dispose()
		{
			_lifetimeDisposables.Dispose();
		}
	}
}