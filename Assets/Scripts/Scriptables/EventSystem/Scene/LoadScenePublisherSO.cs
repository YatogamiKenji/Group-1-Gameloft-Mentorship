using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Load Scene Pulisher", menuName = "Scriptable Objects/Events/Load Scene Publisher")]
public class LoadScenePublisherSO : ScriptableObject
{
    public UnityAction<string> OnEventRaised;

    public void RaiseEvent(string SceneName)
    {
        Debug.Log("RAISED "+SceneName);
        OnEventRaised?.Invoke(SceneName);
    }
}