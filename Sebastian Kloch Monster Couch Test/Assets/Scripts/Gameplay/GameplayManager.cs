using UnityEngine;

namespace SK.MonsterCouch.Gameplay
{
	public class GameplayManager : MonoBehaviour
	{
		public enum State
		{
			NotPlaying,
			Playing,
		}

		[SerializeField]
		private VoidEvent onGameplayStartEvent;
		[SerializeField]
		private VoidEvent onGameplayEndEvent;

		private State state;

		private void Start()
		{
			onGameplayStartEvent.AddListener(StartGame);
			onGameplayEndEvent.AddListener(StopGame);
		}

		public void StartGame()
		{
			state = State.Playing;
		}

		public void StopGame()
		{
			state = State.NotPlaying;
		}

		public State GetState()
		{
			return state;
		}

		private void OnDestroy()
		{
			onGameplayStartEvent.RemoveListener(StartGame);
			onGameplayEndEvent.RemoveListener(StopGame);
		}
	}
}