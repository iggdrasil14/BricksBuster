using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSimple : BrickTemplate
{
    void Start()
    {
        brickHP = 1;                                                                        // ��������� �����.
        brickScore = 1;                                                                     // ���������� ����� �� ������������ ����.
    }

    public override void Crash(bool isForceDestroy = false)
    {
        base.Crash(isForceDestroy);
    }
}
