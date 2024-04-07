using Data;
using JetBrains.Annotations;
using UniRx;
using UnityEngine;
using Zenject;

namespace Input
{
	[UsedImplicitly]
	public class PlayerInput : IPlayerInput, ITickable
	{
		private Vector2 _prevMousePos;

		public ReactiveProperty<Vector2> Delta { get; } = new();

		public PlayerInput(GameConfig gameConfig)
		{
			_prevMousePos = UnityEngine.Input.mousePosition;
		}

		public void Tick()
		{
			Vector2 curMousePos = UnityEngine.Input.mousePosition;
            
			if ( UnityEngine.Input.GetMouseButton( 0 ) )
			{
				Vector2 delta = curMousePos - _prevMousePos;

				Delta.Value = delta.magnitude < float.Epsilon 
					? Vector2.zero 
					: delta;
			}
			
			_prevMousePos = curMousePos;
		}
	}
}