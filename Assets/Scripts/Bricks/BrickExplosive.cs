using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickExplosive : BrickTemplate
{
    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.magenta;                                               // ��������������� ���� �����.

        brickHP = 1;                                                                        // ��������� �����.
        brickScore = 5;                                                                     // ���������� ����� �� ������������ ����.
    }
}
