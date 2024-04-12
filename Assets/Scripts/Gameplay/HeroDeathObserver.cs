using Hero.Interfaces;
using JetBrains.Annotations;
using UniRx;
using UnityEngine;
using Zenject;

namespace Gameplay
{
	[UsedImplicitly]
	public class HeroDeathObserver : IInitializable
	{
		private readonly IHeroFacade _heroFacade;
		
		private readonly CompositeDisposable _lifetimeDisposable = new();

		public HeroDeathObserver(IHeroFacade heroFacade)
		{
			_heroFacade = heroFacade;
		}

		public void Initialize()
		{
			_heroFacade.IsDead
				.Where( v => v )
				.Subscribe( _ => OnHeroDead() )
				.AddTo( _lifetimeDisposable );
		}

		private void OnHeroDead()
		{
			Object.Destroy( _heroFacade.Transform.gameObject );
		}
	}
}