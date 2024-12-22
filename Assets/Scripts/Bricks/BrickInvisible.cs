using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickInvisible : BrickTemplate
{
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.white;                                                 // Устанавливается цвет блока.

        brickHP = 2;                                                                        // Прочность блока.
        brickScore = 3;                                                                     // Количество очков за уничтоженный блок.
    }
}
