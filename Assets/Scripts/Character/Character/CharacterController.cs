using System.Collections;
using Data;
using UnityEngine;


namespace Player {
    public class CharacterController : MonoBehaviour {
        Character _character;

        void Start() {
            // _cooldownTime = cooldown;
            _character = gameObject.GetComponent<CharacterLoader>().Character;
            StartCoroutine(FixedCourutine());
            StartCoroutine(PerFrameCourutine());
        }
        
        IEnumerator PerFrameCourutine()
        {
            while(true)
            {
                _character.HandleMovement();
                _character.Interact();
                yield return null;
            }
        }
        
        IEnumerator FixedCourutine()
        {
            while(true)
            {
                _character.UpdateUI();
                _character.GetInteractionInfo();
                yield return new WaitForFixedUpdate();
            }
        }
    }
}