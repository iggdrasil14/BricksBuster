using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_3_deer : LevelGenerator
{
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
    public override void StartLevel()
    {
        brickTotalValue = 105;                                                          // ������������ ���������� ������ �� ������.
        _levelNumber = 3;                                                               // ����� �������� ������.

        PlayerPrefs.SetInt("PlayerLevelNumber", _levelNumber);                          // ������ ������ � ������� ������ ������.
        PlayerPrefs.Save();                                                             // ���������� ������ � ������� ������ ������.

        textLevelNumber.text = "Level: " + _levelNumber.ToString();                     // ������������� int � string, ������ ������ ������ � ���� � �������.

        //Time.timeScale = 1;                                                             // ����� ��������������� ����������� �������� - 1.
        //MovingBall movingBall = FindObjectOfType<MovingBall>();                         // ������� ���� � ���������� ��������� (����� ��� �������� ������ ������/����� ��� �� �������������, � ����� ���� ����� 0)
        //movingBall.isActive = false;
    }
}
