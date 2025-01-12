using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Old_LevelGenerator : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textLevelNumber;                                   // ���������� � ����� ����� ���������� �� ����� ������.
    public Vector2Int size;
    public Vector2 offset;
    public GameObject brickPrefab;
    public Gradient gradient;                                                           // ��������.
    public int brickTotalValue;                                                         // ������������ ���������� �������� �� ������.
    public int _levelNumber;                                                            // ����� ������.

    private void Awake()
    {
        StartLevel();
    }

    /// <summary>
    /// ����� ������������ ������ ��� ������� Play Again ��� Restart.
    /// </summary>
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);               // �������� ���� ��������� ������� �����.
    }

    /// <summary>
    /// 
    /// </summary>
    public void StartLevel()
    {
        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                GameObject newBrick = Instantiate(brickPrefab, transform);
                newBrick.transform.position = transform.position + new Vector3((float)((size.x - 1) * 0.5f - i) * offset.x, j * offset.y, 0);
                newBrick.GetComponent<SpriteRenderer>().color = gradient.Evaluate((float)j / (size.y - 1));
            }
        }
        brickTotalValue = 151;                                              // ������������ ���������� �������� �� ������.
        _levelNumber++;                                                                 // ���������� ������ ������ �� 1.

        PlayerPrefs.SetInt("PlayerLevelNumber", _levelNumber);                          // ������ ������ � ������� ������ ������.
        PlayerPrefs.Save();                                                             // ���������� ������ � ������� ������ ������.

        textLevelNumber.text = "Level: " + _levelNumber.ToString();                     // ������������� int � string, ������ ������ ������ � ���� � �������.
    }
}
