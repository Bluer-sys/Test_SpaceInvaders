using UnityEngine;

namespace Configuration
{
	[CreateAssetMenu(fileName = "PrefabsConfig", menuName = "Config/PrefabsConfig")]
	public class PrefabsConfig : ScriptableObject
	{
		public Bullet.Bullet _simpleBulletPrefab;
	}
}