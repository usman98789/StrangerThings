using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyDoorController : MonoBehaviour
{
    private Animator doorAnim;

    [SerializeField] AudioClip door1;
    [SerializeField] AudioClip door2;
    [SerializeField] bool locked;
    private AudioSource audioSrc;

    [SerializeField] GameObject lockedText;

    [SerializeField] GameObject key1;
    [SerializeField] GameObject key2;

    private bool doorOpened = false;
    private void Awake()
    {
        doorAnim = gameObject.GetComponent<Animator>();
    }

    private void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    public void PlayAnimation()
    {
        if ((gameObject.name.Contains("door1") && !key1.activeInHierarchy) || (gameObject.name.Contains("door2") && !key2.activeInHierarchy))
        {
            locked = false;
        }

        if (!doorOpened && !locked)
        {
            doorAnim.Play("doorOpen", 0, 0.0f);
            int x = Random.Range(0, 10);
            if (x <= 5)
                audioSrc.PlayOneShot(door1);
            else
                audioSrc.PlayOneShot(door2);

            doorOpened = true;
        } else if (locked)
        {
            // show locked text and play locked sound
        }
    }

}
