using UniRx;
using UnityEngine;

namespace Input
{
	public interface IPlayerInput
	{
		ReactiveProperty<Vector2> Delta { get; }
	}
}