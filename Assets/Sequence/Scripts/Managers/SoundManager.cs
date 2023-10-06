using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip pickUp, drop;

    public void OnInteraction(Component component, object data)
    {
        if (component.gameObject.name == "Stone")
        {
            audioSource.clip = pickUp;
            audioSource.Play();
        }
        if (component.gameObject.name == "BoxA")
        {
            audioSource.clip = drop;
            audioSource.Play();
        }
        if (component.gameObject.name == "BoxB")
        {
            audioSource.clip = drop;
            audioSource.Play();
        }
        if (component.gameObject.name == "BoxC")
        {
            audioSource.clip = drop;
            audioSource.Play();
        }
    }
}
