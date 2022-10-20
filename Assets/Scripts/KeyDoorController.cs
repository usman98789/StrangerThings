using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeySystem
{
    public class KeyDoorController : MonoBehaviour
    {
        private Animator doorAnim;

        [SerializeField] AudioClip door1;
        [SerializeField] AudioClip door2;
        private AudioSource audioSrc;

        [SerializeField] private GameObject showDoorLockedUI = null;
        [SerializeField] private KeyInventory _keyInventory = null;

        public bool doorOpened = false;
        private void Awake()
        {
            doorAnim = gameObject.GetComponent<Animator>();
        }

        private void Start()
        {
            audioSrc = GetComponent<AudioSource>();
        }

        public bool getDoorStatus()
        {
            return doorOpened;
        }

        public void PlayAnimation()
        {
            if (gameObject.name.Contains("door1"))
            {
                if (_keyInventory.hasKey1)
                {
                    OpenDoor();
                } else
                {
                    StartCoroutine(showDoorLocked());
                }

            } else if (gameObject.name.Contains("door2"))
            {
                if (_keyInventory.hasKey2)
                {
                    OpenDoor();
                } else
                {
                    StartCoroutine(showDoorLocked());
                }
            } else
            {
                OpenDoor();
            }
        }

        IEnumerator showDoorLocked()
        {
            showDoorLockedUI.SetActive(true);
            yield return new WaitForSeconds(1);
            showDoorLockedUI.SetActive(false);
        }

        void OpenDoor()
        {
            if (!doorOpened)
            {
                doorOpened = true;
                doorAnim.Play("doorOpen", 0, 0.0f);
                int x = Random.Range(0, 10);
                if (x <= 5)
                    audioSrc.PlayOneShot(door1);
                else
                    audioSrc.PlayOneShot(door2);

            }
        }
    }
}

