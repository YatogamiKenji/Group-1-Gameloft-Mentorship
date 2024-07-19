using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingScene : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI WText;
    public TextMeshProUGUI HText;
    public TextMeshProUGUI ThemeNameText;
    public Image themeImage;

    public SizeConfigSO SizeConfig;
    public ThemeConfigSO ThemeConfig;
    public void UpdateText()
    {
        WText.text = SizeConfig.crnW.ToString();
        HText.text = SizeConfig.crnH.ToString();
    }
    public void UpdateTheme()
    {
        themeImage.sprite = ThemeConfig.GetCurrentTheme().ThemeThumbnail;
        ThemeNameText.text = ThemeConfig.GetCurrentTheme().Name;
    }
    void Start()
    {
        UpdateText();
        UpdateTheme();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
