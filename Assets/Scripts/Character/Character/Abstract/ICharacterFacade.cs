namespace Player.Abstract {
    public interface ICharacterFacade {
        public void HandleMovement();
        public void Interact();
        public void GetInteractionInfo();
        public void UpdateUI();
    }
}