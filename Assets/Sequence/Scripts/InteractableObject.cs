using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public bool interactionRange;

    public GameEvent OnObjectInteraction;
    public GameObject particle;
    public void Interact()
    {
        if(particle!=null)
            OnObjectInteraction.Raise(this, particle);
        else
            OnObjectInteraction.Raise(this, null);
    }
}
