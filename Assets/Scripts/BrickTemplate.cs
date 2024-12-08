using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickTemplate : MonoBehaviour
{
    public GameObject brickPrefab;                                          // ���� � �������� �����.
    public List<Sprite> brickSprites;                                       // ������ �������� ����� (�����, ������������, ����� �����������).
    public Color brickColor;                                                // ���� �����.
    public int brickScore;                                                  // ���������� - ���������� ����� �� ������������ ����.
    public int brickHP;                                                     // ���������� - ���������� ������ � �����.

    void Start()
    {
        brickScore = 1;
        brickHP = 1;
    }

    void Update()
    {
        
    }
}
