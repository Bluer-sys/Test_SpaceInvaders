using System.Collections.Generic;
using JetBrains.Annotations;
using Zenject;

namespace Bullet
{
	[UsedImplicitly]
	public class BulletPool : MonoMemoryPool<BulletModel, Bullet>
	{
		private readonly List<Bullet> _spawnedBullets = new();
		
		public IReadOnlyList<Bullet> SpawnedBullets => _spawnedBullets;
		
		protected override void OnSpawned(Bullet bullet)
		{
			base.OnSpawned( bullet );
			
			_spawnedBullets.Add( bullet );
		}

		protected override void OnDespawned(Bullet bullet)
		{
			base.OnDespawned( bullet );
			
			_spawnedBullets.Remove( bullet );
		}

		protected override void Reinitialize(BulletModel model, Bullet bullet)
		{
			bullet.Initialize(model);
		}
	}
}