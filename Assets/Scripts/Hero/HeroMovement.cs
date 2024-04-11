using Configuration;
using Input;
using JetBrains.Annotations;
using UniRx;
using UnityEngine;
using Utilities;

namespace Hero
{
	[UsedImplicitly]
	public class HeroMovement
	{
		private readonly Transform _transform;
		private readonly GameConfig _gameConfig;

		private readonly CompositeDisposable _lifetimeDisposables = new();
		
		public HeroMovement(Transform transform, GameConfig gameConfig, IPlayerInput playerInput)
		{
			_transform = transform;
			_gameConfig = gameConfig;
			
			playerInput.Delta
				.Where( d => d != Vector2.zero )
				.Subscribe( Move )
				.AddTo( _lifetimeDisposables );
		}

		private void Move(Vector2 delta)
		{
			Vector3 newPos = _transform.position + (Vector3)delta * _gameConfig.HeroSpeed * Time.deltaTime;
			float clampedX = Mathf.Clamp( newPos.x, ScreenWorld.Left, ScreenWorld.Right );
			float clampedY = Mathf.Clamp( newPos.y, ScreenWorld.Bottom, ScreenWorld.Top );
			Vector3 clampedPos = new Vector3( clampedX, clampedY, newPos.z );
			
			_transform.position = clampedPos;
		}
	}
}