using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameRules : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textScore;                                                     // ���������� � ����� ����� ���������� �� ���������� �����.
    [SerializeField] TextMeshProUGUI textLifes;                                                     // ���������� � ����� ����� ���������� �� ���������� ������.
    private GameObject _platform;                                                                   // ������� ���������� ��������� (��� �����������).
    private GameObject _ball;                                                                       // ������� ���������� ���� (��� �����������).
    public GameObject platformPrefab;                                                               // ������� ������ �� ������� �� ������ ���������.
    public GameObject ballPrefab;                                                                   // ������� ������ �� ������� �� ������ ���.
    public int _playerScore;                                                                        // ���������� ����� � ������.
    public int _playerLifes;                                                                        // ���������� ������ � ������.

    void Start()
    {
        _playerScore = 0;                                                                           // ��������� ���������� ����� ����� 0.
        _playerLifes = 3;                                                                           // ��������� ���������� ������ ����� 3.
        textScore.text = _playerScore.ToString();                                                   // ������������� int � string, ������ ����� � ���� � �������.
        textLifes.text = _playerLifes.ToString();                                                   // ������������� int � string, ������ ������ � ���� � �������.
        OnPosition();                                                                               // ��������� ��������� � ���� � �������� �����������.
    }

    private void Update()
    {
        textScore.text = _playerScore.ToString();                                                   // ������������� int � string, ������ ����� � ���� � �������.
    }

    /// <summary>
    /// ����� ����������� ��� ������� ����, ���������� ���������� ������� ������, 
    /// �������� �� ����� ����, ����������� ��������� � ����, ����������� ���� 
    /// � ��������� �������.
    /// </summary>
    public void Dead()
    {
        PlayerLifes();                                                                              // ������ ������. �������� �� ��������� ���������� ������ ������.                                                                             
        Destroy(_platform);                                                                         // ����������� ���������.
        Destroy(_ball);                                                                             // ����������� ����.
        MovingBall.isFall = false;                                                                  // ���� isFall ����������� � ��������� false.
        OnPosition();                                                                               // ��������� ��������� � ���� �� �������� �������.
    }

    /// <summary>
    /// ����� ����������/���������� ���������� ������ � ������.
    /// </summary>
    public void PlayerLifes()
    {
        // ������� ���������� ���������� ������.
        //if ()
        //{
        //    _playersLife++;
        //}

        // ������� ���������� ���������� ������.
        if (MovingBall.isFall == true)                                                              // ���� ��� ������, 
        {
            _playerLifes--;                                                                         // �� ����� ������ 1 �����.
            textLifes.text = _playerLifes.ToString();                                               // ���������� ���������� ������ ������.
            GameOver();                                                                             // �������� �� ��������� ����.
        }
    }

    /// <summary>
    /// ����� �������� ��������� ���� ��� ������ ���� ������ ��� ��� ����������� ���� ������.
    /// </summary>
    public void GameOver()
    {
        if (_playerLifes <= 0)                                                                      // ���� ������ ������ ������ 0,
        {
            Debug.Log("Game Over");                                                                 // �� ���� ������������� ����������.
        }

        if (_playerLifes > 0)                                                                       // ���� ������ ������ ������ 0,
        {
            Debug.Log("���������� ������ -1.");                                                                 // �� 
        }

        //if(���������� ������ < 0)
        //{

        //}
    }

    /// <summary>
    /// ������ ������� ��������� � ��� �� �������� �������, 
    /// ��������� ��������� ������������ �������� ��� ����.
    /// </summary>
    public void OnPosition()
    {
        _platform = Instantiate(platformPrefab, new Vector2(0, -8), Quaternion.identity);           // �������� ������� ���������, ������������� �� ����� � ��������� �����������.
        _ball = Instantiate(ballPrefab, new Vector2(0,-8), Quaternion.identity);                    // �������� ������� ���, ������������� �� ����� � ��������� �����������.
        _ball.transform.SetParent(_platform.transform);                                             // ���������� ��������� ������������ �������� ��� ����.
    }
}
