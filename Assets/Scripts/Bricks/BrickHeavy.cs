using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickHeavy : BrickTemplate
{
    void Start()
    {
        brickHP = 3;                                                                        // ��������� �����.
        brickScore = 3;                                                                     // ���������� ����� �� ������������ ����.
    }
    public override void Crash(bool isForceDestroy = false)
    {
        base.Crash(isForceDestroy);
    }
}
