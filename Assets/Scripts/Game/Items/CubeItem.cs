using Game.Core.Item;
using UnityEngine;

namespace Game.Items
{
    public class CubeItem : Item
    {
        private SpriteRenderer spriteRenderer;
		private Sprite nonHint;
		private Sprite _hintA;
		private Sprite _hintB;
		private Sprite _hintC;

	
        
        private ItemType _itemType;
        private ParticleSystem _particleSystem;


        public override ItemType GetItemType()
        {
            return _itemType;
        }

        public override void setItemType(ItemType itemType)
        {
            _itemType = itemType;
        }

        public override bool IsMatchable()
        {
            return true;
        }

        public void SetCubeType(ItemType colorId)
        {
            _itemType = colorId;
        }

        
		public void PrepareHintItem(ItemBase itemBase, Sprite nonHint, Sprite hintA,  Sprite hintB,  Sprite hintC)
        {
            
            spriteRenderer = itemBase.SpriteRenderer;
            spriteRenderer.sprite = nonHint;
			this.nonHint = nonHint;
			_hintA = hintA;
			_hintB = hintB;
			_hintC = hintC;
            FallAnimation = itemBase.FallAnimation;
            FallAnimation.Item = this;		
        }

		public void openHintA()
		{
			spriteRenderer.sprite = _hintA;
		}
		
		public void openHintB()
		{
			spriteRenderer.sprite = _hintB;
		}
		
		public void openHintC()
		{
			spriteRenderer.sprite = _hintC;
		}

		public void ChangetoNonHint(){
			
			spriteRenderer.sprite = nonHint;
		}

        public override bool TryExecute()
        {
	        if (_particleSystem == null)
				return base.TryExecute ();
        
			var particle = Instantiate (_particleSystem, transform.position, Quaternion.identity, Cell.Board.ParticlesParent);
			particle.Play ();
        
			return base.TryExecute ();

        }



        public void SetParticle(ParticleSystem particles)
        {
            _particleSystem = particles;
        }
        

    }
}
