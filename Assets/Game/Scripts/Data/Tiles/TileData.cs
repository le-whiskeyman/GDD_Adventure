using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "Tile Data", menuName = "Data/Tile Data")]
    public class TileData : ScriptableObject
    {
        public Sprite Sprite;
        public ETileEffect TileEffect;
        public Color ColorTint;
    }
}