using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickMedium : BrickTemplate
{
    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.yellow;                                                // ��������������� ���� �����.

        brickHP = 2;                                                                        // ��������� �����.
        brickScore = 2;                                                                     // ���������� ����� �� ������������ ����.
    }
}
