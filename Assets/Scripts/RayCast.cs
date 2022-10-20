using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    [SerializeField] private int rayLength = 6;
    [SerializeField] private LayerMask layerMaskInteract;
    [SerializeField] private string excludeLayerName = null;

    private MyDoorController rayCastedObj;

    private void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        int mask = 1 << LayerMask.NameToLayer(excludeLayerName) | layerMaskInteract.value;

        if (Physics.Raycast(transform.position, fwd, out hit, rayLength, mask))
        {
            if (hit.collider.CompareTag("interact"))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    rayCastedObj = hit.collider.gameObject.GetComponent<MyDoorController>();
                    rayCastedObj.PlayAnimation();
                }

            }
        }
    }
}
