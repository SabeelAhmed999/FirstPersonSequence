using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public bool interactionRange;

    public GameEvent OnObjectInteraction;
    public GameObject particle;
    public void Interact()
    {
        Debug.Log("Interation");
        OnObjectInteraction.Raise(this, particle);
    }
}
