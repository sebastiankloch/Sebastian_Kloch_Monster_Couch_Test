using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

namespace SK.MonsterCouch.Gameplay
{
	public class EnemyController : MonoBehaviour
	{
		[SerializeField]
		private VoidEvent onGameplayStartEvent;
		[SerializeField]
		private VoidEvent onGameplayEndEvent;
		[SerializeField]
		private GameObject enemyPrefab;
		[SerializeField]
		private int numberOfEnemiesToSpawn;
		[SerializeField]
		private Player player;
		[SerializeField]
		private BoundsCreator boundsCreator;
		[SerializeField]
		private Enemy[] enemies;

		private void Start()
		{
			onGameplayStartEvent.AddListener(OnGameplayStart);
			onGameplayEndEvent.AddListener(OnGameplayEnd);
		}

		private void OnGameplayStart()
		{
			List<Enemy> enemies = new List<Enemy>();

			Rect boundsRect = boundsCreator.GetRect();
			Enemy enemyTemplate = Instantiate(enemyPrefab, GetRandomPos(boundsRect), Quaternion.identity).GetComponent<Enemy>();
			enemies.Add(enemyTemplate);
			for (int i = 0; i < numberOfEnemiesToSpawn; i++)
			{
				Enemy enemy = Instantiate(enemyTemplate, GetRandomPos(boundsRect), Quaternion.identity).GetComponent<Enemy>();
				enemies.Add(enemy);
			}

			this.enemies = enemies.ToArray();
		}

		private static Vector2 GetRandomPos(Rect boundsRect)
		{
			return new Vector2(Random.Range(boundsRect.xMin, boundsRect.xMax), Random.Range(boundsRect.yMin, boundsRect.yMax));
		}

		private void Update()
		{
			for (int id = 0; id < enemies.Length; id++)
			{
				if (enemies[id].enabled)
				{
					Vector2 vec2 = enemies[id].GetPosition2D() - player.GetPosition2D();
					enemies[id].Move(vec2.normalized);
				}
			}
		}

		private void OnGameplayEnd()
		{
			for (int id = 0; id < enemies.Length; id++)
			{
				Destroy(enemies[id].gameObject);
			}

			enemies = new Enemy[0];
		}

		private void OnDestroy()
		{
			onGameplayStartEvent.RemoveListener(OnGameplayStart);
			onGameplayEndEvent.RemoveListener(OnGameplayEnd);
		}
	}
}