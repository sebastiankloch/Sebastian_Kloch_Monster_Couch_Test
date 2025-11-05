using UnityEngine;

namespace SK.MonsterCouch.Gameplay
{
	public class Enemy : Unit
	{
		[SerializeField]
		private Rigidbody2D ridBy2D;
		[SerializeField]
		private SpriteRenderer spriteRenderer;
		
		[SerializeField]
		private EnemyData data;

		public void Move(Vector2 vector2)
		{
			ridBy2D.AddForce(vector2 * data.speed * Time.deltaTime);
		}

		private void Reset()
		{
			ridBy2D = GetComponent<Rigidbody2D>();
		}

		private void OnCollisionEnter2D(Collision2D collision)
		{
			if (collision.gameObject.CompareTag("Player"))
			{
				ridBy2D.simulated = false;
				spriteRenderer.color = data.disabledColor;
				enabled = false;
			}
		}
	}
}