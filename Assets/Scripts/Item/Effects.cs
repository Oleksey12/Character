using Item.Abstract;
using System.Collections.Generic;
using Player.Abstract;
using UnityEngine;

namespace Item {
    public class HealEffect : IEffect {
        readonly float healedHealth = 100f;
        public void Effect(ICharacterData character, float amplifier = 1f) {
            var data = character.GetData();
            data.currentHealth = Mathf.Clamp(data.currentHealth + healedHealth * amplifier, 0, data.maxHealth);
        }
    }
    
    
    public class DamageEffect : IEffect {
        readonly float damage = 50f;
        public void Effect(ICharacterData character, float amplifier = 1f) {
            var data = character.GetData();
            data.currentHealth = Mathf.Clamp(data.currentHealth - damage * amplifier, 0, data.maxHealth);
        }
    }
    
    public class SpeedUpEffect : IEffect {
        readonly float speedUp = 1f;
        public void Effect(ICharacterData character, float amplifier = 1f) {
            var data = character.GetData();
            data.speed = data.speed + speedUp * amplifier;
        }
    }
    
    
    
}

