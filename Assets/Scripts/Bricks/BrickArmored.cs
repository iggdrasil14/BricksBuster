using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickArmored : BrickTemplate
{
    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.black;                                                 // Устанавливается цвет блока.
        
        brickHP = 9999;                                                                     // Прочность блока.
        brickScore = 10;                                                                    // Количество очков за уничтоженный блок.
    }
}
