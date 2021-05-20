using Game.Items;
using Settings;
using UnityEngine;

namespace Game.Core.Item
{
    public static class ItemFactory
    {
        private static GameObject _itemBasePrefab;
        private static ImageLibrary _imageLibrary;
        private static ParticleLibrary _particleLibrary;

        public static void Prepare(ImageLibrary imageLibrary, ParticleLibrary particleLibrary)
        {
            _imageLibrary = imageLibrary;
            _particleLibrary = particleLibrary;
        }
        
        public static Item CreateItem(ItemType itemType, Transform parent)
        {
            if (_itemBasePrefab == null)
            {
                _itemBasePrefab = Resources.Load("ItemBase") as GameObject;
            }
            
            var itemBase = GameObject.Instantiate(
                _itemBasePrefab, Vector3.zero, Quaternion.identity, parent).GetComponent<ItemBase>();
            
            Item item = null;
            switch (itemType)
            {
                case ItemType.GreenCube:
                    item = CreateCubeItem(itemType, itemBase, _imageLibrary.GreenCubeDefault, _particleLibrary.CubeGreenParticle);
                    break;
                case ItemType.YellowCube:
                    item = CreateCubeItem(itemType, itemBase, _imageLibrary.YellowCubeDefault, _particleLibrary.CubeYellowParticle);
                    break;
                case ItemType.BlueCube:
                    item = CreateCubeItem(itemType, itemBase, _imageLibrary.BlueCubeDefault, _particleLibrary.CubeBlueParticle);
                    break;
                case ItemType.RedCube:
                    item = CreateCubeItem(itemType, itemBase, _imageLibrary.RedCubeDefault, _particleLibrary.CubeRedParticle);
                    break;  
                case ItemType.PinkCube:
                    item = CreateCubeItem(itemType, itemBase, _imageLibrary.PinkCubeDefault, _particleLibrary.CubePinkParticle);
                    break;  
                case ItemType.PurpleCube:
                    item = CreateCubeItem(itemType, itemBase, _imageLibrary.PurpleCubeDefault, _particleLibrary.CubePurpleParticle);
                    break;

                default:
                    Debug.LogWarning("Can not create item: "+itemType);
                    break;
            }
            
            return item;
        }

        private static Item CreateCubeItem(ItemType itemType, ItemBase itemBase, Sprite sprite, ParticleSystem particleSystem)
        {
            var cubeItem = itemBase.gameObject.AddComponent<CubeItem>();
            //cubeItem.Prepare(itemBase, sprite);

			if(sprite == _imageLibrary.YellowCubeDefault)
				cubeItem.PrepareHintItem (itemBase, sprite, _imageLibrary.YellowCubeA, _imageLibrary.YellowCubeB , _imageLibrary.YellowCubeC);	
			
			if(sprite == _imageLibrary.BlueCubeDefault)
				cubeItem.PrepareHintItem (itemBase, sprite, _imageLibrary.BlueCubeA, _imageLibrary.BlueCubeB , _imageLibrary.BlueCubeC);	
			
			if (sprite == _imageLibrary.GreenCubeDefault)
				cubeItem.PrepareHintItem (itemBase, sprite, _imageLibrary.GreenCubeA, _imageLibrary.GreenCubeB, _imageLibrary.GreenCubeC);			

			if(sprite == _imageLibrary.RedCubeDefault)
				cubeItem.PrepareHintItem (itemBase, sprite, _imageLibrary.RedCubeA, _imageLibrary.RedCubeB, _imageLibrary.RedCubeC);	
            
            if(sprite == _imageLibrary.PinkCubeDefault)
                cubeItem.PrepareHintItem (itemBase, sprite, _imageLibrary.PinkCubeA, _imageLibrary.PinkCubeB, _imageLibrary.PinkCubeC);	

            if(sprite == _imageLibrary.PurpleCubeDefault)
                cubeItem.PrepareHintItem (itemBase, sprite, _imageLibrary.PurpleCubeA, _imageLibrary.PurpleCubeB, _imageLibrary.PurpleCubeC);	


            cubeItem.SetCubeType(itemType);
            cubeItem.SetParticle(particleSystem);
            
            return cubeItem;
        }
    }
}


