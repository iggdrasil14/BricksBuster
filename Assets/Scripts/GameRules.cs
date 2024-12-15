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
    [SerializeField] TextMeshProUGUI textScore;                                                     // ���������� � ����� ����� ���������� �� ���������� �����.
    [SerializeField] TextMeshProUGUI textLifes;                                                     // ���������� � ����� ����� ���������� �� ���������� ������.
    [SerializeField] TextMeshProUGUI textTotalScore;                                                // ���������� � ����� ����� ���������� �� ���������� �����.
    [SerializeField] TextMeshProUGUI textPanelYouWinScore;                                          // ����� �� ������ YouWin ���������� �� �����.
    [SerializeField] TextMeshProUGUI textPanelYouWinLifes;                                          // ����� �� ������ YouWin ���������� � ������
    private GameObject _platform;                                                                   // ������� ���������� ��������� (��� �����������).
    private GameObject _ball;                                                                       // ������� ���������� ���� (��� �����������).
    public GameObject platformPrefab;                                                               // ������� ������ �� ������� �� ������ ���������.
    public GameObject ballPrefab;                                                                   // ������� ������ �� ������� �� ������ ���.
    public GameObject panelYouWin;                                                                  // Canvas. ������ ���������� ��� ������.
    public GameObject panelMenu;                                                                    // Canvas. ������ ���������� ��� ������� ������� Esc.
    public GameObject panelGameOver;                                                                // Canvas. ������ ���������� ��� ���������.
    public int _playerScore;                                                                        // ���������� ����� � ������.
    public int _playerLifes;                                                                        // ���������� ������ � ������.
    public int _totalScore;                                                                         // �������� ���������� �����.
    public bool _isPaused = false;                                                                  // ���������� ��������� ��� �����.

    void Start()
    {
        //PlayerPrefs.SetInt("score", 100);
        //int score = PlayerPrefs.GetInt("score");

        _playerScore = 0;                                                                           // ��������� ���������� ����� ����� 0.
        _playerLifes = 3;                                                                           // ��������� ���������� ������ ����� 3.

        textScore.text = _playerScore.ToString();                                                   // ������������� int � string, ������ ����� � ���� � �������.
        textLifes.text = _playerLifes.ToString();                                                   // ������������� int � string, ������ ������ � ���� � �������.

        OnPosition();                                                                               // ��������� ��������� � ���� � �������� �����������.
    }

    private void Update()
    {
        textPanelYouWinScore.text = _playerScore.ToString();
        textPanelYouWinLifes.text = _playerLifes.ToString();

        textScore.text = "Score: " + _playerScore.ToString();                                       // ������������� int � string, ������ ����� � ���� � �������.
        textLifes.text = "Lifes: " + _playerLifes.ToString();                                       // ������������� int � string, ������ ������ � ���� � �������.
        Cheat();                                                                                    // ���-��� ��������� �������� ����.
        Menu();                                                                                     // ��������� �������� ����.
    }

    /// <summary>
    /// ����� ����������� ��� ������� ����, ���������� ���������� ������� ������, 
    /// �������� �� ����� ����, ����������� ��������� � ����, ����������� ���� 
    /// � ��������� �������.
    /// </summary>
    public void Dead()
    {
        PlayerLifes();                                                                              // ������ ������. �������� �� ��������� ���������� ������ ������.                                                                             
        Destroy(_platform);                                                                         // ����������� ���������.
        Destroy(_ball);                                                                             // ����������� ����.
        MovingBall.isFall = false;                                                                  // ���� isFall ����������� � ��������� false.
        OnPosition();                                                                               // ��������� ��������� � ���� �� �������� �������.
    }

    /// <summary>
    /// ����� ����������/���������� ���������� ������ � ������.
    /// </summary>
    public void PlayerLifes()
    {
        // ������� ���������� ���������� ������.
        if (MovingBall.isFall == true)                                                              // ���� ��� ������, 
        {
            _playerLifes--;                                                                         // �� ����� ������ 1 �����.
            textLifes.text = _playerLifes.ToString();                                               // ���������� ���������� ������ ������.
            GameOver();                                                                             // �������� �� ��������� ����.
        }
    }

    /// <summary>
    /// ����� �������� ��������� ���� ��� ������ ���� ������ ��� ��� ����������� ���� ������.
    /// </summary>
    public void GameOver()
    {
        // ��� ������.
        LevelGenerator levelGenerator = FindObjectOfType<LevelGenerator>();                         // ��������� ������� � �������.
        if (levelGenerator.brickTotalValue <= 0)                                                    // ���� ���������� ������ ����� 0 ��� ������,
        {
            panelYouWin.SetActive(true);                                                            // Canvas. ������ ���������� ��� ������.
            textTotalScore.text = $"Your score: " + _playerScore.ToString();                        // Canvas. ����� �� ������ ��������� �����.
            Time.timeScale = 0;                                                                     // ��������� �������������� �������, ����� ����� �� ����� �� ���������.
            Destroy(_platform);                                                                     // ����������� ���������.
            Destroy(_ball);                                                                         // ����������� ����.
        }

        // ��� ���������.
        if (_playerLifes <= 0)                                                                      // ���� ������ ������ ������ 0,
        {
            panelGameOver.SetActive(true);                                                          // Canvas. ������ ���������� ��� ���������.
            textTotalScore.text = $"Your score: " + _playerScore.ToString();                        // Canvas. ����� �� ������ ��������� �����.
            Time.timeScale = 0;                                                                     // ��������� �������������� �������, ����� ����� �� ����� �� ���������.
            Destroy(_platform);                                                                     // ����������� ���������.
            Destroy(_ball);                                                                         // ����������� ����.
        }
    }

    /// <summary>
    /// ����� ������������ ������� ���� (������� �����).
    /// </summary>
    public void Menu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))                                                       // ��� ������� ������� Esc ���������� ������� ����.
        {
            if (_isPaused == false)                                                                 // ���� 
            {
                panelMenu.SetActive(true);                                                          // ��������� �������� ����.
                Time.timeScale = 0;                                                                 // ����� ����������� �� 0.
                _isPaused = true;
            }
            else
            {
                panelMenu.SetActive(false);                                                         // ����������� �������� ����.
                Time.timeScale = 1;                                                                 // ����� ����������� �� 1.
                _isPaused = false;
            }
        }
    }

    /// <summary>
    /// ������ �������� ���� (Main menu), ������� � �������� ����.
    /// </summary>
    public void MenuBackToMaidMenu()
    {
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// ����� ����������� ���� (������ � �����), ����� �� �������� ����.
    /// </summary>
    public void Continue()
    {
        panelMenu.SetActive(false);                                                                 // ����������� �������� ����.
        panelYouWin.SetActive(false);                                                               // ����������� ������ YouWin.
        Time.timeScale = 1;                                                                         // ����� �� 1.
        _isPaused = false;
        //SceneManager.LoadScene(1);
    }

    /// <summary>
    /// ����� ������ �� ����������.
    /// </summary>
    public void ExitGame()
    {
        Application.Quit();
    }

    /// <summary>
    /// ������ ������� ��������� � ��� �� �������� �������, 
    /// ��������� ��������� ������������ �������� ��� ����.
    /// </summary>
    public void OnPosition()
    {
        _platform = Instantiate(platformPrefab, new Vector2(0, -8), Quaternion.identity);           // �������� ������� ���������, ������������� �� ����� � ��������� �����������.
        _ball = Instantiate(ballPrefab, new Vector2(0,-8), Quaternion.identity);                    // �������� ������� ���, ������������� �� ����� � ��������� �����������.
        _ball.transform.SetParent(_platform.transform);                                             // ���������� ��������� ������������ �������� ��� ����.
    }

    /// <summary>
    /// ����� ���-����, �������� � ��������� ������� ������� ��� ������� ������.
    /// </summary>
    public void Cheat()
    {
        if (Input.GetKeyDown(KeyCode.PageUp))                                                       // ��������� �������� ����.
        {
            Time.timeScale++;
        }

        if (Input.GetKeyDown(KeyCode.PageDown))                                                     // ���������� �������� ����.
        {
            if(Time.timeScale > 0)                                                                  // �������� �������� �������� timeScale, ���� ������ 0,
            {
                Time.timeScale--;                                                                   // �� ����� ��������� �������� �� 1.
            }
            if (Time.timeScale < 0)                                                                 // �������� �������� �������� timeScale� ���� ������ 0,
            {
                Time.timeScale = 0;                                                                 // �� ������ ��������� ��������, ��� ����� 0.
            }
        }
    }
}
