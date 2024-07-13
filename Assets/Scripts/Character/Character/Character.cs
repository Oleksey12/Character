using System.Collections.Generic;
using IGameUI = UI.Abstract.IGameUI;
using Object = System.Object;
using Unity.VisualScripting;
using Modules.Abstract;
using Player.Abstract;
using UnityEngine;
using System.Linq;
using UI.Abstract;
using System;
using Data;

namespace Player {
    public class Character: ICharacterData, ICharacterInitializer, ICharacterFacade {
        protected Dictionary<string, Object> _usedModules;
        protected List<Object> _modules;
        protected GameObject _player;
        protected DataStorage _data;

        public Character(GameObject playerObject, DataStorage data) {
            _usedModules = new Dictionary<string, Object>();
            _modules = new List<Object>();
            _player = playerObject;
            _data = data;
        }
        
        public DataStorage GetData() {
           return _data;
        }
        public GameObject GetGameObject() {
            return _player;
        }
        
        private bool CheckModules(List<Type> modules) {
            if (!modules.All(x => _usedModules.ContainsKey(StringType(x)))) {
                InitializeModules(modules);
            }
            foreach (var moduleType in modules) {
                if (!_usedModules.ContainsKey(StringType(moduleType))) {
                    return false;
                }
            }
            return true;
        }
        private void InitializeModules(List<Type> modules) {
            foreach (Type moduleType in modules) {
                if (_usedModules.ContainsKey(StringType(moduleType))) continue;
                var suitableModules = _modules.Where(
                    x => ConversionUtility.CanConvert(x, moduleType, false));
                _usedModules[StringType(moduleType)] = suitableModules.Count() != 0 ?
                                                       suitableModules.ElementAt(0).ConvertTo(moduleType)
                                                       : null;
            }
        }
        
        public void LinkModules(Object modules) {
            if (modules is not List<Object>) {
                _modules.Add(modules);
            } else {
                _modules = new List<Object>(_modules.Concat((List<Object>)modules));
            }
        }
    

        public void HandleMovement() {
            List<Type> requiredInterfaces = new List<Type> { typeof(IPlayerInput), typeof(IMovementController)};
            
            if (!CheckModules(requiredInterfaces)) {
                // Put actions here
                Debug.Log("modules not found");
                return;
            }
            
            var inputModule = (IPlayerInput)_usedModules["IPlayerInput"];
            var movementModule = (IMovementController)_usedModules["IMovementController"];
            
            Vector2 mouseChange = inputModule.GetMouseMovement();
            Vector2 pressPower = inputModule.GetPlayerMovement();
            movementModule.Rotate(mouseChange.x, mouseChange.y);
            movementModule.Move(pressPower.x, pressPower.y);
        }
        

        public void Interact() {
            List<Type> requiredInterfaces = new List<Type> {typeof(IPlayerInput), typeof(ICharacterInteraction)};
            if (!CheckModules(requiredInterfaces)) {
                // Put actions here
                Debug.Log("modules not found");
                return;
            }
            
            var interactionModule = (ICharacterInteraction)_usedModules["ICharacterInteraction"];
            var inputModule = (IPlayerInput)_usedModules["IPlayerInput"];
            if (inputModule.CheckHotKey()) {
                interactionModule.Interact();
            }
        }

        public void GetInteractionInfo() {
            List<Type> requiredInterfaces = new List<Type> { typeof(ICharacterInteraction), typeof(IHotKeyDisplay)};
            
            if (!CheckModules(requiredInterfaces)) {
                // Put actions here
                Debug.Log("modules not found");
                return;
            }
            var interactionModule = (ICharacterInteraction)_usedModules["ICharacterInteraction"];
            var hotKeyDisplayModule = (IHotKeyDisplay)_usedModules["IHotKeyDisplay"];
            
            bool result = interactionModule.CheckInteraction();
            if(result) hotKeyDisplayModule.ShowHotKey();
        }
        
        public void UpdateUI() {
            List<Type> requiredInterfaces = new List<Type> { typeof(IGameUI), typeof(IHotKeyDisplay)};
            
            if (!CheckModules(requiredInterfaces)) {
                // Put actions here
                Debug.Log("modules not found");
                return;
            }
            var playerUIModule = (IGameUI)_usedModules["IGameUI"];
            var hotKeyDisplayModule = (IHotKeyDisplay)_usedModules["IHotKeyDisplay"];

            playerUIModule.UpdateUI();
            hotKeyDisplayModule.UpdateDisplay();
        }


        protected string StringType(Type val) {
            var fullName = val.ToString();
            return fullName.Split('.').Last();
        }
    }
}