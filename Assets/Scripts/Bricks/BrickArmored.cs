using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickArmored : BrickTemplate
{
    void Start()
    {
        brickHP = 999;                                                                      // ��������� �����.
        brickScore = 10;                                                                    // ���������� ����� �� ������������ ����.
    }
    public override void Crash(bool isForceDestroy = false)
    {
        base.Crash(isForceDestroy);
    }
}
