using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace SK.MonsterCouch.UI
{
	public class Window : MonoBehaviour
	{
		[SerializeField]
		private bool openOnStart;
		[SerializeField]
		private GameObject content;
		[SerializeField]
		private Selectable firstToSelect;
		[SerializeField]
		private Window backWindow;

		private bool opened;

		private void Start()
		{
			if (openOnStart)
				Open();
		}

		public virtual void Open()
		{
			if (firstToSelect)
			{
				EventSystem.current.SetSelectedGameObject(firstToSelect.gameObject);
			}

			content.SetActive(true);
			opened = true;
		}

		public virtual void Close()
		{
			content.SetActive(false);
			opened = false;
		}

		private void Update()
		{
			if (opened)
			{
				if (Keyboard.current != null)
				{
					if (Keyboard.current[Key.Escape].wasPressedThisFrame)
					{
						Back();
					}
				}
			}
		}

		public void Back()
		{
			if (backWindow)
			{
				Close();
				backWindow.Open();
			}
		}
	}
}