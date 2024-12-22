//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class InformationManager : MonoBehaviour
//{
//    public void PlayerSavedInformation()
//    {
//        string _playerName = PlayerPrefs.GetString("playerName");                           // Загрузка данных Игрока (name) из сцены MainMenu.

//        GameRules score = FindObjectOfType<GameRules>();                                    // Получение доступа к данным Игрока (scrore).
//        PlayerPrefs.SetInt("PlayerSavedScore", score._playerScore);                         // Запись данных Игрока (score).

//        GameRules lifes = FindObjectOfType<GameRules>();                                    // Получение доступа к данным Игрока (lifes).
//        PlayerPrefs.SetInt("PlayerSavedLifes", lifes._playerLifes);                         // Запись данных Игрока (lifes).

//        LevelGenerator level = FindObjectOfType<LevelGenerator>();                          // Получения доступа к данным о номере уровня (level number).
//        PlayerPrefs.SetInt("PlayerSevedLevel", level._levelNumber);                         // Запись данных о номере уровня (level number).

//        PlayerPrefs.Save();                                                                 // Сохранение всех данных Игрока.
//    }
//}
