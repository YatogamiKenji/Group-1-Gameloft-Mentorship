using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Game Init Pulisher", menuName = "Scriptable Objects/Events/Game Init Publisher")]
public class GameInitPublisherSO : ScriptableObject
{
    public UnityAction<int, int> OnSizeEventRaised;
    public SizeConfigSO SizeConfig;

    public UnityAction<CardThemeSO> OnThemeEventRaised;
    public ThemeConfigSO ThemeConfig;

    public void RaiseSizeEvent()
    {
        OnSizeEventRaised?.Invoke(SizeConfig.crnW, SizeConfig.crnH);
    }

    public void RaiseThemeEvent()
    {
        OnThemeEventRaised?.Invoke(ThemeConfig.GetCurrentTheme());
    }
}