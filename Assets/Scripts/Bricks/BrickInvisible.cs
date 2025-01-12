using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickInvisible : BrickTemplate
{
    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.white;                                                 // Устанавливается цвет блока.

        brickHP = 2;                                                                        // Прочность блока.
        brickScore = 3;                                                                     // Количество очков за уничтоженный блок.
    }

    public override void Crash(bool isForceDestroy = false)
    {
        base.Crash(isForceDestroy);
    }
}
