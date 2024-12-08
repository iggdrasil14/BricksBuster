using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public GameObject panelOptions;                                                     // Canvas. Панель вызываемая при победе.
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
