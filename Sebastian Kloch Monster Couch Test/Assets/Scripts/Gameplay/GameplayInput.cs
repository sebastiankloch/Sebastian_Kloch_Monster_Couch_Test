using SK.MonsterCouch.UI;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SK.MonsterCouch.Gameplay
{
	public class GameplayInput : MonoBehaviour
	{
		[SerializeField]
		private GameplayManager gameplayManager;
		[SerializeField]
		private Window mainMenu;
		[SerializeField]
		private Player player;
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
						//gameplayManager.StopGame();
						onGameplayEndEvent.Rise();
						//mainMenu.Open();
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

					if (moveVector.sqrMagnitude > 0)
						player.Move(moveVector);
				}
			}
		}
	}
}