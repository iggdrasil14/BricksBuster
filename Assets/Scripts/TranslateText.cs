using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public enum Language
{
    ru,
    en,
    de
}

public class TranslateText : MonoBehaviour
{
    public TextMeshProUGUI text;

    [Space(10)]
    [Header("Переводы")]
    public string ru_text;
    public string en_text;
    public string de_text;



    // Update is called once per frame
    void Update()
    {
        int indexLang = PlayerPrefs.GetInt("lang");
        Language language = (Language)indexLang;
        switch (language) 
        {
            case Language.ru:
                text.text = ru_text; 
                break;
            case Language.en: 
                text.text = en_text; 
                break;
            case Language.de:
                text.text = de_text;
                break;
        }
    }
}
