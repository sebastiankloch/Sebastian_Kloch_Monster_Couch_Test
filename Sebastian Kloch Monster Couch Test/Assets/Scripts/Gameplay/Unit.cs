using UnityEngine;

namespace SK.MonsterCouch.Gameplay
{
	public class Unit : MonoBehaviour
	{
		[SerializeField]
		protected Rigidbody2D ridBy2D;

		private Transform trans;

		private void Awake()
		{
			trans = transform;
		}

		public virtual void Move(Vector2 vector2)
		{
			
		}

		public Vector2 GetPosition2D()
		{
			return trans.position;
		}

		private void Reset()
		{
			ridBy2D = GetComponent<Rigidbody2D>();
		}
	}
}