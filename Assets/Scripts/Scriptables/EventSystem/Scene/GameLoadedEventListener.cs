using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameLoadedEventListener : MonoBehaviour
{
    [SerializeField] private UnityEvent<int, int> InitEventResponse;
    [SerializeField] private UnityEvent<CardThemeSO> InitThemeEventResponse;
    [SerializeField] private GameInitPublisherSO InitPublisher;
    private void OnEnable()
    {
        if (InitPublisher != null)
        {
            InitPublisher.OnSizeEventRaised += InitGameSize;
            InitPublisher.OnThemeEventRaised += InitGameTheme;
        }    
            
    }

    private void OnDisable()
    {
        if (InitPublisher != null)
        {
            InitPublisher.OnSizeEventRaised -= InitGameSize;
            InitPublisher.OnThemeEventRaised -= InitGameTheme;
        }
    }

    private void InitGameSize(int w, int h)
    {
        InitEventResponse?.Invoke(w, h);
    }

    private void InitGameTheme(CardThemeSO theme)
    {
        InitThemeEventResponse?.Invoke(theme);
    }
}