using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{ 
    public int id { get; set; }
    public int matchID { get; set; }
    [HideInInspector] public Image matchImg;
    [HideInInspector] public Image bgImg;
    public bool isEnabled { get; set; }
    public Sprite[] bgImage { get; set; }

    public bool isFlipped = true;

    private void Awake()
    {
        matchImg = GetComponent<Image>();
        bgImg = GetComponentInChildren<Image>();
        matchImg.preserveAspect = true;
    }
}
