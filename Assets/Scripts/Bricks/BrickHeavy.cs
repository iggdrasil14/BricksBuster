using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickHeavy : BrickTemplate
{
    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.red;                                                   // Устанавливается цвет блока.

        brickHP = 3;                                                                        // Прочность блока.
        brickScore = 3;                                                                     // Количество очков за уничтоженный блок.
    }
}
