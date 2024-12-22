using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickHeavy : BrickTemplate
{
    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.red;                                                   // ��������������� ���� �����.

        brickHP = 3;                                                                        // ��������� �����.
        brickScore = 3;                                                                     // ���������� ����� �� ������������ ����.
    }
}
