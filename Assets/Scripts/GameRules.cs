using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Runtime.CompilerServices;
using UnityEngine.SceneManagement;

public class GameRules : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textName;                                                     // Переменная с полем текст отвечающее за количество очков.
    [SerializeField] TextMeshProUGUI textScore;                                                     // Переменная с полем текст отвечающее за количество очков.
    [SerializeField] TextMeshProUGUI textLifes;                                                     // Переменная с полем текст отвечающее за количество жизней.
    [SerializeField] TextMeshProUGUI textTotalScore;                                                // Переменная с полем текст отвечающее за количество очков.
    [SerializeField] TextMeshProUGUI textPanelYouWinScore;                                          // Вывод на панеле YouWin информации об очках.
    [SerializeField] TextMeshProUGUI textPanelYouWinLifes;                                          // Вывод на панеле YouWin информации о жизнях
    private GameObject _platform;                                                                   // Скрытая переменная платформы (для уничтожения).
    private GameObject _ball;                                                                       // Скрытая переменная щара (для уничтожения).
    public GameObject platformPrefab;                                                               // Игровой объект со ссылкой на префаб платформы.
    public GameObject ballPrefab;                                                                   // Игровой объект со ссылкой на префаб шар.
    public GameObject panelYouWin;                                                                  // Canvas. Панель вызываемая при победе.
    public GameObject panelMenu;                                                                    // Canvas. Панель вызываемая при нажатии клавиши Esc.
    public GameObject panelGameOver;                                                                // Canvas. Панель вызываемая при поражении.
    public string _playerName;
    public int _playerScore;                                                                        // Количество очков у игрока.
    public int _playerLifes;                                                                        // Количество жизней у игрока.
    public int _totalScore;                                                                         // Итоговое количество очков.
    public bool _isPaused = false;                                                                  // Переменная состояния при паузе.

    void Start()
    {
        PlayerDataLoad();                                                                           // Метод загрузки данных(имя, количество очков и жизней, номер уровня) об игроке.

        textName.text = _playerName;
        Debug.Log(_playerName);
        textScore.text = _playerScore.ToString();                                                   // Трансформация int в string, запись очков в поле с текстом.
        textLifes.text = _playerLifes.ToString();                                                   // Трансформация int в string, запись жизней в поле с текстом.

        OnPosition();                                                                               // Установка платформы и шара в заданных координатах.
    }

    /// <summary>
    /// Метод загрузки данных (имя, количество очков и жизней, номер уровня) об игроке.
    /// </summary>
    private void PlayerDataLoad()
    {
        // Имя Игрока.
        if (PlayerPrefs.HasKey("SlotOnePlayerName") == true)                                        // Если, SlotOnePlayerName содержит данные,
        {
            string _playerName = PlayerPrefs.GetString("SlotOnePlayerName");                        // то в имя Игрока записывается значение указанное при вводе.
        }

        // Количество очков Игрока.
        if (PlayerPrefs.HasKey("PlayerScore") == true)                                              // Если, PlayerScore содержит данные,
        {
            int _playerScore = PlayerPrefs.GetInt("PlayerScore");                                   // то загружаются данные о количестве очков из прошлой игры.
        }
        else                                                                                        // иначе,
        {
            _playerScore = 0;                                                                       // начальное количество очков Игрока равно 0.
        }

        // Количество жизней игрока.
        if (PlayerPrefs.HasKey("PlayerLifes") == true)                                              // Если, PlayerLifes содержит данные,
        {
            int _playerLifes = PlayerPrefs.GetInt("PlayerLifes");                                   // то загружаются данные о количестве жизней из прошлой игры.
        }
        else                                                                                        // иначе,
        {
            _playerLifes = 3;                                                                       // начальное количество жизней Игрока равно 3.
        }

        // Текущий уровень Игрока.
        if (PlayerPrefs.HasKey("PlayerLevelNumber") == true)                                        // Если, PlayerLevelNumber содержит данные,
        {
            int _levelNumber = PlayerPrefs.GetInt("PlayerSevedLevel");                              // то загружаются данные о последнем уровне из прошлой игры.
        }
    }

    private void Update()
    {
        textPanelYouWinScore.text = _playerScore.ToString();
        textPanelYouWinLifes.text = _playerLifes.ToString();

        textScore.text = "Score: " + _playerScore.ToString();                                       // Трансформация int в string, запись очков в поле с текстом.
        textLifes.text = "Lifes: " + _playerLifes.ToString();                                       // Трансформация int в string, запись жизней в поле с текстом.
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

            PlayerLifesSave();                                                                      // Метод сохранение текущего значения жизней Игрока.

            GameOver();                                                                             // Проверка на окончание игры.
        }
    }

    /// <summary>
    /// Метод сохранение текущего значения жизней Игрока.
    /// </summary>
    private void PlayerLifesSave()
    {
        PlayerPrefs.GetInt("PlayerLifes", _playerLifes);                                        // Запись данных о количестве жизней Игрока.
        PlayerPrefs.Save();                                                                     // Сохранение данных о количестве жизней Игрока.
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

            PlayerScoreSave();                                                                      // Запись данных и сохранение информации о количестве набранных Игроком очков.

            Time.timeScale = 0;                                                                     // Остановка внутриигрового времени, чтобы ничто не сцене не двигалось.
            Destroy(_platform);                                                                     // Уничтожение платформы.
            Destroy(_ball);                                                                         // Уничтожение шара.
        }

        // При поражении.
        if (_playerLifes <= 0)                                                                      // Если жизней игрока меньше 0,
        {
            panelGameOver.SetActive(true);                                                          // Canvas. Панель вызываемая при поражении.
            textTotalScore.text = $"Your score: " + _playerScore.ToString();                        // Canvas. Вывод на панель итогового счета.

            PlayerScoreSave();                                                                      // Запись данных и сохранение информации о количестве набранных Игроком очков.

            Time.timeScale = 0;                                                                     // Остановка внутриигрового времени, чтобы ничто не сцене не двигалось.
            Destroy(_platform);                                                                     // Уничтожение платформы.
            Destroy(_ball);                                                                         // Уничтожение шара.
        }
    }

    /// <summary>
    /// Запись данных и сохранение информации о количестве набранных Игроком очков.
    /// </summary>
    private void PlayerScoreSave()
    {
        PlayerPrefs.GetInt("PlayerScore", _playerScore);                                        // Запись данных о количестве очков Игрока.
        PlayerPrefs.Save();                                                                     // Сохранение данных о количестве очков Игрока.
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
    /// Кнопка игрового меню (Main menu), выводит в основное меню.
    /// </summary>
    public void MenuBackToMaidMenu()
    {
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// Метод продолжения игры (снятия с паузы), выход из игрового меню.
    /// </summary>
    public void Continue()
    {
        panelMenu.SetActive(false);                                                                 // Деактивация игрового меню.
        panelYouWin.SetActive(false);                                                               // Деактивация панели YouWin.
        Time.timeScale = 1;                                                                         // Время до 1.
        _isPaused = false;
        //SceneManager.LoadScene(1);
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
