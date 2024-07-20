using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        AudioManager.Instance.UpdateMixerVolume(value, -1);
    }
    public void OnSfxUpdate(float value) { 
        Debug.Log("SFX: " + value);
        AudioManager.Instance.UpdateMixerVolume(-1, value);
    }

    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;
    public void OpenPanel()
    {
        this.gameObject.SetActive(true);
        musicSlider.value = AudioManager.Instance.GetValue("Music Volume") / 100f;
        sfxSlider.value = AudioManager.Instance.GetValue("SFX Volume") / 100f;
    }    
    public void ClosePanel()
    {
        this.gameObject.SetActive(false);
    }
}
