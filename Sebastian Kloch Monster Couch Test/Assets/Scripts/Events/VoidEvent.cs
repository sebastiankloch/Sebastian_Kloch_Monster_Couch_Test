using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Void Event", menuName = "Scriptable Objects/Void Event")]
public class VoidEvent : ScriptableObject
{
    private event Action listeners;

    public void Rise()
    {
        listeners?.Invoke();
    }

    public void AddListener(Action action)
    {
        listeners += action;
    }

    public void RemoveListener(Action action)
    {
        listeners -= action;
    }
}
