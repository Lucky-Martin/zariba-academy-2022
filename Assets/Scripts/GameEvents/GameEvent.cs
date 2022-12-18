using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="GameEvent")]
public class GameEvent : ScriptableObject
{
    public List<GameEventListener> Listeners = new List<GameEventListener>();

    public void RegisterListener(GameEventListener listener) {
        if(!Listeners.Contains(listener)) {
            Listeners.Add(listener);
        }
    }

    public void UnregisterListener(GameEventListener listener)
    {
        if(Listeners.Contains(listener)) {
            Listeners.Remove(listener);
        }
    }

    public void Raise(Component sender, object data)
    {
        Debug.Log("Raise");
        for(int i = 0 ; i < Listeners.Count; i++) {
            Listeners[i].OnEventRaised(sender, data);
        }
    }
}