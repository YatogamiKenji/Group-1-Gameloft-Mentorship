using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SceneEventListener : MonoBehaviour
{
    [SerializeField] private UnityEvent<string> EventResponse;
    
    [SerializeField] private LoadScenePublisherSO LoadPublisher;
    
    private void OnEnable()
    {
        if(LoadPublisher != null)
            LoadPublisher.OnEventRaised += RespondLoadScene;
        

    }

    private void OnDisable()
    {
        if (LoadPublisher != null)
            LoadPublisher.OnEventRaised -= RespondLoadScene;
        

    }

    private void RespondLoadScene(string SceneName)
    {
        Debug.Log("LISTENED " + SceneName);
        EventResponse?.Invoke(SceneName);
    }

    

}