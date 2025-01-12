using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_4_pizza : LevelGenerator
{
    private void Awake()
    {
        StartLevel();
    }

    /// <summary>
    /// Метод перезагрузки уровня при нажатии Play Again или Restart.
    /// </summary>
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);               // Менеджер сцен загружает текущую сцену.
    }

    /// <summary>
    /// 
    /// </summary>
    public override void StartLevel()
    {
        brickTotalValue = 153;                                                          // Максимальное количество блоков на уровне.
        _levelNumber = 4;                                                               // Номер текущего уровня.

        PlayerPrefs.SetInt("PlayerLevelNumber", _levelNumber);                          // Запись данных о текущем уровне Игрока.
        PlayerPrefs.Save();                                                             // Сохранение данных о текущем уровне Игрока.

        textLevelNumber.text = "Level: " + _levelNumber.ToString();                     // Трансформация int в string, запись номера уровня в поле с текстом.

        //Time.timeScale = 1;                                                           // Время восстанавливает стандартную скорость - 1.
        //MovingBall movingBall = FindObjectOfType<MovingBall>();                       // Перевод шара в неактивное положение (иначе при загрузке нового цровня/сцены шар не активировался, а время было равно 0)
        //movingBall.isActive = false;
    }
}
