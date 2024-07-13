using System.Collections.Generic;
using Data;
using Modules;
using Modules.Abstract;
using TMPro;
using UI;
using UI.Abstract;
using UnityEngine;
using UnityEngine.Serialization;
using IGameUI = UI.Abstract.IGameUI;
using Object = System.Object;

namespace Player {
    public class CharacterLoader : MonoBehaviour {
        public Character Character { get; private set; }
        
        [SerializeField] DataStorage data;
        [SerializeField] Transform cameraPos;
        [SerializeField] TMP_Text textDisplay;
        [SerializeField] List<TMP_Text> indicators;
        [SerializeField] float distance;
        [SerializeField] string[] layers = new string[]{"Interactive"};

        KeyStorage _keys;

    void Awake() {
            _keys = new KeyStorage();
            Character = new Character(gameObject, data);
            var modules = InitializePlayerModules();
            Character.LinkModules(modules);
        }

        public List<Object> InitializePlayerModules() {
            List<Object> modules = new List<Object>();
            IPlayerInput playerInput = new SimplePlayerInput(Character, _keys);
            IMovementController movement = new SimpleMovementController(Character, cameraPos);
            ICharacterInteraction characterInteraction =
                new RayCastCharacterInteraction(Character, cameraPos, distance, layers);
            IHotKeyDisplay display = new ScreenHotKeyDisplay(Character, textDisplay, _keys);
            IGameUI gameUI = new TextGameUI(Character, indicators);

            modules.Add(characterInteraction);
            modules.Add(playerInput);
            modules.Add(movement);
            modules.Add(display);
            modules.Add(gameUI);
            return modules;
        }
    }
}