using System.Collections.Generic;
using UnityEngine;

public abstract class BaseGameEvent<T> : ScriptableObject
{
    private readonly List<IGameEventListener<T>> EventListeners = new List<IGameEventListener<T>>();

    public T DebugValue;

    public void Raise(T item)
    {
        for (int i = EventListeners.Count - 1; i >= 0; i--)
        {
            EventListeners[i].OnEventRaise(item);
        }
    }

    public void RegisterListener(IGameEventListener<T> listener)
    {
        if (!EventListeners.Contains(listener))
            EventListeners.Add(listener);
    }

    public void UnregisterListener(IGameEventListener<T> listener)
    {
        if (EventListeners.Contains(listener))
            EventListeners.Remove(listener);
    }
}
