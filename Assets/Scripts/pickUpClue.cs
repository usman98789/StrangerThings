using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pickUpClue : MonoBehaviour
{
    private AudioSource audioSrc;
    private MeshRenderer mesh;
    [SerializeField] Text text;
    private void Start()
    {
        audioSrc = GetComponent <AudioSource>();
        mesh = GetComponent<MeshRenderer>();
    }
    public void ObjectInteraction()
    {
        audioSrc.Play();
        int val;
        int.TryParse(text.text.ToString().Substring(0,1), out val);
        if (val < 4)
        {
            val += 1;
        }
        text.text = val.ToString() + " / 4";
        mesh.enabled = false;
        StartCoroutine(Disablein3());
    }

    IEnumerator Disablein3()
    {
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
    }
}
