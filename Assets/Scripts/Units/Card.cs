using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{ 
    [HideInInspector] public int id { get; set; }
    [HideInInspector] public int matchID { get; set; }
    public Image matchImg;
    [HideInInspector] public Image bgImg;
    private Button button;
    public bool isEnabled { get; set; }
    public Sprite[] bgImage { get; set; }

    public bool isFlippedBack = true;

    private void Awake()
    {
        bgImg = GetComponent<Image>();
        matchImg.preserveAspect = true;
        bgImg.preserveAspect = true;
        button = GetComponent<Button>();
    }

    // sử dụng nếu card đã được match
    public void CheckMatch()
    {
        button.enabled = false;
        AudioManager.Instance.PlaySound("Correct SFX");
    }

    public void Flip()
    {
        isFlippedBack = !isFlippedBack;
        Color matchColor = matchImg.color;

        if (isFlippedBack)
        {
            bgImg.sprite = bgImage[0];
            matchColor.a = 0;
        }
        else
        {
            bgImg.sprite = bgImage[1];
            matchColor.a = 1;
        }
        matchImg.color = matchColor;
    }
}
