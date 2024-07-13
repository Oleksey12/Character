using Data;
using UnityEngine;

namespace Player.Abstract {
    public interface ICharacterData {
        public DataStorage GetData();
        public GameObject GetGameObject();
    }
}