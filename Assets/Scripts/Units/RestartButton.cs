using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{
    [SerializeField] private VoidPublisherSO restartGameSO;

    private void Awake()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(OnRestartButtonClick);
    }

    private void OnRestartButtonClick()
    {
        restartGameSO.RaiseEvent();
    }
}
