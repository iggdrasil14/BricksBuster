using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI textLevelNumber;                                   // ���������� � ����� ����� ���������� �� ����� ������.
    public int brickTotalValue;                                                         // ������������ ���������� ������ �� ������.
    public int _levelNumber;                                                            // ����� ������.

    private void Awake()
    {
        StartLevel();
    }

    /// <summary>
    /// ����� ������������ ������ ��� ������� Play Again ��� Restart.
    /// </summary>
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);               // �������� ���� ��������� ������� �����.
    }

    /// <summary>
    /// 
    /// </summary>
    public virtual void StartLevel()
    {
        brickTotalValue = 151;                                                          // ������������ ���������� ������ �� ������.
        _levelNumber = 1;                                                               // ����� �������� ������.

        PlayerPrefs.SetInt("PlayerLevelNumber", _levelNumber);                          // ������ ������ � ������� ������ ������.
        PlayerPrefs.Save();                                                             // ���������� ������ � ������� ������ ������.

        textLevelNumber.text = "Level: " + _levelNumber.ToString();                     // ������������� int � string, ������ ������ ������ � ���� � �������.

        //Time.timeScale = 1;                                                             // ����� ��������������� ����������� �������� - 1.
        //MovingBall movingBall = FindObjectOfType<MovingBall>();                         // ������� ���� � ���������� ��������� (����� ��� �������� ������ ������/����� ��� �� �������������, � ����� ���� ����� 0)
        //movingBall.isActive = false;
    }
}
