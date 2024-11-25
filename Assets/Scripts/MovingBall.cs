using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBall : MonoBehaviour
{
    public Rigidbody2D rb;                                      // ѕеременна€, котора€ ссылаетс€ на компонент Rigidbody 2D.
    public bool isActive;                                       // —осто€ние м€ча (деактивирован в начале игры, активирован после нажати€ Ћ ћ).
    public float Force = 500f;                                  // —ила с которой м€ч начинает двигатьс€.
    public float OffsetX = 100f;                                // —мещение м€ча по оси X.

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();                       // —охранение в переменной rb ссылку на компонент Rigidbody.
        rb.bodyType = RigidbodyType2D.Kinematic;                // ”становка режима Kinematic чтобы в начале игры м€ч мог двигатьс€ с платформой.
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isActive)           // јктиваци€ движени€ м€ча при налатии Ћ ћ и выполнении услови€ что м€ч еще не активирован.
        {
            BallActive();                                       // ћетод активации м€ча.
        }
    }

    /// <summary>
    /// јктивачи€ м€ча при нажатии Ћ ћ, параметры его движение;
    /// </summary>
    public void BallActive()
    {
        isActive = true;                                        // јктиваци€ м€ча.
        transform.SetParent(null);                              // ќтсутствие родительских объектов, чтобы м€ч двигалс€ самосто€тельно от платформы.
        rb.bodyType = RigidbodyType2D.Dynamic;                  // ѕеревод объекта в Dinamic (управление объектом физикой).
        rb.AddForce(new Vector2 (Random.Range(-100, 100), Force));              // ƒобавление силы вли€ни€ и смещени€.
    }
}
