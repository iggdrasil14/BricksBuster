using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickInvisible : BrickTemplate
{
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.white;                                                 // ��������������� ���� �����.

        brickHP = 2;                                                                        // ��������� �����.
        brickScore = 3;                                                                     // ���������� ����� �� ������������ ����.
    }
}
