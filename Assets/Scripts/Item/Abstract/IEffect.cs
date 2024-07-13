using UnityEngine;
using System.Collections.Generic;
using Player.Abstract;

namespace Item.Abstract {
    public interface IEffect {
        public void Effect(ICharacterData character, float amplifier = 1f);
    }
}