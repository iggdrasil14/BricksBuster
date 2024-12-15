using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageSwitch : MonoBehaviour
{
    public Language language;
    public void LanguageChange()
    {
        PlayerPrefs.SetInt("lang", (int)language);
    }
}
