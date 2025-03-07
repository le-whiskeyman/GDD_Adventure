using UnityEngine;

namespace Game
{
    public abstract class ItemData : ScriptableObject
    {
        public string Name;
		[TextArea()] public string Description;
        public Sprite Sprite;
        public Color Color;
	}
}