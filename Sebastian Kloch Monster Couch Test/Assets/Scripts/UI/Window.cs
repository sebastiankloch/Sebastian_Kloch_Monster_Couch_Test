using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace SK.MonsterCouch.UI
{
	public class Window : MonoBehaviour
	{
		[SerializeField]
		private bool openOnStart;
		[SerializeField]
		private Selectable firstToSelect;

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
				Debug.Log("I'm here");
			}

			gameObject.SetActive(true);
		}

		public void Back()
		{

		}
	}
}