//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class InformationManager : MonoBehaviour
//{
//    public void PlayerSavedInformation()
//    {
//        string _playerName = PlayerPrefs.GetString("playerName");                           // �������� ������ ������ (name) �� ����� MainMenu.

//        GameRules score = FindObjectOfType<GameRules>();                                    // ��������� ������� � ������ ������ (scrore).
//        PlayerPrefs.SetInt("PlayerSavedScore", score._playerScore);                         // ������ ������ ������ (score).

//        GameRules lifes = FindObjectOfType<GameRules>();                                    // ��������� ������� � ������ ������ (lifes).
//        PlayerPrefs.SetInt("PlayerSavedLifes", lifes._playerLifes);                         // ������ ������ ������ (lifes).

//        LevelGenerator level = FindObjectOfType<LevelGenerator>();                          // ��������� ������� � ������ � ������ ������ (level number).
//        PlayerPrefs.SetInt("PlayerSevedLevel", level._levelNumber);                         // ������ ������ � ������ ������ (level number).

//        PlayerPrefs.Save();                                                                 // ���������� ���� ������ ������.
//    }
//}
