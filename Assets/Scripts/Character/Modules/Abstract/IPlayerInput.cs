using System.Collections.Generic;
using UnityEngine;

namespace Modules.Abstract {
    public interface IPlayerInput {
        public Vector2 GetMouseMovement();
        public Vector2 GetPlayerMovement();
        public bool CheckHotKey();
    }
}