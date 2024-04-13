using System;
using Hero.Interfaces;
using JetBrains.Annotations;
using UI.Interfaces;
using UniRx;
using Zenject;

namespace UI
{
	[UsedImplicitly]
	public class UiTopPanelController : IInitializable, IDisposable
	{
		private readonly IUiTopPanelView _uiTopPanelView;
		private readonly IHeroFacade _heroFacade;
		private readonly IPauseScreen _pauseScreen;
		
		private readonly CompositeDisposable _lifetimeDisposables = new();

		public UiTopPanelController(IUiTopPanelView uiTopPanelView, IHeroFacade heroFacade, IPauseScreen pauseScreen)
		{
			_uiTopPanelView = uiTopPanelView;
			_heroFacade = heroFacade;
			_pauseScreen = pauseScreen;
		}

		public void Initialize()
		{
			_heroFacade.Health
				.Subscribe( h => _uiTopPanelView.SetHealth( h, _heroFacade.MaxHealth ) )
				.AddTo( _lifetimeDisposables );

			_heroFacade.Score
				.Subscribe( _uiTopPanelView.SetScore )
				.AddTo( _lifetimeDisposables );

			_uiTopPanelView.OnPause
				.Subscribe( _ => _pauseScreen.Show() )
				.AddTo( _lifetimeDisposables );
		}

		public void Dispose()
		{
			_lifetimeDisposables.Dispose();
		}
	}
}