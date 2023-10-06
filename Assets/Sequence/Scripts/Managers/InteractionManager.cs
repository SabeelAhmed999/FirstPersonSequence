using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameEvent OnRestart;
    public InteractableObject interactable;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactable.interactionRange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactable.interactionRange = false;
        }
    }

    public void OnInteraction(Component component, object data)
    {
        if (component.gameObject.name == "BoxA")
        {
            GameObject obj  =(GameObject)data;
            obj.GetComponent<ParticleSystem>().Play();
        }
        if (component.gameObject.name == "BoxB")
        {
            GameObject obj = (GameObject)data;
            obj.GetComponent<ParticleSystem>().Play();
        }
        if (component.gameObject.name == "BoxC")
        {
            OnRestart.Raise(this, null);
        }
    }
}
