using UnityEngine;

using Modules.Abstract;
using Player.Abstract;
using Data;

namespace Modules {
    public class SimpleMovementController: IMovementController{
        protected GameObject _playerObject;
        protected DataStorage _data;
        
        protected Transform _transform;
        protected Transform _cameraPos;
        protected Rigidbody _rb;
        
        protected float _sensX = 400;
        protected float _sensY = 400;

        protected float xRotation;
        protected float yRotation;
        
        public SimpleMovementController(ICharacterData character, Transform cameraPos) {
            _data = character.GetData();
            _playerObject = character.GetGameObject();
            _rb = _playerObject.GetComponent<Rigidbody>();
            
            _transform = _playerObject.transform;
            
            _cameraPos = cameraPos;
            //_rb.drag = _data.speed * 0.2f;

            xRotation = _transform.rotation.x;
            yRotation = _transform.rotation.y;
            
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        
        public void Rotate(float angleX, float angleY) {
            xRotation -= angleX * Time.deltaTime * _sensX;
            yRotation += angleY * Time.deltaTime * _sensY;
            xRotation = Mathf.Clamp(xRotation, -90, 75);
            
            _transform.rotation = Quaternion.Euler(0, yRotation, 0);
            _cameraPos.localRotation = Quaternion.Euler(xRotation, 0, 0);
        }
        

        public void Move(float speedX, float speedY) {
            Vector3 moveVector = _transform.forward * speedX + _transform.right * speedY;
            _rb.velocity =  moveVector * _data.speed;
            if (_rb.velocity.magnitude > _data.speed) {
                _rb.velocity = new Vector3(_rb.velocity.x, 0, _rb.velocity.z ).normalized * _data.speed;
            }
        }


    }
}