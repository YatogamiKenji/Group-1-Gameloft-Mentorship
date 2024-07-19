using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSetting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMusicUpdate(float value) {
        Debug.Log("Music: " + value);
    }
    public void OnSfxUpdate(float value) { 
        Debug.Log("SFX: " + value);
    }

    public void OpenPanel()
    {
        this.gameObject.SetActive(true);
    }    
    public void ClosePanel()
    {
        this.gameObject.SetActive(false);
    }
}
