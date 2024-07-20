using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingButton : MonoBehaviour
{
    [SerializeField] private LoadScenePublisherSO loadSceneSO;

    private void Awake()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(OnSettingButtonClick);
    }

    private void OnSettingButtonClick()
    {
        loadSceneSO.RaiseEvent("MenuSceneTest");
        Time.timeScale = 1.0f;
    }
}
