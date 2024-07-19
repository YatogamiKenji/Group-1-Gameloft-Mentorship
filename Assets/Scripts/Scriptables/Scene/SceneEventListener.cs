using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SceneEventListener : MonoBehaviour
{
    [SerializeField] private UnityEvent<string> EventResponse;
    [SerializeField] private UnityEvent<int, int> InitEventResponse;
    [SerializeField] private LoadScenePublisherSO LoadPublisher;
    [SerializeField] private GameInitPublisherSO InitPublisher;
    private void OnEnable()
    {
        if(LoadPublisher != null)
            LoadPublisher.OnEventRaised += RespondLoadScene;
        if (InitPublisher != null)
            InitPublisher.OnEventRaised += InitGameScene;
    }

    private void OnDisable()
    {
        if (LoadPublisher != null)
            LoadPublisher.OnEventRaised -= RespondLoadScene;
        if (InitPublisher != null)
            InitPublisher.OnEventRaised -= InitGameScene;
    }

    private void RespondLoadScene(string SceneName)
    {
        Debug.Log("LISTENED " + SceneName);
        EventResponse?.Invoke(SceneName);
    }

    private void InitGameScene(int w, int h)
    {
        InitEventResponse?.Invoke(w, h);
    }
}