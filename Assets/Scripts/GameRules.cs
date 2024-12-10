using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Runtime.CompilerServices;

public class GameRules : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textScore;                                                     // Переменная с полем текст отвечающее за количество очков.
    [SerializeField] TextMeshProUGUI textLifes;                                                     // Переменная с полем текст отвечающее за количество жизней.
    [SerializeField] TextMeshProUGUI textTotalScore;                                                // Переменная с полем текст отвечающее за количество жизней.
    private GameObject _platform;                                                                   // Скрытая переменная платформы (для уничтожения).
    private GameObject _ball;                                                                       // Скрытая переменная щара (для уничтожения).
    public GameObject platformPrefab;                                                               // Игровой объект со ссылкой на префаб платформы.
    public GameObject ballPrefab;                                                                   // Игровой объект со ссылкой на префаб шар.
    public GameObject panelYouWin;                                                                  // Canvas. Панель вызываемая при победе.
    public GameObject panelMenu;                                                                    // Canvas. Панель вызываемая при нажатии клавиши Esc.
    public GameObject panelGameOver;                                                                // Canvas. Панель вызываемая при поражении.
    public int _playerScore;                                                                        // Количество очков у игрока.
    public int _playerLifes;                                                                        // Количество жизней у игрока.
    public int _totalScore;                                                                         // Итоговое количество очков.
    public bool _isPaused = false;                                                                  // Переменная состояния при паузе.

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
        Cheat();                                                                                    // Чит-код ускорения движения шара.
        Menu();                                                                                     // Активация игрового меню.
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
        // При победе.
        LevelGenerator levelGenerator = FindObjectOfType<LevelGenerator>();                         // Получение доступа к скрипту.
        if (levelGenerator.brickTotalValue <= 0)                                                    // Если колиечство блоков будет 0 или меньше,
        {
            panelYouWin.SetActive(true);                                                            // Canvas. Панель вызываемая при победе.
            textTotalScore.text = $"Your score: " + _playerScore.ToString();                        // Canvas. Вывод на панель итогового счета.
            Time.timeScale = 0;                                                                     // Остановка внутриигрового времени, чтобы ничто не сцене не двигалось.
            Destroy(_platform);                                                                     // Уничтожение платформы.
            Destroy(_ball);                                                                         // Уничтожение шара.
        }

        // При поражении.
        if (_playerLifes <= 0)                                                                      // Если жизней игрока меньше 0,
        {
            panelGameOver.SetActive(true);                                                          // Canvas. Панель вызываемая при поражении.
            textTotalScore.text = $"Your score: " + _playerScore.ToString();                        // Canvas. Вывод на панель итогового счета.
            Time.timeScale = 0;                                                                     // Остановка внутриигрового времени, чтобы ничто не сцене не двигалось.
            Destroy(_platform);                                                                     // Уничтожение платформы.
            Destroy(_ball);                                                                         // Уничтожение шара.
        }
    }

    /// <summary>
    /// Метод активирующий игровое меню (вариант паузы).
    /// </summary>
    public void Menu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))                                                       // При нажатии клавиши Esc вызывается игровое меню.
        {
            if (_isPaused == false)                                                                 // Если 
            {
                panelMenu.SetActive(true);                                                          // Автивация игрового меню.
                Time.timeScale = 0;                                                                 // Время замедляется до 0.
                _isPaused = true;
            }
            else
            {
                panelMenu.SetActive(false);                                                         // Деактивация игрового меню.
                Time.timeScale = 1;                                                                 // Время замедляется до 1.
                _isPaused = false;
            }
        }
    }

    /// <summary>
    /// Метод продолжения игры (снятия с паузы), выход из игрового меню.
    /// </summary>
    public void Continue()
    {
        panelMenu.SetActive(false);                                                                 // Деактивация игрового меню.
        Time.timeScale = 1;                                                                         // Время замедляется до 1.
        _isPaused = false;
    }

    /// <summary>
    /// Метод выхода из приложения.
    /// </summary>
    public void ExitGame()
    {
        Application.Quit();
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

    /// <summary>
    /// Метод чит-кода, ускоряет и замедляет течение времени при нажатии клавиш.
    /// </summary>
    public void Cheat()
    {
        if (Input.GetKeyDown(KeyCode.PageUp))                                                       // Ускорения процесса игры.
        {
            Time.timeScale++;
        }

        if (Input.GetKeyDown(KeyCode.PageDown))                                                     // Замедление процесса игры.
        {
            if(Time.timeScale > 0)                                                                  // Проверка текущего значения timeScale, если больше 0,
            {
                Time.timeScale--;                                                                   // то можно уменьшить значение на 1.
            }
            if (Time.timeScale < 0)                                                                 // Проверка текущего значения timeScaleб если меньше 0,
            {
                Time.timeScale = 0;                                                                 // то нельзя уменьшить значение, оно равно 0.
            }
        }
    }
}
