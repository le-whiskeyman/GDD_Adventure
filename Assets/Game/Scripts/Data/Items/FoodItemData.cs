using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "Food Item", menuName = "Data/Food Item")]
    public class FoodItemData : ItemData
    {
        [Tooltip("How much health this should restore.")] public float Healing;
		[Tooltip("How long this takes to eat.")] public float Time;
    }
}