using UnityEngine;

namespace Game
{
    public class Tile : MonoBehaviour
    {
		public TileData TileData => tileData;
		public ETileEffect Effect => tileData.TileEffect;

        [SerializeField] private TileData tileData;
		[SerializeField] private SpriteRenderer spriteRenderer;

		private void Awake()
		{
			spriteRenderer = GetComponent<SpriteRenderer>();
		}

		private void Start()
		{
			UpdateTile();
		}

		public void UpdateTile()
		{
			if (tileData.Sprite)
				spriteRenderer.sprite = tileData.Sprite;
			spriteRenderer.color = tileData.ColorTint;
		}

		public void UpdateTile(TileData newData)
		{
			tileData = newData;
			UpdateTile();
		}
	}
}