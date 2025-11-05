using SK.MonsterCouch.Gameplay;
using UnityEngine;

namespace SK.MonsterCouch.UI
{
	public class MainMenu : Window
	{
		[SerializeField]
		private Window settings;
		[SerializeField] 
		private GameplayManager gameplayManager;

		public void PlayButton()
		{
			Close();
			gameplayManager.StartGame();
		}

		public void OpenSettingsWindow()
		{
			Close();
			settings.Open();
		}

		public void ExitButton()
		{
#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
#else
			Application.Quit();
#endif
		}
	}
}