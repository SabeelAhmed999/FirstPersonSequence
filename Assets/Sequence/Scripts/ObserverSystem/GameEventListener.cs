using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum Status{successful,failed}
[System.Serializable]
public class CustomGameEvent : UnityEvent<Component , object>{}

public class GameEventListener : MonoBehaviour
{
    [Tooltip("Event to register with.")]
    public GameEvent Event;

    [Tooltip("Response to invoke when Event is raised.")]
    public CustomGameEvent response;

    private void OnEnable()
    {
        Event.RegisterListener(this);
    }

    private void OnDisable()
    {
        Event.UnregisterListener(this);
    }
    public void OnEventRaised(Component sender, object data)
    {
        response.Invoke(sender,data);
    }
}