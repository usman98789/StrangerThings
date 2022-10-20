using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showOneSecond : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject spotLight;
    

    private bool showed = false;
    private SkinnedMeshRenderer[] mesh;
    private AudioSource audioSrc;

    private void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        mesh = GetComponentsInChildren<SkinnedMeshRenderer>();
        foreach (SkinnedMeshRenderer r in mesh)
            r.enabled = false;
    }

    private void Update()
    {
        if (!showed && player.transform.position.z >= -28.7 && spotLight.activeInHierarchy)
        {
            StartCoroutine(ShowOneSecond());
        }
    }

    IEnumerator ShowOneSecond()
    {
        showed = true;
        foreach (SkinnedMeshRenderer r in mesh)
            r.enabled = true;
        audioSrc.Play();
        yield return new WaitForSeconds(0.2f);
        foreach (SkinnedMeshRenderer r in mesh)
            r.enabled = false;
    }
}
