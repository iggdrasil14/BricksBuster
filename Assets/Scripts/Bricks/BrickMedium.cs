using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickMedium : BrickTemplate
{
    void Start()
    {
        brickHP = 2;                                                                        // ��������� �����.
        brickScore = 2;                                                                     // ���������� ����� �� ������������ ����.
    }
    public override void Crash(bool isForceDestroy = false)
    {
        base.Crash(isForceDestroy);
    }
}
