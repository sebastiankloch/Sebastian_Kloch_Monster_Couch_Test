using UnityEngine;

namespace SK.MonsterCouch.Gameplay
{
	public class Unit : MonoBehaviour
	{
		private Transform trans;

		private void Awake()
		{
			trans = transform;
		}

		public Vector2 GetPosition2D()
		{
			return trans.position;
		}
	}
}