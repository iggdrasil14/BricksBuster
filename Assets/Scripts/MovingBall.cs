using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBall : MonoBehaviour
{
    public Rigidbody2D rb;                                      // ����������, ������� ��������� �� ��������� Rigidbody 2D.
    public bool isActive;                                       // ��������� ���� (������������� � ������ ����, ����������� ����� ������� ���).
    public float Force = 500f;                                  // ���� � ������� ��� �������� ���������.
    public float OffsetX = 100f;                                // �������� ���� �� ��� X.

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();                       // ���������� � ���������� rb ������ �� ��������� Rigidbody.
        rb.bodyType = RigidbodyType2D.Kinematic;                // ��������� ������ Kinematic ����� � ������ ���� ��� ��� ��������� � ����������.
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isActive)           // ��������� �������� ���� ��� ������� ��� � ���������� ������� ��� ��� ��� �� �����������.
        {
            BallActive();                                       // ����� ��������� ����.
        }
    }

    /// <summary>
    /// ��������� ���� ��� ������� ���, ��������� ��� ��������;
    /// </summary>
    public void BallActive()
    {
        isActive = true;                                        // ��������� ����.
        transform.SetParent(null);                              // ���������� ������������ ��������, ����� ��� �������� �������������� �� ���������.
        rb.bodyType = RigidbodyType2D.Dynamic;                  // ������� ������� � Dinamic (���������� �������� �������).
        rb.AddForce(new Vector2 (Random.Range(-100, 100), Force));              // ���������� ���� ������� � ��������.
    }
}
