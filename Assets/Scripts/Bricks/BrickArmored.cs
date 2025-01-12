using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickArmored : BrickTemplate
{
    void Start()
    {
        brickHP = 999;                                                                      // Прочность блока.
        brickScore = 10;                                                                    // Количество очков за уничтоженный блок.
    }
    public override void Crash(bool isForceDestroy = false)
    {
        base.Crash(isForceDestroy);
    }
}
