using UnityEngine;
using System;
using System.Collections.Generic;

namespace Game
{
	[Serializable]
	public class Inventory
	{
		public List<Item> Items => items;

		[SerializeField] private List<Item> items = new List<Item>();
	}
}