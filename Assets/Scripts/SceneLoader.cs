using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneLoader : MonoBehaviour
{
    public GameObject panelOptions;                                                     // Canvas. Панель Options.
    public GameObject panelHallOfFame;                                                  // Canvas. Панель Hall of Fame.
    public GameObject panelPlayerNameInputField;                                        // Canvas. Панель ввода имени игрока.
    public TMP_InputField playerName;
    public string namePlayer;                                                           // Переменная имени игрока, по умолчанию null.
    public bool isNamePlayer = false;                                                   // Флаг, введено ли имя игрока.

    /// <summary>
    /// Начать новую игру (все сохраненные результаты сбрасываются).
    /// </summary>
    public void NewGame()
    {
        PlayerNameInputField();                                                         // Вывод панели ввода имени игрока.
    }

    public void Continue()
    {

    }

    /// <summary>
    /// Панель ввода имени игрока.
    /// </summary>
    public void PlayerNameInputField()                                                  
    {
        panelPlayerNameInputField.SetActive(true);                                      // Активация панели ввода имени игрока.
    }

    public void InputPlayerName(string name)                                            // Ввод имени игрока.
    {
        string player = playerName.text;

        //if (player == null) return; //---
        if (string.IsNullOrEmpty(player)) return;//+++

        namePlayer = name;                                                              // Запись введеного значения имени игрока
        isNamePlayer = true;                                                            // Флаг, введено ли имя игрока.
        SceneManager.LoadScene(1);                                                      // Загрузка игровой сцены.
    }

    /// <summary>
    /// Вывод панели Options на экран.
    /// </summary>
    public void Options()
    {
        panelOptions.SetActive(true);
    }

    /// <summary>
    /// Закрыть меню Options. Сохранить все изменения параметров.
    /// </summary>
    public void OptionsOk()
    {
        panelOptions.SetActive(false);
        //+ сохранение вновь установленных параметров.
    }

    /// <summary>
    /// Установка параметров по умолчанию.
    /// </summary>
    public void OptionsDefault()
    {
        
    }

    /// <summary>
    /// Закрыть меню Options. Не сохранять все изменения параметров.
    /// </summary>
    public void OptionsCancel()
    {
        panelOptions.SetActive(false);
    }

    /// <summary>
    /// Загрузить сцену с Залом Славы.
    /// </summary>
    public void HallOfFame()
    {
        panelHallOfFame.SetActive(true);
    }

    /// <summary>
    /// Кнопка Ok из панели Hall of Fame которая скрывает панель.
    /// </summary>
    public void HallOfFameOk()
    {
        panelHallOfFame.SetActive(false);
    }

    public void LoadScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }

    /// <summary>
    /// Выйти из игры.
    /// </summary>
    public void Exit()
    {
        Application.Quit();
    }
}
