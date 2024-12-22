using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public static string PlayerName { get; private set; }

    public GameObject panelSelectSaveSlot;                                              // Canvas. Панель Select Save Slot.
    public GameObject panelOptions;                                                     // Canvas. Панель Options.
    public GameObject panelHallOfFame;                                                  // Canvas. Панель Hall of Fame.
    public GameObject panelPlayerNameInputField;                                        // Canvas. Панель ввода имени игрока.
    public Button ButtonSlotOne;                                                        // Canvas. Кнопка (по умолчанию пуста и используется для записи имени Игрока).
    public Button ButtonDelSlotOne;                                                     // Canvas. Кнопка удаления ячейкис сохранения прогресса (активна если есть прогресс).
    public TMP_InputField playerName;
    public string namePlayer;                                                           // Переменная имени игрока, по умолчанию null.
    public bool isNamePlayer = false;                                                   // Флаг, введено ли имя игрока.

    /// <summary>
    /// Начать новую игру (все сохраненные результаты сбрасываются).
    /// </summary>
    public void NewGame()
    {
        SelectSaveSlot();                                                                 // Вывод панели слотов сохранения.
        //PlayerNameInputField();                                                         // Вывод панели ввода имени игрока.
    }

    /// <summary>
    /// Метод вывода панели со слотами сохранения.
    /// </summary>
    public void SelectSaveSlot()
    {
        panelSelectSaveSlot.SetActive(true);
    }

    /// <summary>
    /// Метод выбора первого слота сохранения с последующим выводом панели ввода имени.
    /// </summary>
    public void SelectSaveSlotButtonSlotOne()
    {
        PlayerNameInputField();
    }

    /// <summary>
    /// Панель ввода имени игрока.
    /// </summary>
    public void PlayerNameInputField()
    {
        panelPlayerNameInputField.SetActive(true);                                      // Активация панели ввода имени игрока.
    }

    /// <summary>
    /// Кнопка на панели ввода имени игрока - отменяет ввод, скрывает панель.
    /// </summary>
    public void PlayerNameInputFieldCancel()
    {
        panelPlayerNameInputField.SetActive(false);                                     
    }


    // Использовать PlayerPrefs тут.

    /// <summary>
    /// Метод ввода имени игрока в поле ввода, с проверкой на "пустоту" заполнения поля.
    /// </summary>
    /// <param name="name"></param>
    public void InputPlayerName(string name)                                            // Ввод имени игрока. 
    {
        string player = playerName.text;
        if (string.IsNullOrEmpty(player))                                               // Проверка на заполненность поля,
        {
            return;                                                                     // если поле не заполнено, то ничего не происходит.
        }
        namePlayer = name;                                                              // Запись введеного значения имени игрока
        PlayerName = name;                                                              // 

        isNamePlayer = true;                                                            // Флаг, введено ли имя игрока.
        if(isNamePlayer == true)                                                        // если имя Игрока введено,
        {
            ButtonDelSlotOne.gameObject.SetActive(true);                                // то кнопка ButtonDelSlotOne активна.
        }

        PlayerPrefs.SetString("SlotOnePlayerName", name);                               // Добавление в хранилище "SlotOnePlayerName" имени игрока.
        PlayerPrefs.Save();                                                             // Сохранение имени Игрока.
        //ButtonSlotOne. = PlayerPrefs.GetString("SlotOnePlayerName");                               // Запись имени Игрока в название кнопки.

        SceneManager.LoadScene(1);                                                      // Загрузка игровой сцены.
    }

    /// <summary>
    /// Метод сокрытия панели со слотами сохранения, выход в основное меню.
    /// </summary>
    public void SelectSaveSlotBack()
    {
        panelSelectSaveSlot.SetActive(false);
    }

    public void Continue()
    {

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
