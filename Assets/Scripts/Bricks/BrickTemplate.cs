using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickTemplate : MonoBehaviour
{
    public GameObject brickPrefab;                                                      // Поле с префабом блока.
    public List<Sprite> brickSprites;                                                   // Список спрайтов блока (целый, поврежденный, почти разрушенный).
    public Color brickColor;                                                            // Цвет блока.
    public int brickScore;                                                              // Переменная - количество очков за уничтоженный блок.
    public int brickHP;                                                                 // Переменная - количество жизней у блока.
    public AudioClip audio;

    public virtual void Crash(bool isForceDestroy = false) 
    {
        if(isForceDestroy == true)
        {
            Destroy(gameObject);                                                        // блок уничтожается,

            LevelGenerator levelGenerator = FindObjectOfType<LevelGenerator>();         // Обращение к скрипту
            levelGenerator.brickTotalValue--;                                           // Уменьшение общего количества блоков.

            GameRules gameRules = FindObjectOfType<GameRules>();                        // Обращение к скрипту.
            gameRules.GameOver();                                                       // Проверка на выполнение условий победы при уничтожении блока.

            gameRules._playerScore = gameRules._playerScore + brickScore;               // Увеличение счета Игрока.
            return;
        }
        brickHP--;                                                                      // количество жизней блока уменьшается на 1.
        if (brickHP <= 0)                                                               // Если количество жизней будет равно 0 или ниже, то
        {
            Destroy(gameObject);                                                        // блок уничтожается,

            LevelGenerator levelGenerator = FindObjectOfType<LevelGenerator>();         // Обращение к скрипту
            levelGenerator.brickTotalValue--;                                           // Уменьшение общего количества блоков.

            GameRules gameRules = FindObjectOfType<GameRules>();                        // Обращение к скрипту.
            gameRules.GameOver();                                                       // Проверка на выполнение условий победы при уничтожении блока.

            gameRules._playerScore = gameRules._playerScore + brickScore;               // Увеличение счета Игрока.
        }
    } 
}
