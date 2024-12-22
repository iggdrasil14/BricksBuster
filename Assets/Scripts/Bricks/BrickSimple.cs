using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSimple : BrickTemplate
{
    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.white;                                                 // ��������������� ���� �����.

        brickHP = 1;                                                                        // ��������� �����.
        brickScore = 1;                                                                     // ���������� ����� �� ������������ ����.
    }
}
