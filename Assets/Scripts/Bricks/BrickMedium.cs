using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickMedium : BrickTemplate
{
    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.yellow;                                                // Устанавливается цвет блока.

        brickHP = 2;                                                                        // Прочность блока.
        brickScore = 2;                                                                     // Количество очков за уничтоженный блок.
    }
}
