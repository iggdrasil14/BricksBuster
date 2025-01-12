using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickHeavy : BrickTemplate
{
    void Start()
    {
        brickHP = 3;                                                                        // Прочность блока.
        brickScore = 3;                                                                     // Количество очков за уничтоженный блок.
    }
    public override void Crash(bool isForceDestroy = false)
    {
        base.Crash(isForceDestroy);
    }
}
