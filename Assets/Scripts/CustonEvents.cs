using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class CustonEvent<T>
{
    private List<Action<T>> listeners;

    public UnityEvent onTrigger;

    public CustonEvent()
    {
        listeners = new List<Action<T>>();
    }

    public void AddListener(Action<T> newListener)
    {
        listeners.Add(newListener);
    }

    public void Trigger(T value)
    {
        for(int i = 0; i < listeners.Count; i++)
        {
            listeners[i].Invoke(value);
        }

        onTrigger.Invoke();
    }

    public void RemoveListener(Action<T> listenerToRemove)
    {
        listeners.Remove(listenerToRemove);
    }
}

[System.Serializable]
public class CustonEvent<T1,T2>
{
    private List<Action<T1, T2>> listeners;

    public UnityEvent onTrigger;

    public CustonEvent()
    {
        listeners = new List<Action<T1, T2>>();
    }

    public void AddListener(Action<T1, T2> newListener)
    {
        listeners.Add(newListener);
    }

    public void Trigger(T1 value1, T2 value2)
    {
        for (int i = 0; i < listeners.Count; i++)
        {
            listeners[i].Invoke(value1, value2);
        }

        onTrigger.Invoke();
    }

    public void RemoveListener(Action<T1, T2> listenerToRemove)
    {
        listeners.Remove(listenerToRemove);
    }
}


public class CustonEvents : MonoBehaviour
{
    public static CustonEvents Instance;

    public CustonEvent<Vector3Int> OnNewMouseGridPosition = new CustonEvent<Vector3Int>();
    public CustonEvent<Vector3Int> OnClickGridCell = new CustonEvent<Vector3Int>();
    public CustonEvent<int> OnNewTurn = new CustonEvent<int>();

    private void Awake()
    {
        Instance = this;
    }
}
