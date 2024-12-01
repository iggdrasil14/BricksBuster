using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameRules : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textScore;                                                     // Переменная с полем текст отвечающее за количество очков.
    [SerializeField] TextMeshProUGUI textLifes;                                                     // Переменная с полем текст отвечающее за количество жизней.
    private GameObject _platform;                                                                   // Скрытая переменная платформы (для уничтожения).
    private GameObject _ball;                                                                       // Скрытая переменная щара (для уничтожения).
    public GameObject platformPrefab;                                                               // Игровой объект со ссылкой на префаб платформы.
    public GameObject ballPrefab;                                                                   // Игровой объект со ссылкой на префаб шар.
    public int _playerScore;                                                                        // Количество очков у игрока.
    public int _playerLifes;                                                                        // Количество жизней у игрока.

    void Start()
    {
        _playerScore = 0;                                                                           // Начальное количество очков равно 0.
        _playerLifes = 3;                                                                           // Начальное количество жизней равно 3.
        textScore.text = _playerScore.ToString();                                                   // Трансформация int в string, запись очков в поле с текстом.
        textLifes.text = _playerLifes.ToString();                                                   // Трансформация int в string, запись жизней в поле с текстом.
        OnPosition();                                                                               // Установка платформы и шара в заданных координатах.
    }

    private void Update()
    {
        textScore.text = _playerScore.ToString();                                                   // Трансформация int в string, запись очков в поле с текстом.
    }

    /// <summary>
    /// Метод выполняется при падении шара, происходит уменьшение жизгней игрока, 
    /// проверка на конец игры, уничтожение платформы и шара, продолжение игры 
    /// с начальной позиции.
    /// </summary>
    public void Dead()
    {
        PlayerLifes();                                                                              // Запуск метода. Проверка на изменение количества жизней игрока.                                                                             
        Destroy(_platform);                                                                         // Уничтожение платформы.
        Destroy(_ball);                                                                             // Уничтожение шара.
        MovingBall.isFall = false;                                                                  // Флаг isFall переводится в положение false.
        OnPosition();                                                                               // Установка платформы и шара на исходную позицию.
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
        if (MovingBall.isFall == true)                                                              // Если шар падает, 
        {
            _playerLifes--;                                                                         // то игрок теряет 1 жизнь.
            textLifes.text = _playerLifes.ToString();                                               // Отобразить количество жизней игрока.
            GameOver();                                                                             // Проверка на окончание игры.
        }
    }

    /// <summary>
    /// Метод проверки окончания игры при потере всех жизней или при уничтожении всех блоков.
    /// </summary>
    public void GameOver()
    {
        if (_playerLifes <= 0)                                                                      // Если жизней игрока меньше 0,
        {
            Debug.Log("Game Over");                                                                 // то игра заканчивается поражением.
        }

        if (_playerLifes > 0)                                                                       // Если жизней игрока больше 0,
        {
            Debug.Log("Количество жизней -1.");                                                                 // то 
        }

        //if(количество блоков < 0)
        //{

        //}
    }

    /// <summary>
    /// Методы выводит платформу и шар на заданную позицию, 
    /// назначает платформу родительским объектом для шара.
    /// </summary>
    public void OnPosition()
    {
        _platform = Instantiate(platformPrefab, new Vector2(0, -8), Quaternion.identity);           // Создание объекта платформа, инициализация на сцене в начальных координатах.
        _ball = Instantiate(ballPrefab, new Vector2(0,-8), Quaternion.identity);                    // Создание объекта шар, инициализация на сцене в начальных координатах.
        _ball.transform.SetParent(_platform.transform);                                             // Назначение платформы родительским объектом для шара.
    }
}
