using UnityEngine;

namespace Data {
    public class DataStorage : MonoBehaviour {
        [SerializeField] public float currentHealth = 1f;
        [SerializeField] public float maxHealth = 1000f;
        [SerializeField] public float speed = 6f;
        [SerializeField] public float size = 1f;
    }
}