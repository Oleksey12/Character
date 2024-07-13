using System.Collections.Generic;
using System.Linq;
using Data;
using Item.Abstract;
using Modules.Abstract;
using Player.Abstract;
using Unity.VisualScripting;
using UnityEngine;

namespace Modules {
    public class RayCastCharacterInteraction: ICharacterInteraction {
        protected ICharacterData _data;
        protected Transform _cameraTransform;
        protected LayerMask _mask = 0;
        protected float _distance;
        
        public RayCastCharacterInteraction(ICharacterData data, 
                                 Transform cameraTransform, 
                                 float interactionDistance, 
                                 string[] effectedLayers) {
            _data = data;
            _cameraTransform = cameraTransform;
            _distance = interactionDistance;
            _mask |= LayerMask.GetMask(effectedLayers);
        }


        public bool CheckInteraction() {
            return Physics.Raycast(_cameraTransform.position, 
                            _cameraTransform.TransformDirection(Vector3.forward), 
                            _distance,
                            _mask);
        }

        public bool Interact() {
            RaycastHit res;
            //Debug.DrawRay(_cameraTransform.position,
            //              _cameraTransform.TransformDirection(Vector3.forward) * _distance,
            //              Color.Red);
            if (Physics.Raycast(_cameraTransform.position,
                                _cameraTransform.TransformDirection(Vector3.forward),
                                out res,
                                _distance,
                                _mask)) {
                Interactive itemComponent = res.transform.gameObject.GetComponent<Interactive>();
                if (itemComponent != null) {
                    itemComponent.Interact(_data);
                    return true;
                }
            }
            return false;
        }
    }
}