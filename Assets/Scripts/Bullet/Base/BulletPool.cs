using Zenject;

namespace Bullet.Base
{
	public class BulletPool : MonoMemoryPool<BulletSettings, BulletBase>
	{
		protected override void Reinitialize(BulletSettings settings, BulletBase bullet)
		{
			bullet.Initialize(settings);
		}
	}
}