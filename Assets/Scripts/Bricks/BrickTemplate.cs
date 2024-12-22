using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickTemplate : MonoBehaviour
{
    public GameObject brickPrefab;                                          // Поле с префабом блока.
    public List<Sprite> brickSprites;                                       // Список спрайтов блока (целый, поврежденный, почти разрушенный).
    public Color brickColor;                                                // Цвет блока.
    public int brickScore;                                                  // Переменная - количество очков за уничтоженный блок.
    public int brickHP;                                                     // Переменная - количество жизней у блока.

    void Start()
    {

    }

    void Update()
    {
        
    }
}
