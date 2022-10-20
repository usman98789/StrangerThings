using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoRun : MonoBehaviour
{

    [SerializeField] GameObject key2;
    [SerializeField] GameObject demogorgon;

    private void OnTriggerEnter(Collider other)
    {
        if (!key2.activeInHierarchy)
        {
            StartCoroutine(DemogorgonRun());
        }
    }

    IEnumerator DemogorgonRun()
    {
        demogorgon.SetActive(true);
        yield return new WaitForSeconds(4);
        demogorgon.SetActive(false);
    }
}
