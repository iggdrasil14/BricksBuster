using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBall : MonoBehaviour
{
    public Rigidbody2D rb;                                                                      // ѕеременна€, котора€ ссылаетс€ на компонент Rigidbody 2D.
    public bool isActive;                                                                       // —осто€ние м€ча (деактивирован в начале игры, активирован после нажати€ Ћ ћ).
    public static bool isFall = false;
    public float Force = 500f;                                                                  // —ила с которой м€ч начинает двигатьс€.
    public float OffsetX = 100f;                                                                // —мещение м€ча по оси X.
    public float speedBall;
    public int _playersLife;                                                                    //  оличество жизней игрока
    private Vector2 _inDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();                                                       // —охранение в переменной rb ссылку на компонент Rigidbody.
        rb.bodyType = RigidbodyType2D.Kinematic;                                                // ”становка режима Kinematic чтобы в начале игры м€ч мог двигатьс€ с платформой.
        _playersLife = 3;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isActive)                                           // јктиваци€ движени€ м€ча при налатии Ћ ћ и выполнении услови€ что м€ч еще не активирован.
        {
            BallActive();                                                                       // ћетод активации м€ча.
        }
        _inDirection = rb.velocity;
    }

    private void OnDestroy()
    {
        print("Destroyed");
    }

    /// <summary>
    /// јктивачи€ м€ча при нажатии Ћ ћ, параметры его движение;
    /// </summary>
    public void BallActive()
    {
        isActive = true;                                                                        // јктиваци€ м€ча.
        transform.SetParent(null);                                                              // ќтсутствие родительских объектов, чтобы м€ч двигалс€ самосто€тельно от платформы.
        rb.bodyType = RigidbodyType2D.Dynamic;                                                  // ѕеревод объекта в Dinamic (управление объектом физикой).
        rb.AddForce(new Vector2 (Random.Range(-500, 500), Force));                              // ƒобавление силы вли€ни€ и смещени€.
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ƒвижение шара.
        speedBall = _inDirection.magnitude;                                                     // —охранение текущей скорости м€ча (величину вектора скорости).
        var direction = Vector2.Reflect(_inDirection.normalized, collision.contacts[0].normal); // –асчет нового направлени€ движени€ м€ча.
        rb.velocity = direction * speedBall;                                                    // ”становка новой скорости м€ча после отскока.
        
        // ”ничтожение объекта.
        if (collision.gameObject.CompareTag("Brick"))                                           // ѕроверка, содержит ли объект тег Brick.
        {
            Destroy(collision.gameObject);                                                      // ”ничтожение объекта содержащего тег Brick.
            GameRules gameRules = FindObjectOfType<GameRules>();                                // ќбращение к скрипту GameRules.
            gameRules._playerScore++;                                                           // ”величение оков у игрока при уничтожении блока.
        }

        // ”ничтожение шара, потер€ жизни игрока, окончание игры.
        if (collision.gameObject.CompareTag("DeathZone"))                                       // ѕроверка, содержит ли объект тег DeathZone.
        {
            isFall = true;
            GameRules gameRules = FindObjectOfType<GameRules>();
            gameRules.Dead();
        }
    }
}
