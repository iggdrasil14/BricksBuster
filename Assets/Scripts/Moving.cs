using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    public Rigidbody2D rb;                              // ����������, ������� ��������� �� ��������� Rigidbody 2D.
    public float speedPlatform;                         // ���������� �������� ����������� ���������.
    public float horizontal;                            // ��������, ������� ������ �������������� �����������.

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();               // ���������� � ���������� rb ������ �� ��������� Rigidbody.
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");       // ����������� ��������������� ����������� �������� � ������� ������.
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2 (horizontal, 0) * speedPlatform;
    }
}
