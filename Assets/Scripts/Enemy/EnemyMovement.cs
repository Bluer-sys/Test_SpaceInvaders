using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace Enemy
{
	[UsedImplicitly]
	public class EnemyMovement : ITickable
	{
		private Transform _transform;

		[Inject]
		private void Construct(Transform transform)
		{
			_transform = transform;
		}

		public void Tick()
		{
			var speed = 3f;
			
			_transform.Translate( _transform.up * speed * Time.deltaTime, Space.World );
		}
	}
}