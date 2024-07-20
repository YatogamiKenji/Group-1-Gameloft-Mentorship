using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound(string name)
    {
        AudioManager.Instance.PlaySound(name);
    }
    public void StopSound(string name)
    {
        AudioManager.Instance.StopSound(name);
    }
    public void LoadScene(string SceneName)
    {
        Debug.Log("LOADING "+SceneName);
        SceneManager.LoadScene(SceneName);
    }

    

}
