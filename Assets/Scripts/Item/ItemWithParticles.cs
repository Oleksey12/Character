using Player.Abstract;
using Item.Abstract;
using UnityEngine;

namespace Item {
    public class ItemWithParticles: Abstract.Item {
        protected ParticleSystem _emission;
        protected Rigidbody _rb;
        protected Transform _transform;
        protected float _defaultMass;
        
        public ItemWithParticles(GameObject gameObject, ParticleSystem emission, IEffect effect, float defaultMass, float size) {
            _transform = gameObject.transform;
            _effect = effect;
            _emission = emission;
            _rb = gameObject.GetComponent<Rigidbody>();
            _defaultMass = defaultMass;
            _size = size;
            ApplySize(size);
        }

        public override void Interact(ICharacterData character) {
            base.Interact(character);
            Emit();
        }

        protected void Emit() {
            int particlesCount = 160;
            _emission.Emit((int)(particlesCount * _size));
            _emission.Play();
        }
        
        protected void ApplySize(float size) {
            _size = size;
            _transform.localScale = new Vector3(_size, _size, _size);
            _transform.position = new Vector3(_transform.position.x, _size / 2, _transform.position.z);
            _rb.mass = _defaultMass * size;
            var main = _emission.shape;
            main.scale = new Vector3(_size, _size, _size);
            
        }
    }
}