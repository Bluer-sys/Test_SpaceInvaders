using Enemy.Interfaces;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace Enemy
{
	[UsedImplicitly]
	public class EnemyMovement : ITickable, IEnemyMovement
	{
		private Transform _transform;

		private float _speed;
		
		[Inject]
		private void Construct(Transform transform)
		{
			_transform = transform;
		}

		public void Tick()
		{
			_transform.Translate( _transform.up * _speed * Time.deltaTime, Space.World );
		}

		public void SetSpeed(float speed)
		{
			_speed = speed;
		}
	}
}