using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickExplosive : BrickTemplate
{
    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.magenta;                                               // Устанавливается цвет блока.

        brickHP = 1;                                                                        // Прочность блока.
        brickScore = 5;                                                                     // Количество очков за уничтоженный блок.
    }
}
