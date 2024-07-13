using Player.Abstract;

namespace Item.Abstract {
    public abstract class Item {
        protected IEffect _effect;
        protected float _size;
        
        public virtual void Interact(ICharacterData character) {
            _effect.Effect(character, _size);
        }
    }
}