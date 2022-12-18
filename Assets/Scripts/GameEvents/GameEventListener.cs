using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[System.Serializable]
public class CustomUnityEvent : UnityEvent<Component, object> {}

public class GameEventListener : MonoBehaviour
{
    
    [Tooltip("Event to register with.")]
    public GameEvent Event;
    
    [Tooltip("Response to invoke when Event with GameData is raised.")]
    public CustomUnityEvent response;

    private void OnEnable() {
        Event.RegisterListener(this);
    }

    private void OnDisable() {
        Event.UnregisterListener(this);
    }

    public void OnEventRaised(Component sender, object data) {
        response.Invoke(sender, data);
    }
}
