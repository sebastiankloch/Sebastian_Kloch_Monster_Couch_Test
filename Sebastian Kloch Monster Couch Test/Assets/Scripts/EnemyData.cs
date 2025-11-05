using UnityEngine;

namespace SK.MonsterCouch.Gameplay
{
	[CreateAssetMenu(fileName = "EnemyData", menuName = "Scriptable Objects/EnemyData")]
	public class EnemyData : ScriptableObject
	{
		public float speed;
		public Color disabledColor;
	}
}