using System.CodeDom;
using System.Linq;
using Game.Core.Item;
using Settings;
using UnityEngine;

namespace Game.Core.Level
{
	public abstract class LevelData
	{		
		public abstract ItemType GetNextFillItemType();
		public abstract void Initialize();
		public ItemType[,] GridData { get; protected set; }

		private ItemType[] lastCubeArray;
		
		private    ItemType[] DefaultCubeArray = new[]
		{
			ItemType.GreenCube,
			ItemType.YellowCube,
			ItemType.BlueCube,
			ItemType.RedCube,
			ItemType.PinkCube,
			ItemType.PurpleCube,
		};

		protected  ItemType GetRandomCubeItemType()
		{
			if (GameSettings.cubeChoice<1 || GameSettings.cubeChoice>6)
				return GetRandomItemTypeFromArray(DefaultCubeArray);
			
			lastCubeArray = DefaultCubeArray.ToList().GetRange(0, GameSettings.cubeChoice).ToArray();
			return GetRandomItemTypeFromArray(lastCubeArray);
		}

		protected  ItemType GetRandomItemTypeFromArray(ItemType[] itemTypeArray)
		{
			return itemTypeArray[Random.Range(0, itemTypeArray.Length)];
			
		}
	}
}
