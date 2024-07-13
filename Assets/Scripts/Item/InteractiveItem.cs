using System.Collections.Generic;
using Player.Abstract;
using UnityEngine;

namespace Item.Abstract {
    public class InteractiveItem: MonoBehaviour, Interactive {
        [SerializeField] List<Texture> images;
        [SerializeField] List<Renderer> faces;
        [SerializeField] List<Material> materials;
        [SerializeField] ParticleSystem particles;
        protected AbstractItemFabric _fabric;
        protected Item _item;
        
        protected void Awake() {
            _fabric = new ItemWithParticlesFabric(faces, materials, images, particles,gameObject, new float[] { 0.125f, 0.25f, 0.5f });
            _item = _fabric.ProduceItem();
        }

        public void Interact(ICharacterData character) {
            _item.Interact(character);
        }
    }
}