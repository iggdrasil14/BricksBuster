using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public static string PlayerName { get; private set; }

    public GameObject panelSelectSaveSlot;                                              // Canvas. ������ Select Save Slot.
    public GameObject panelOptions;                                                     // Canvas. ������ Options.
    public GameObject panelHallOfFame;                                                  // Canvas. ������ Hall of Fame.
    public GameObject panelPlayerNameInputField;                                        // Canvas. ������ ����� ����� ������.
    public Button ButtonSlotOne;                                                        // Canvas. ������ (�� ��������� ����� � ������������ ��� ������ ����� ������).
    public Button ButtonDelSlotOne;                                                     // Canvas. ������ �������� ������� ���������� ��������� (������� ���� ���� ��������).
    public TMP_InputField playerName;
    public string namePlayer;                                                           // ���������� ����� ������, �� ��������� null.
    public bool isNamePlayer = false;                                                   // ����, ������� �� ��� ������.

    /// <summary>
    /// ������ ����� ���� (��� ����������� ���������� ������������).
    /// </summary>
    public void NewGame()
    {
        SelectSaveSlot();                                                                 // ����� ������ ������ ����������.
        //PlayerNameInputField();                                                         // ����� ������ ����� ����� ������.
    }

    /// <summary>
    /// ����� ������ ������ �� ������� ����������.
    /// </summary>
    public void SelectSaveSlot()
    {
        panelSelectSaveSlot.SetActive(true);
    }

    /// <summary>
    /// ����� ������ ������� ����� ���������� � ����������� ������� ������ ����� �����.
    /// </summary>
    public void SelectSaveSlotButtonSlotOne()
    {
        PlayerNameInputField();
    }

    /// <summary>
    /// ������ ����� ����� ������.
    /// </summary>
    public void PlayerNameInputField()
    {
        panelPlayerNameInputField.SetActive(true);                                      // ��������� ������ ����� ����� ������.
    }

    /// <summary>
    /// ������ �� ������ ����� ����� ������ - �������� ����, �������� ������.
    /// </summary>
    public void PlayerNameInputFieldCancel()
    {
        panelPlayerNameInputField.SetActive(false);                                     
    }


    // ������������ PlayerPrefs ���.

    /// <summary>
    /// ����� ����� ����� ������ � ���� �����, � ��������� �� "�������" ���������� ����.
    /// </summary>
    /// <param name="name"></param>
    public void InputPlayerName(string name)                                            // ���� ����� ������. 
    {
        string player = playerName.text;
        if (string.IsNullOrEmpty(player))                                               // �������� �� ������������� ����,
        {
            return;                                                                     // ���� ���� �� ���������, �� ������ �� ����������.
        }
        namePlayer = name;                                                              // ������ ��������� �������� ����� ������
        PlayerName = name;                                                              // 

        isNamePlayer = true;                                                            // ����, ������� �� ��� ������.
        if(isNamePlayer == true)                                                        // ���� ��� ������ �������,
        {
            ButtonDelSlotOne.gameObject.SetActive(true);                                // �� ������ ButtonDelSlotOne �������.
        }

        PlayerPrefs.SetString("SlotOnePlayerName", name);                               // ���������� � ��������� "SlotOnePlayerName" ����� ������.
        PlayerPrefs.Save();                                                             // ���������� ����� ������.
        //ButtonSlotOne. = PlayerPrefs.GetString("SlotOnePlayerName");                               // ������ ����� ������ � �������� ������.

        SceneManager.LoadScene(1);                                                      // �������� ������� �����.
    }

    /// <summary>
    /// ����� �������� ������ �� ������� ����������, ����� � �������� ����.
    /// </summary>
    public void SelectSaveSlotBack()
    {
        panelSelectSaveSlot.SetActive(false);
    }

    public void Continue()
    {

    }


    /// <summary>
    /// ����� ������ Options �� �����.
    /// </summary>
    public void Options()
    {
        panelOptions.SetActive(true);
    }

    /// <summary>
    /// ������� ���� Options. ��������� ��� ��������� ����������.
    /// </summary>
    public void OptionsOk()
    {
        panelOptions.SetActive(false);
        //+ ���������� ����� ������������� ����������.
    }

    /// <summary>
    /// ��������� ���������� �� ���������.
    /// </summary>
    public void OptionsDefault()
    {
        
    }

    /// <summary>
    /// ������� ���� Options. �� ��������� ��� ��������� ����������.
    /// </summary>
    public void OptionsCancel()
    {
        panelOptions.SetActive(false);
    }

    /// <summary>
    /// ��������� ����� � ����� �����.
    /// </summary>
    public void HallOfFame()
    {
        panelHallOfFame.SetActive(true);
    }

    /// <summary>
    /// ������ Ok �� ������ Hall of Fame ������� �������� ������.
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
    /// ����� �� ����.
    /// </summary>
    public void Exit()
    {
        Application.Quit();
    }
}
