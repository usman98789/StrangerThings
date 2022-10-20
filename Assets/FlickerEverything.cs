using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerEverything : MonoBehaviour
{
    [SerializeField] GameObject ceil;
    [SerializeField] GameObject flash;
    private bool inTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        inTrigger = true;
        StartCoroutine(FlashCeil());
        ceil.GetComponent<AudioSource>().Play();
        StartCoroutine(Flash());
    }

    private void OnTriggerStay(Collider other)
    {
        inTrigger = true;
    }

    private void OnTriggerExit(Collider other)
    {
        inTrigger = false;
    }

    IEnumerator FlashCeil()
    {
        while (true)
        {
            ceil.GetComponent<MeshRenderer>().enabled = true;
            yield return new WaitForSeconds(0.5f);
            ceil.GetComponent<MeshRenderer>().enabled = false;
            yield return new WaitForSeconds(0.5f);
        }
    }

    IEnumerator Flash()
    {
        while (true)
        {
            flash.SetActive(false);
            yield return new WaitForSeconds(0.25f);
            flash.SetActive(true);
            yield return new WaitForSeconds(0.25f);
        }
    }
}
