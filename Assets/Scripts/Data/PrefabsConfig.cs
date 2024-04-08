using Bullet;
using UnityEngine;

namespace Data
{
	[CreateAssetMenu(fileName = "PrefabsConfig", menuName = "Data/PrefabsConfig", order = 1)]
	public class PrefabsConfig : ScriptableObject
	{
		public HeroBullet HeroBulletPrefab;
	}
}