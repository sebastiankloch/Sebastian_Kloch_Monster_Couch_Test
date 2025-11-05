using UnityEngine;

namespace SK.MonsterCouch.UI
{
	public class MainMenu : Window
	{
		[SerializeField]
		private Window settings;

		public void OpenSettingsWindow()
		{
			Close();
			settings.Open();
		}

		public void Exit()
		{
#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
#else
			Application.Quit();
#endif
		}
	}
}