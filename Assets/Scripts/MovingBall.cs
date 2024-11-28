using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBall : MonoBehaviour
{
    public Rigidbody2D rb;                                                                      // ����������, ������� ��������� �� ��������� Rigidbody 2D.
    public GameObject platform;
    public GameObject ball;
    public GameObject platformAndBallPrefab;
    public bool isActive;                                                                       // ��������� ���� (������������� � ������ ����, ����������� ����� ������� ���).
    private bool _isFall = false;
    public float Force = 500f;                                                                  // ���� � ������� ��� �������� ���������.
    public float OffsetX = 100f;                                                                // �������� ���� �� ��� X.
    public float speedBall;
    public int _playersLife;                                                                    // ���������� ������ ������
    private Vector2 _inDirection;
    private Vector2 _inNormal;
    private Vector2 _startPosition;

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
        }

        // ����������� ����, ������ ����� ������, ��������� ����.
        if (collision.gameObject.CompareTag("DeathZone"))                                       // ��������, �������� �� ������ ��� DeathZone.
        {
            Destroy(ball);                                                                      // ���������� ������ ball.
            Destroy(platform);                                                                  // ���������� ������ platform (������).
            Instantiate(platformAndBallPrefab, new Vector2(0, -8), Quaternion.identity);        // ������������� ������� FlatformAndBall � ��������� �����������.
            _isFall = true;
        }
    }

    /// <summary>
    /// ����� ����������/���������� ���������� ������ � ������.
    /// </summary>
    public void PlayersLife()
    {
        // ������� ���������� ���������� ������.
        //if ()
        //{
        //    _playersLife++;
        //}

        // ������� ���������� ���������� ������.
        if(_isFall == true)
        {
            _playersLife--;
            GameOver();
        }
    }

    /// <summary>
    /// ����� �������� ��������� ����.
    /// </summary>
    public void GameOver()
    {
        if(_playersLife <= 0)
        {
            Debug.Log("Game Over");
        }
    }
}
