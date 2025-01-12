using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickTemplate : MonoBehaviour
{
    public GameObject brickPrefab;                                                      // ���� � �������� �����.
    public List<Sprite> brickSprites;                                                   // ������ �������� ����� (�����, ������������, ����� �����������).
    public Color brickColor;                                                            // ���� �����.
    public int brickScore;                                                              // ���������� - ���������� ����� �� ������������ ����.
    public int brickHP;                                                                 // ���������� - ���������� ������ � �����.
    public AudioClip audio;

    public virtual void Crash(bool isForceDestroy = false) 
    {
        if(isForceDestroy == true)
        {
            Destroy(gameObject);                                                        // ���� ������������,

            LevelGenerator levelGenerator = FindObjectOfType<LevelGenerator>();         // ��������� � �������
            levelGenerator.brickTotalValue--;                                           // ���������� ������ ���������� ������.

            GameRules gameRules = FindObjectOfType<GameRules>();                        // ��������� � �������.
            gameRules.GameOver();                                                       // �������� �� ���������� ������� ������ ��� ����������� �����.

            gameRules._playerScore = gameRules._playerScore + brickScore;               // ���������� ����� ������.
            return;
        }
        brickHP--;                                                                      // ���������� ������ ����� ����������� �� 1.
        if (brickHP <= 0)                                                               // ���� ���������� ������ ����� ����� 0 ��� ����, ��
        {
            Destroy(gameObject);                                                        // ���� ������������,

            LevelGenerator levelGenerator = FindObjectOfType<LevelGenerator>();         // ��������� � �������
            levelGenerator.brickTotalValue--;                                           // ���������� ������ ���������� ������.

            GameRules gameRules = FindObjectOfType<GameRules>();                        // ��������� � �������.
            gameRules.GameOver();                                                       // �������� �� ���������� ������� ������ ��� ����������� �����.

            gameRules._playerScore = gameRules._playerScore + brickScore;               // ���������� ����� ������.
        }
    } 
}
