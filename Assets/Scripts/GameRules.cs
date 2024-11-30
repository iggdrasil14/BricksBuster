using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameRules : MonoBehaviour
{
    public GameObject platformPrefab;
    public GameObject ballPrefab;
    private int _playerLifes;                                                                   // Количество жизней у игрока

    void Start()
    {
        _playerLifes = 3;                                                                       // Начальное количество жизней равно 3.
        Instantiate(platformPrefab, new Vector2(0, -8), Quaternion.identity);                   // Инициализация префаба платформы в начальных координатах.
        Instantiate(ballPrefab, new Vector2(0, -8), Quaternion.identity);                       // Инициализация префаба шара в начальных координатах.                                                                          // Установка платформы и шара в заданных координатах.
    }

    void Update()
    {
        if(MovingBall.isFall == true)
        {
            Debug.Log("Перенос платформы");
            Destroy(GameObject.Find("PlatformPrefab(Clone)"));
            Destroy(GameObject.Find("BallPrefab(Clone)"));
            MovingBall.isFall = false;
            OnPosition();
        }
    }

    /// <summary>
    /// Метод увеличения/уменьшения количества жизней у игрока.
    /// </summary>
    public void PlayerLifes()
    {
        // Условия увеличения количества жизней.
        //if ()
        //{
        //    _playersLife++;
        //}

        // Условие уменьшения количества жизней.
        if (MovingBall.isFall == true)                                                          // Если шар падает, 
        {
            _playerLifes--;                                                                     // то игрок теряет 1 жизнь.
            GameOver();                                                                         // Проверка на окончание игры.
        }
    }

    /// <summary>
    /// Метод проверки окончания игры при потере всех жизней или при уничтожении всех блоков.
    /// </summary>
    public void GameOver()
    {
        if (_playerLifes <= 0)                                                                  // Если жизней игрока меньше 0,
        {
            Debug.Log("Game Over");                                                             // то игра заканчивается поражением.
        }

        //if(количество блоков < 0)
        //{

        //}
    }

    /// <summary>
    /// Методы выводит платформу и шар на заданную позицию.
    /// </summary>
    public void OnPosition()
    {
        Instantiate(platformPrefab, new Vector2(0, -8), Quaternion.identity);                   // Инициализация префаба платформы в начальных координатах.
        Instantiate(ballPrefab, new Vector2(0, -8), Quaternion.identity);                       // Инициализация префаба шара в начальных координатах.
    }
}
