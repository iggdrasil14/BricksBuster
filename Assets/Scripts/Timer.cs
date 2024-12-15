using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public int sec = 0;                                                                     // Переменная секунд.
    public int min = 0;                                                                     // Переменная минут.
    public TextMeshProUGUI timerText;                                                       // Ссылка на текст с таймером.
    [SerializeField] private int delta = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ITimer());
    }

    IEnumerator ITimer()
    {
        while (true)
        {
            if (sec == 59)
            {
                min++;
                sec = -1;
            }
            sec += delta;
            timerText.text = min.ToString("D2") + " : " + sec.ToString("D2");
            yield return new WaitForSeconds(1);
        }
    }
}
