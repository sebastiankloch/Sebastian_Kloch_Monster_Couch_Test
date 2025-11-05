using UnityEngine;

namespace SK.MonsterCouch.Gameplay
{
	public class Player : Unit
	{
		[SerializeField]
		private float speed;

		public override void Move(Vector2 vector2)
		{
			ridBy2D.linearVelocity = vector2 * speed;
		}
	}
}