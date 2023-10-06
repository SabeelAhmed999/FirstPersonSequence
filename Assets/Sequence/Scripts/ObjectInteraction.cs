using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    private Camera mainCamera; // Reference to the main camera.

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {

        if (Input.GetMouseButtonDown(0)) 
        {

            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;


            if (Physics.Raycast(ray, out hit))
            {
                InteractableObject interactableObject = hit.collider.GetComponent<InteractableObject>();

                if (interactableObject != null&&interactableObject.interactionRange)
                {
                    interactableObject.Interact();
                }
            }
        }
    }
}
