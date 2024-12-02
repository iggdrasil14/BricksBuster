using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBall : MonoBehaviour
{
    public Rigidbody2D rb;                                                                      // ����������, ������� ��������� �� ��������� Rigidbody 2D.
    public bool isActive;                                                                       // ��������� ���� (������������� � ������ ����, ����������� ����� ������� ���).
    public static bool isFall = false;
    public float Force = 500f;                                                                  // ���� � ������� ��� �������� ���������.
    public float OffsetX = 100f;                                                                // �������� ���� �� ��� X.
    public float speedBall;
    public int _playersLife;                                                                    // ���������� ������ ������
    private Vector2 _inDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();                                                       // ���������� � ���������� rb ������ �� ��������� Rigidbody.
        rb.bodyType = RigidbodyType2D.Kinematic;                                                // ��������� ������ Kinematic ����� � ������ ���� ��� ��� ��������� � ����������.
        _playersLife = 3;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isActive)                                           // ��������� �������� ���� ��� ������� ��� � ���������� ������� ��� ��� ��� �� �����������.
        {
            BallActive();                                                                       // ����� ��������� ����.
        }
        _inDirection = rb.velocity;
    }

    private void OnDestroy()
    {
        print("Destroyed");
    }

    /// <summary>
    /// ��������� ���� ��� ������� ���, ��������� ��� ��������;
    /// </summary>
    public void BallActive()
    {
        isActive = true;                                                                        // ��������� ����.
        transform.SetParent(null);                                                              // ���������� ������������ ��������, ����� ��� �������� �������������� �� ���������.
        rb.bodyType = RigidbodyType2D.Dynamic;                                                  // ������� ������� � Dinamic (���������� �������� �������).
        rb.AddForce(new Vector2 (Random.Range(-500, 500), Force));                              // ���������� ���� ������� � ��������.
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �������� ����.
        speedBall = _inDirection.magnitude;                                                     // ���������� ������� �������� ���� (�������� ������� ��������).
        var direction = Vector2.Reflect(_inDirection.normalized, collision.contacts[0].normal); // ������ ������ ����������� �������� ����.
        rb.velocity = direction * speedBall;                                                    // ��������� ����� �������� ���� ����� �������.
        
        // ����������� �������.
        if (collision.gameObject.CompareTag("Brick"))                                           // ��������, �������� �� ������ ��� Brick.
        {
            Destroy(collision.gameObject);                                                      // ����������� ������� ����������� ��� Brick.
            GameRules gameRules = FindObjectOfType<GameRules>();                                // ��������� � ������� GameRules.
            gameRules._playerScore++;                                                           // ���������� ���� � ������ ��� ����������� �����.

            LevelGenerator levelGenerator = FindObjectOfType<LevelGenerator>();                 // ������� ���������� ������������ ������. ��������� ������� � �������.
            levelGenerator.brickTotalValue--;                                                   // ������� ���������� ����������� ������. ���������� ������ ����� ���������� ������.
            gameRules.GameOver();                                                               // �������� �� ���������� ������� ������.
        }

        // ����������� ����, ������ ����� ������, ��������� ����.
        if (collision.gameObject.CompareTag("DeathZone"))                                       // ��������, �������� �� ������ ��� DeathZone.
        {
            isFall = true;
            GameRules gameRules = FindObjectOfType<GameRules>();
            gameRules.Dead();
        }
    }
}
