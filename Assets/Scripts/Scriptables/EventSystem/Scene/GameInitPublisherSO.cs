using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Game Init Pulisher", menuName = "Scriptable Objects/Events/Game Init Publisher")]
public class GameInitPublisherSO : ScriptableObject
{
    public UnityAction<int, int> OnSizeEventRaised;
    public UnityAction<CardThemeSO> OnThemeEventRaised;

    public void RaiseSizeEvent(int w, int h)
    {
        OnSizeEventRaised?.Invoke(w, h);
    }

    public void RaiseThemeEvent(CardThemeSO theme)
    {
        OnThemeEventRaised?.Invoke(theme);
    }
}