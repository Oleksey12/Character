using Player.Abstract;

namespace Item.Abstract {
    public interface Interactive {
        public void Interact(ICharacterData character);
    }
}