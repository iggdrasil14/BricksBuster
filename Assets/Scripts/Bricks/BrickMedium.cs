using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickMedium : BrickTemplate
{
    void Start()
    {
        brickHP = 2;                                                                        // Прочность блока.
        brickScore = 2;                                                                     // Количество очков за уничтоженный блок.
    }
    public override void Crash(bool isForceDestroy = false)
    {
        base.Crash(isForceDestroy);
    }
}
