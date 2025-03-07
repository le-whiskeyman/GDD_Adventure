using System;

namespace Game {
	[Serializable]
	public class Item
	{
		private ItemData data;

		public void Init(ItemData newItemData)
		{
			data = newItemData;
		}
	}
}