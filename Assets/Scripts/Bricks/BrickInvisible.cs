using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickInvisible : BrickTemplate
{
    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.white;                                                 // ��������������� ���� �����.

        brickHP = 2;                                                                        // ��������� �����.
        brickScore = 3;                                                                     // ���������� ����� �� ������������ ����.
    }

    public override void Crash(bool isForceDestroy = false)
    {
        base.Crash(isForceDestroy);
    }
}
