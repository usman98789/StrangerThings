using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeySystem
{
    public class KeyItemController : MonoBehaviour
    {
        [SerializeField] private bool door1key = false;
        [SerializeField] private bool door2key = false;

        [SerializeField] private KeyInventory _keyInventory = null;
        private MeshRenderer mesh;
        private KeyDoorController doorObject;
        private AudioSource audioSrc;

        private void Start()
        {
            mesh = GetComponent<MeshRenderer>();
            audioSrc = GetComponent<AudioSource>();
            doorObject = GetComponent<KeyDoorController>();
        }

        private void Disable()
        {
            audioSrc.Play();
            mesh.enabled = false;
            StartCoroutine(Disableon3());
        }

        public void ObjectInteraction()
        {

            if (door1key)
            {
                _keyInventory.hasKey1 = true;
                Disable();
            } else if (door2key)
            {
                _keyInventory.hasKey2 = true;
                Disable();
            }
            else
            {
                doorObject.PlayAnimation();
            }

        }

        IEnumerator Disableon3()
        {
            yield return new WaitForSeconds(3);
            gameObject.SetActive(false);
        }

    }
}

