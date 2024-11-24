using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    public Rigidbody2D rb;                              // Переменная, которая ссылается на компонент Rigidbody 2D.
    public float speedPlatform;                         // Переменная скорости перемещения платформы.
    public float horizontal;                            // Величина, которая задает горизонтальное направление.

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();               // Сохранение в переменной rb ссылку на компонент Rigidbody.
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");       // Определение горизонтального направления движений с помощью клавиш.
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2 (horizontal, 0) * speedPlatform;
    }
}
