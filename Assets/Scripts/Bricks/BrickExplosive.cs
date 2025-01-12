using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickExplosive : BrickTemplate
{
    void Start()
    {
        brickHP = 1;                                                                        // Прочность блока.
        brickScore = 5;                                                                     // Количество очков за уничтоженный блок.
    }
    public override void Crash(bool isForceDestroy = false)
    {
        base.Crash();
        if (brickHP <= 0) 
        {
            RaycastHit2D[] bricks = Physics2D.CircleCastAll(transform.position, 1.2f, Vector2.one);
            if (bricks != null) 
            {
                for (int i = 0; i < bricks.Length; i++) 
                {
                    if (bricks[i].transform.gameObject.TryGetComponent<BrickTemplate>(out BrickTemplate brick))
                    {
                        brick.Crash(true);
                    }
                }
            }
        }
    }
}
