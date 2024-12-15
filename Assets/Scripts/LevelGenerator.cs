using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textLevelNumber;                                               // Переменная с полем текст отвечающее за номер уровня.
    public Vector2Int size;
    public Vector2 offset;
    public GameObject brickPrefab;
    public Gradient gradient;                                                           // Градиент.
    public int brickTotalValue;                                                         // Максимальное количество кирпичей на уровне.
    public int _levelNumber;                                                            // Номер уровня.

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
        brickTotalValue = size.x * size.y;                                              // Максимальное количество кирпичей на уровне.
        _levelNumber++;
        textLevelNumber.text = "Level: " + _levelNumber.ToString();                                 // Трансформация int в string, запись номера уровня в поле с текстом.
    }
}
