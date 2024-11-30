using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameRules : MonoBehaviour
{
    public GameObject platformPrefab;
    public GameObject ballPrefab;
    private int _playerLifes;                                                                   // ���������� ������ � ������

    void Start()
    {
        _playerLifes = 3;                                                                       // ��������� ���������� ������ ����� 3.
        Instantiate(platformPrefab, new Vector2(0, -8), Quaternion.identity);                   // ������������� ������� ��������� � ��������� �����������.
        Instantiate(ballPrefab, new Vector2(0, -8), Quaternion.identity);                       // ������������� ������� ���� � ��������� �����������.                                                                          // ��������� ��������� � ���� � �������� �����������.
    }

    void Update()
    {
        if(MovingBall.isFall == true)
        {
            Debug.Log("������� ���������");
            Destroy(GameObject.Find("PlatformPrefab(Clone)"));
            Destroy(GameObject.Find("BallPrefab(Clone)"));
            MovingBall.isFall = false;
            OnPosition();
        }
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
        if (MovingBall.isFall == true)                                                          // ���� ��� ������, 
        {
            _playerLifes--;                                                                     // �� ����� ������ 1 �����.
            GameOver();                                                                         // �������� �� ��������� ����.
        }
    }

    /// <summary>
    /// ����� �������� ��������� ���� ��� ������ ���� ������ ��� ��� ����������� ���� ������.
    /// </summary>
    public void GameOver()
    {
        if (_playerLifes <= 0)                                                                  // ���� ������ ������ ������ 0,
        {
            Debug.Log("Game Over");                                                             // �� ���� ������������� ����������.
        }

        //if(���������� ������ < 0)
        //{

        //}
    }

    /// <summary>
    /// ������ ������� ��������� � ��� �� �������� �������.
    /// </summary>
    public void OnPosition()
    {
        Instantiate(platformPrefab, new Vector2(0, -8), Quaternion.identity);                   // ������������� ������� ��������� � ��������� �����������.
        Instantiate(ballPrefab, new Vector2(0, -8), Quaternion.identity);                       // ������������� ������� ���� � ��������� �����������.
    }
}
