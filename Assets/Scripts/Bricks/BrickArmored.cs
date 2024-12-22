using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickArmored : BrickTemplate
{
    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.black;                                                 // ��������������� ���� �����.
        
        brickHP = 9999;                                                                     // ��������� �����.
        brickScore = 10;                                                                    // ���������� ����� �� ������������ ����.
    }
}
