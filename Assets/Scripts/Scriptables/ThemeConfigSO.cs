using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ThemeConfigSO", menuName = "Scriptable Objects/ThemeConfigSO")]
public class ThemeConfigSO : ScriptableObject
{
    [SerializeField] CardThemeSO [] themeList;

    [SerializeField] int _crnThemeIndex = 0;
    public int crnThemeIndex { get { return _crnThemeIndex; } set { _crnThemeIndex = value; } }

    public CardThemeSO GetCurrentTheme() { return themeList[crnThemeIndex];}

    public void OnNextThemeChoose()
    {
        
        if (crnThemeIndex < themeList.Length - 1)
            crnThemeIndex++;
    }
    public void OnPrevThemeChoose()
    {
        if (crnThemeIndex > 0)
            crnThemeIndex--;
    }

}
