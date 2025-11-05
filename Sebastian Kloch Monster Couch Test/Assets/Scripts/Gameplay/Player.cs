using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField]
	private Rigidbody2D ridBy2D;
	[SerializeField]
	private float speed;

	public void Move(Vector2 vector2)
	{
		ridBy2D.linearVelocity = vector2 * speed;
	}

	private void Reset()
	{
		ridBy2D = GetComponent<Rigidbody2D>();
	}
}
