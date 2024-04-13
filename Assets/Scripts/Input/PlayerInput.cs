using JetBrains.Annotations;
using UniRx;
using UnityEngine;
using Zenject;

namespace Input
{
	[UsedImplicitly]
	public class PlayerInput : IPlayerInput, ITickable
	{
		private Vector2 _prevInputPos;
		private bool _beginTouchHappened;
		
		public ReactiveProperty<Vector2> Delta { get; } = new();

		public void Tick()
		{
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
			MobileInput();
#else
			DesktopInput();
#endif
		}
		
		private void MobileInput()
		{
			if ( UnityEngine.Input.touchCount == 0 )
			{
				_beginTouchHappened = false;
				return;
			}

			Vector2 curTouchPos = UnityEngine.Input.GetTouch( 0 ).position;

			if ( !_beginTouchHappened )
			{
				BeginTouch( curTouchPos );
				_beginTouchHappened = true;
				return;
			}

			SetDelta( curTouchPos );
			_prevInputPos = curTouchPos;
		}

		private void DesktopInput()
		{
			Vector2 curMousePos = UnityEngine.Input.mousePosition;
            
			if ( UnityEngine.Input.GetMouseButton( 0 ) )
			{
				SetDelta( curMousePos );
			}
			
			_prevInputPos = curMousePos;
		}

		private void BeginTouch(Vector2 curTouchPos)
		{
			_prevInputPos = curTouchPos;
		}

		private void SetDelta(Vector2 curInputPos)
		{
			Vector2 delta = curInputPos - _prevInputPos;
			
			Delta.Value = delta.magnitude < float.Epsilon 
				? Vector2.zero 
				: delta;
		}
	}
}