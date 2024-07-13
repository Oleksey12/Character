using System;
using System.Collections.Generic;
using Data;
using Player;
using TMPro;
using UI.Abstract;
using UnityEngine;

namespace UI {
    public class TextGameUI: IGameUI {
        protected Rigidbody _rb;
        protected DataStorage _data;
        protected List<TMP_Text> _text;
        
        public TextGameUI(Character character, List<TMP_Text> text) {
            _rb = character.GetGameObject().GetComponent<Rigidbody>();
            _data = character.GetData();
            _text = text;
        }
        
        public void UpdateUI() {
            _text[0].text = $"HP: {_data.currentHealth}/{_data.maxHealth}";
            _text[1].text = $"Speed: {Math.Round(_rb.velocity.magnitude, 2)}/{_data.speed}";
        }
    }
}