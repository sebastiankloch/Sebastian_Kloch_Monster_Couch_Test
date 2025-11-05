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
		[SerializeField]
		private VoidEvent onGameplayStartEvent;
		[SerializeField]
		private VoidEvent onGameplayEndEvent;

		protected override void Start()
		{
			base.Start();
			onGameplayEndEvent.AddListener(Open);
		}

		public void PlayButton()
		{
			Close();
			//gameplayManager.StartGame();
			onGameplayStartEvent.Rise();
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

		private void OnDestroy()
		{
			onGameplayEndEvent.RemoveListener(Open);
		}
	}
}