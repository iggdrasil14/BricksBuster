using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickTemplate : MonoBehaviour
{
    public GameObject Prefab;
    public List<Sprite> Sprite;
    public Color color;
    public int score;
    public int healthBrick;
    private int _countBlocks = 0;

    void Start()
    {
        healthBrick = 1;
    }

    void Update()
    {
        
    }

    private void OnEnable()
    {
        _countBlocks++;
    }

    private void OnDisable()
    {
        _countBlocks--;
        if(_countBlocks <= 0)
        {
            Debug.Log("����� �����������");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}