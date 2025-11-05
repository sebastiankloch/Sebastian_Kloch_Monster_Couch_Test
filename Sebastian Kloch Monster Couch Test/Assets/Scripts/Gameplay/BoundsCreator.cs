using SK.MonsterCouch;
using System.Collections.Generic;
using UnityEngine;

namespace SK.MonsterCouch.Gameplay
{
	public class BoundsCreator : MonoBehaviour
	{
		[SerializeField]
		private float boundWidth;
		[SerializeField]
		private Camera cam;
		[SerializeField]
		private VoidEvent onGameplayStartEvent;
		[SerializeField]
		private VoidEvent onGameplayEndEvent;
		[SerializeField]

		private List<GameObject> gaObjBounds = new List<GameObject>();
		private Rect rect;

		private void Start()
		{
			onGameplayStartEvent.AddListener(CreateBounds);
			onGameplayEndEvent.AddListener(DestroyBounds);
		}

		private void CreateBounds()
		{
			Vector2 bottomLeft = cam.ScreenToWorldPoint(Vector3.zero);
			Vector2 topRight = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
			rect = new Rect(bottomLeft, topRight - bottomLeft);

			CreateBound(
				"Bound Left",
				new Vector2(rect.xMin - boundWidth / 2f, rect.center.y),
				new Vector2(boundWidth, rect.height + boundWidth * 2f));
			CreateBound(
				"Bound Right",
				new Vector2(rect.xMax + boundWidth / 2f, rect.center.y),
				new Vector2(boundWidth, rect.height + boundWidth * 2f));
			CreateBound(
				"Bound Top",
				new Vector2(rect.center.x, rect.yMax + boundWidth / 2f),
				new Vector2(rect.width + boundWidth * 2f, boundWidth));
			CreateBound(
				"Bound Down",
				new Vector2(rect.center.x, rect.yMin - boundWidth / 2f),
				new Vector2(rect.width + boundWidth * 2f, boundWidth));
		}

		private void CreateBound(string name, Vector2 pos, Vector2 size)
		{
			GameObject bound = new GameObject(name);
			bound.transform.SetParent(transform);
			bound.transform.position = pos;
			BoxCollider2D boxCollider2D = bound.AddComponent<BoxCollider2D>();
			boxCollider2D.size = size;
			gaObjBounds.Add(bound);
		}

		private void DestroyBounds()
		{
			for (int id = 0; id < gaObjBounds.Count; id++)
			{
				Destroy(gaObjBounds[id]);
			}

			gaObjBounds.Clear();
		}

		private void OnDestroy()
		{
			onGameplayStartEvent.RemoveListener(CreateBounds);
			onGameplayEndEvent.RemoveListener(DestroyBounds);
		}

		public Rect GetRect()
		{
			return rect;
		}
	}
}