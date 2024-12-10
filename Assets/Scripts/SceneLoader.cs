using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public GameObject panelOptions;                                                     // Canvas. ������ Options.
    public GameObject panelPlayerNameInputField;                                        // Canvas. ������ ����� ����� ������.
    public string namePlayer;                                                           // ���������� ����� ������, �� ��������� null.
    public bool isNamePlayer = false;                                                   // ����, ������� �� ��� ������.

    /// <summary>
    /// ������ ����� ���� (��� ����������� ���������� ������������).
    /// </summary>
    public void NewGame()
    {
        PlayerNameInputField();                                                         // ����� ������ ����� ����� ������.
    }

    public void Continue()
    {

    }

    /// <summary>
    /// ������ ����� ����� ������.
    /// </summary>
    public void PlayerNameInputField()                                                  
    {
        panelPlayerNameInputField.SetActive(true);                                      // ��������� ������ ����� ����� ������.
    }

    public void InputPlayerName(string name)                                            // ���� ����� ������.
    {
        namePlayer = name;                                                              // ������ ��������� �������� ����� ������
        isNamePlayer = true;                                                            // ����, ������� �� ��� ������.
        SceneManager.LoadScene(1);                                                      // �������� ������� �����.
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
        SceneManager.LoadScene(2);
    }

    /// <summary>
    /// ������ Back �� ����� Hall of Fame ������� ���������� ������� � MainMenu.
    /// </summary>
    public void HallOfFameBack()
    {
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// ����� �� ����.
    /// </summary>
    public void Exit()
    {
        Application.Quit();
    }
}
