using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runAcross : MonoBehaviour
{
    [SerializeField] float speed;
    private void Update()
    {
        transform.Translate(Vector3.forward * (Time.deltaTime * speed));
    }
}
