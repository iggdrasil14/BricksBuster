using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSimple : BrickTemplate
{
    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.white;                                                 // Устанавливается цвет блока.

        brickHP = 1;                                                                        // Прочность блока.
        brickScore = 1;                                                                     // Количество очков за уничтоженный блок.
    }
}
