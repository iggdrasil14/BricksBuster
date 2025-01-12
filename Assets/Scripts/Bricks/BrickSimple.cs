using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSimple : BrickTemplate
{
    void Start()
    {
        brickHP = 1;                                                                        // Прочность блока.
        brickScore = 1;                                                                     // Количество очков за уничтоженный блок.
    }

    public override void Crash(bool isForceDestroy = false)
    {
        base.Crash(isForceDestroy);
    }
}
