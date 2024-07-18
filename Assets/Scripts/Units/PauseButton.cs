using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    [SerializeField] private VoidPublisherSO pauseGameSO;

    private void Awake()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(OnPauseButtonClick);
    }

    private void OnPauseButtonClick()
    {
        pauseGameSO.RaiseEvent();
    }
}
