using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseLight : MonoBehaviour
{
    [SerializeField] GameObject spotLight1;
    [SerializeField] GameObject spotLight2;
    [SerializeField] GameObject ceil;
    [SerializeField] GameObject help;
    private AudioSource audioSrc;

    private void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (spotLight1.activeInHierarchy && spotLight2.activeInHierarchy)
        {
            spotLight1.SetActive(false);
            spotLight2.SetActive(false);
            ceil.GetComponent<MeshRenderer>().enabled = false;
            help.SetActive(true);
            audioSrc.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (help.activeInHierarchy)
        {
            help.SetActive(false);
        }
    }
}
