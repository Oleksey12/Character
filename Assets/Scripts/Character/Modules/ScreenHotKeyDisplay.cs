using Data;
using Player;
using TMPro;
using UI.Abstract;
using UnityEngine;

namespace UI {
    public class ScreenHotKeyDisplay: IHotKeyDisplay {
        protected Character _character;
        protected TMP_Text _text;
        protected KeyStorage _keys;
        protected float _alpha;
        protected float _animationSpeed;
        
        public ScreenHotKeyDisplay(Character character, TMP_Text text, KeyStorage keys, float animationDuration=0.15f) {
            _character = character;
            _keys = keys;
            _text = text;
            _animationSpeed = 255f / animationDuration;
        }

        public void UpdateDisplay() {
            _alpha = Mathf.Clamp(_alpha - _animationSpeed * Time.deltaTime, 0f, 255f);
            _text.alpha = _alpha;
        }

        public void ShowHotKey() {
            _alpha = 255f;
            _text.alpha = _alpha;
            _text.text = _keys.HotKey.ToString();
        }
    }
}