using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public int sec = 0;                                                                     // ���������� ������.
    public int min = 0;                                                                     // ���������� �����.
    public TextMeshProUGUI timerText;                                                       // ������ �� ����� � ��������.
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
