using UnityEngine;

namespace Weapon.Base
{
	public class Muzzle : MonoBehaviour
	{
		public Vector3 Position => transform.position;
		public Vector3 Up => transform.up;
	}
}