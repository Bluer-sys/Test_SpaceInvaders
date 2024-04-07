using Data;
using Input;
using JetBrains.Annotations;
using UniRx;
using UnityEngine;

namespace Hero
{
	[UsedImplicitly]
	public class HeroMovement
	{
		private readonly Transform _transform;
		private readonly GameConfig _gameConfig;

		private readonly CompositeDisposable _lifetimeDisposables = new();
		
		private Vector3 _minBorder;
		private Vector3 _maxBorder;

		public HeroMovement(Transform transform, GameConfig gameConfig, IPlayerInput playerInput)
		{
			_transform = transform;
			_gameConfig = gameConfig;
			
			CalcBorders();

			playerInput.Delta
				.Where( d => d != Vector2.zero )
				.Subscribe( Move )
				.AddTo( _lifetimeDisposables );
		}

		private void CalcBorders()
		{
			var camera = Camera.main;
			
			_minBorder = camera!.ViewportToWorldPoint( new Vector3( 0, 0, 0 ) );
			_maxBorder = camera.ViewportToWorldPoint( new Vector3( 1, 1, 0 ) );
		}

		private void Move(Vector2 delta)
		{
			Vector3 newPos = _transform.position + (Vector3)delta * _gameConfig.HeroSpeed * Time.deltaTime;
			float clampedX = Mathf.Clamp( newPos.x, _minBorder.x, _maxBorder.x );
			float clampedY = Mathf.Clamp( newPos.y, _minBorder.y, _maxBorder.y );
			Vector3 clampedPos = new Vector3( clampedX, clampedY, newPos.z );
			
			_transform.position = clampedPos;
		}
	}
}