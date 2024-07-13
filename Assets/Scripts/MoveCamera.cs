using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {
    [SerializeField] private Transform cameraPosition; 
    [SerializeField] private Transform head; 
    void Update() {
        transform.position = cameraPosition.position;
        head.localRotation = cameraPosition.rotation;
    }
}
