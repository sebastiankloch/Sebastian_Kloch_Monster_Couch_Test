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

		private State state;

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
	}
}