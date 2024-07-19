using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Game Init Pulisher", menuName = "Scriptable Objects/Events/Game Init Publisher")]
public class GameInitPublisherSO : ScriptableObject
{
    public UnityAction<int, int> OnEventRaised;

    public void RaiseEvent(int w, int h)
    {
        OnEventRaised?.Invoke(w, h);
    }
}