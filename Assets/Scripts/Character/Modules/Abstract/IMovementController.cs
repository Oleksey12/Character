using UnityEngine;

namespace Modules.Abstract {
    public interface IMovementController {
        public void Move(float speedX, float speedY);
        public void Rotate(float angleX, float angleY);
    }
}