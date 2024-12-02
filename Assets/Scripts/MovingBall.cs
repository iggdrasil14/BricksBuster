using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBall : MonoBehaviour
{
    public Rigidbody2D rb;                                                                      // Переменная, которая ссылается на компонент Rigidbody 2D.
    public bool isActive;                                                                       // Состояние мяча (деактивирован в начале игры, активирован после нажатия ЛКМ).
    public static bool isFall = false;
    public float Force = 500f;                                                                  // Сила с которой мяч начинает двигаться.
    public float OffsetX = 100f;                                                                // Смещение мяча по оси X.
    public float speedBall;
    public int _playersLife;                                                                    // Количество жизней игрока
    private Vector2 _inDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();                                                       // Сохранение в переменной rb ссылку на компонент Rigidbody.
        rb.bodyType = RigidbodyType2D.Kinematic;                                                // Установка режима Kinematic чтобы в начале игры мяч мог двигаться с платформой.
        _playersLife = 3;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isActive)                                           // Активация движения мяча при налатии ЛКМ и выполнении условия что мяч еще не активирован.
        {
            BallActive();                                                                       // Метод активации мяча.
        }
        _inDirection = rb.velocity;
    }

    private void OnDestroy()
    {
        print("Destroyed");
    }

    /// <summary>
    /// Активачия мяча при нажатии ЛКМ, параметры его движение;
    /// </summary>
    public void BallActive()
    {
        isActive = true;                                                                        // Активация мяча.
        transform.SetParent(null);                                                              // Отсутствие родительских объектов, чтобы мяч двигался самостоятельно от платформы.
        rb.bodyType = RigidbodyType2D.Dynamic;                                                  // Перевод объекта в Dinamic (управление объектом физикой).
        rb.AddForce(new Vector2 (Random.Range(-500, 500), Force));                              // Добавление силы влияния и смещения.
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Движение шара.
        speedBall = _inDirection.magnitude;                                                     // Сохранение текущей скорости мяча (величину вектора скорости).
        var direction = Vector2.Reflect(_inDirection.normalized, collision.contacts[0].normal); // Расчет нового направления движения мяча.
        rb.velocity = direction * speedBall;                                                    // Установка новой скорости мяча после отскока.
        
        // Уничтожение объекта.
        if (collision.gameObject.CompareTag("Brick"))                                           // Проверка, содержит ли объект тег Brick.
        {
            Destroy(collision.gameObject);                                                      // Уничтожение объекта содержащего тег Brick.
            GameRules gameRules = FindObjectOfType<GameRules>();                                // Обращение к скрипту GameRules.
            gameRules._playerScore++;                                                           // Увеличение оков у игрока при уничтожении блока.

            LevelGenerator levelGenerator = FindObjectOfType<LevelGenerator>();                 // Подсчет количества уничтоженных блоков. Получение доступа к скрипту.
            levelGenerator.brickTotalValue--;                                                   // Подсчет количества уничтоженых блоков. Уменьшение общего числа количества блоков.
            gameRules.GameOver();                                                               // Проверка на выполнение условий победы.
        }

        // Уничтожение шара, потеря жизни игрока, окончание игры.
        if (collision.gameObject.CompareTag("DeathZone"))                                       // Проверка, содержит ли объект тег DeathZone.
        {
            isFall = true;
            GameRules gameRules = FindObjectOfType<GameRules>();
            gameRules.Dead();
        }
    }
}
