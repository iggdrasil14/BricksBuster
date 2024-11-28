using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBall : MonoBehaviour
{
    public Rigidbody2D rb;                                                                      // ѕеременна€, котора€ ссылаетс€ на компонент Rigidbody 2D.
    public GameObject platform;
    public GameObject ball;
    public GameObject platformAndBallPrefab;
    public bool isActive;                                                                       // —осто€ние м€ча (деактивирован в начале игры, активирован после нажати€ Ћ ћ).
    private bool _isFall = false;
    public float Force = 500f;                                                                  // —ила с которой м€ч начинает двигатьс€.
    public float OffsetX = 100f;                                                                // —мещение м€ча по оси X.
    public float speedBall;
    public int _playersLife;                                                                    //  оличество жизней игрока
    private Vector2 _inDirection;
    private Vector2 _inNormal;
    private Vector2 _startPosition;

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
        }

        // ”ничтожение шара, потер€ жизни игрока, окончание игры.
        if (collision.gameObject.CompareTag("DeathZone"))                                       // ѕроверка, содержит ли объект тег DeathZone.
        {
            Destroy(ball);                                                                      // ”ничтожает объект ball.
            Destroy(platform);                                                                  // ”ничтожает объект platform (стара€).
            Instantiate(platformAndBallPrefab, new Vector2(0, -8), Quaternion.identity);        // »нициализаци€ префаба FlatformAndBall в начальный координатах.
            _isFall = true;
        }
    }

    /// <summary>
    /// ћетод увеличени€/уменьшени€ количества жизней у игрока.
    /// </summary>
    public void PlayersLife()
    {
        // ”слови€ увеличени€ количества жизней.
        //if ()
        //{
        //    _playersLife++;
        //}

        // ”словие уменьшени€ количества жизней.
        if(_isFall == true)
        {
            _playersLife--;
            GameOver();
        }
    }

    /// <summary>
    /// ћетод проверки окончани€ игры.
    /// </summary>
    public void GameOver()
    {
        if(_playersLife <= 0)
        {
            Debug.Log("Game Over");
        }
    }
}
