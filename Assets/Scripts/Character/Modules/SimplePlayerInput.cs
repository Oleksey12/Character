using Player.Abstract;
using Modules.Abstract;
using UnityEngine;
using Data;

namespace Modules {
    public class SimplePlayerInput: IPlayerInput {
        protected KeyStorage _keys;
        protected GameObject _playerObject;
        protected DataStorage _data;
        
        public SimplePlayerInput(ICharacterData character, KeyStorage keys) {
            _keys = keys;
            _data = character.GetData();
            _playerObject = character.GetGameObject();
        }
        public Vector2 GetMouseMovement() {
            float x = Input.GetAxisRaw("Mouse Y");
            float y = Input.GetAxisRaw("Mouse X");
            return new Vector2(x, y);
        }
        
        public Vector2 GetPlayerMovement() {
            float x = Input.GetAxis("Vertical");
            float y = Input.GetAxis("Horizontal");
            
            return new Vector2(x, y);
        }

        public bool CheckHotKey() {
            return Input.GetKeyDown(_keys.HotKey);
        }
    }
}