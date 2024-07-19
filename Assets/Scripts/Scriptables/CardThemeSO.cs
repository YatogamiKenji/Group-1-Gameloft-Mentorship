using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Card Theme", menuName = "Scriptable Objects/Card Theme")]
public class CardThemeSO : ScriptableObject
{
    public Sprite[] bgImage; //Background của thẻ, gồm 2 phần tử là mode đóng và lật
    public List<Sprite> matchImages; //pattern của thẻ, gồm các pattern có sẵn
    public string Name;
    public Sprite ThemeImage;
    public Sprite ThemeThumbnail;
}
