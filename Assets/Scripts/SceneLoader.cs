using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    /// <summary>
    /// Начать новую игру (все сохраненные результаты сбрасываются).
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

    public void HallOfFame()
    {

    }

    public void Exit()
    {

    }

}
