using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Item.Abstract {
    public class ItemWithParticlesFabric: AbstractItemFabric  {
        protected List<Renderer> _faces;
        protected List<Material> _materials;
        protected List<Texture> _images;
        protected ParticleSystem _emission;
        protected GameObject _gameObject;
        protected float[] _sizes;
        
        public ItemWithParticlesFabric(List<Renderer> faces,
            List<Material> materials,
            List<Texture> images,
            ParticleSystem emission,
            GameObject gameObject,
            float[] sizes) {
            _faces = faces;
            _materials = materials;
            _images = images;
            _emission = emission;
            _gameObject = gameObject;
            _sizes = sizes;
        }
        
        public Item ProduceItem() {
            IEffect effect = new DamageEffect();
            int type = Random.Range(0, _images.Count);
            switch (type) {
                case 0:
                    effect = new DamageEffect();
                    break;
                case 1:
                    effect = new HealEffect();
                    break;
                case 2:
                    effect = new SpeedUpEffect();
                    break;
            }
            _faces.ForEach(x => x.material.SetTexture("_BaseMap", _images[type]));
            _emission.GetComponent<Renderer>().material = _materials[type];
            int sizeNumber = Random.Range(0, _sizes.Length);
            return new ItemWithParticles(_gameObject, _emission, effect, 10f, _sizes[sizeNumber]);
        }
    }
}