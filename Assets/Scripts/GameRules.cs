using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameRules : MonoBehaviour
{
    private GameObject _platform;                                                                   // ������� ���������� ��������� (��� �����������).
    private GameObject _ball;                                                                       // ������� ���������� ���� (��� �����������).
    public GameObject platformPrefab;                                                               // ������� ������ �� ������� �� ������ ���������.
    public GameObject ballPrefab;                                                                   // ������� ������ �� ������� �� ������ ���.
    private int _playerLifes;                                                                       // ���������� ������ � ������.

    void Start()
    {
        _playerLifes = 3;                                                                           // ��������� ���������� ������ ����� 3.
        OnPosition();                                                                               // ��������� ��������� � ���� � �������� �����������.
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
