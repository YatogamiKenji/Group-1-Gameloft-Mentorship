using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Card Pulisher", menuName = "Scriptable Objects/Events/Card Publisher")]
public class CardPublisherSO : ScriptableObject
{
    public UnityAction<Card> OnEventRaised;

    public void RaiseEvent(Card value)
    {
        OnEventRaised?.Invoke(value);
    }
}
