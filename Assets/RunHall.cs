using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class RunHall : MonoBehaviour
{
    [SerializeField] GameObject text;
    [SerializeField] FirstPersonController fps;

    [SerializeField] GameObject demo1;
    [SerializeField] GameObject demo2;


    private void OnTriggerEnter(Collider other)
    {
        fps.m_RunSpeed = 4.5f;
        fps.m_RunstepLenghten = 0.5f;
        text.SetActive(true);
        demo1.SetActive(true);
        demo2.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        text.SetActive(false);
    }
}
