using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    /// <summary>
    /// ������ ����� ���� (��� ����������� ���������� ������������).
    /// </summary>
    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Continue()
    {

    }

    public void Options()
    {

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
