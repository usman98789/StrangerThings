using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scream : MonoBehaviour
{
    private Animator anim;
    [SerializeField] GameObject door;

    private AudioSource audiosrc;
    [SerializeField] AudioClip clip;
    [SerializeField] GameObject flicker;
    private void Start()
    {
        anim = GetComponent<Animator>();
        audiosrc = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (door.GetComponent<KeySystem.KeyDoorController>().getDoorStatus())
        {
            anim.SetBool("scream", true);
            StartCoroutine(ScreamUntil());
            StartCoroutine(FlickerLight());
        }
    }

    IEnumerator ScreamUntil()
    {
        audiosrc.PlayOneShot(clip);
        yield return new WaitForSeconds(3.3f);
        gameObject.SetActive(false);
    }

    IEnumerator FlickerLight()
    {
        flicker.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        flicker.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        flicker.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        flicker.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        flicker.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        flicker.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        flicker.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        flicker.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        flicker.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        flicker.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        flicker.SetActive(false);
    }
}
