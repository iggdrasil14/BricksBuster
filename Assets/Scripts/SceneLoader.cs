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

    /// <summary>
    /// Загрузить сцену с Залом Славы.
    /// </summary>
    public void HallOfFame()
    {
        SceneManager.LoadScene(2);
    }

    /// <summary>
    /// Кнопка Back из сцены Hall of Fame которая активирует возврат в MainMenu.
    /// </summary>
    public void HallOfFameBack()
    {
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// Выйти из игры.
    /// </summary>
    public void Exit()
    {
        Application.Quit();
    }

}
