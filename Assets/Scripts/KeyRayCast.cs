using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace KeySystem
{
    public class KeyRayCast : MonoBehaviour
    {
        [SerializeField] private int rayLength = 5;
        [SerializeField] private LayerMask layerMaskInteract;
        [SerializeField] private string excludeLayername = null;

        private KeyItemController rayCastObj;
        private pickUpClue rayCastObj2;
        [SerializeField] GameObject interactText;

        private bool started = false;
        private void Update()
        {
            RaycastHit hit;
            Vector3 fwd = transform.TransformDirection(Vector3.forward);

            int mask = 1 << LayerMask.NameToLayer(excludeLayername) | layerMaskInteract.value;

            if (Physics.Raycast(transform.position, fwd, out hit, rayLength, mask))
            {
                if (hit.collider.CompareTag("interact"))
                {
                    bool rayCast2 = false;
                    if (hit.collider.gameObject.name.Contains("paper"))
                    {
                        if (!started)
                        {
                            StartCoroutine(ShowOneSecond());
                        }
                        rayCastObj2 = hit.collider.gameObject.GetComponent<pickUpClue>();
                        rayCast2 = true;
                    } else
                    {
                        rayCastObj = hit.collider.gameObject.GetComponent<KeyItemController>();
                    }

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (rayCast2) {
                            rayCastObj2.ObjectInteraction();
                        } else
                        {
                            rayCastObj.ObjectInteraction();
                        }
                    }

                }
            }
        }

        IEnumerator ShowOneSecond()
        {
            started = true;
            interactText.SetActive(true);
            yield return new WaitForSeconds(0.3f);
            interactText.SetActive(false);
            started = false;
        }
    }
}

