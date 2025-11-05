using SK.MonsterCouch.UI;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SK.MonsterCouch.Gameplay
{
	public class GameplayInput : MonoBehaviour
	{
		private const float MINIMAL_DISTANCE_TO_MOUSE = 0.1f;
		[SerializeField]
		private GameplayManager gameplayManager;
		[SerializeField]
		private Window mainMenu;
		[SerializeField]
		private Player player;
		[SerializeField]
		private Camera cam;
		[SerializeField]
		private VoidEvent onGameplayEndEvent;

		private void Update()
		{
			if (gameplayManager.GetState() == GameplayManager.State.Playing)
			{
				if (Keyboard.current != null)
				{
					if (Keyboard.current[Key.Escape].wasPressedThisFrame)
					{
						onGameplayEndEvent.Rise();
					}

					Vector2 moveVector = Vector2.zero;

					if (Keyboard.current[Key.UpArrow].isPressed)
					{
						moveVector += Vector2.up;
					}

					if (Keyboard.current[Key.RightArrow].isPressed)
					{
						moveVector += Vector2.right;
					}

					if (Keyboard.current[Key.DownArrow].isPressed)
					{
						moveVector += Vector2.down;
					}

					if (Keyboard.current[Key.LeftArrow].isPressed)
					{
						moveVector += Vector2.left;
					}

					player.Move(moveVector.normalized);
				}

				if (Mouse.current != null)
				{
					if (Mouse.current.leftButton.isPressed)
					{
						Vector2 mouseVector = ((Vector2)cam.ScreenToWorldPoint(Mouse.current.position.value) - player.GetPosition2D());
						if (mouseVector.magnitude > MINIMAL_DISTANCE_TO_MOUSE)
							player.Move(mouseVector.normalized);
					}
				}
			}
		}
	}
}