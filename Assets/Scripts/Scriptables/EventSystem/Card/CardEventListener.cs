using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CardEventListener : MonoBehaviour
{
    [SerializeField] private UnityEvent<Card> EventResponse;
    [SerializeField] private CardPublisherSO publisher;

    private void OnEnable()
    {
        publisher.OnEventRaised += Respond;
    }

    private void OnDisable()
    {
        publisher.OnEventRaised -= Respond;
    }

    private void Respond(Card value)
    {
        EventResponse?.Invoke(value);
    }
}
