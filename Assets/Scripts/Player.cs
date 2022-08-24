using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class Player : MonoBehaviour, IMovable
{
    [SerializeField]
    private float Speed = 1f;

    public void Move(int direction)
    {
        if(Direction.Left==(Direction)direction)
        {
            transform.Translate(Vector3.left*Time.deltaTime*Speed);
        }
        else if(Direction.Right == (Direction)direction)
        {
            transform.Translate(Vector3.right * Time.deltaTime * Speed);
        }
    }
    public void Move(Direction direction)
    {
        if (Direction.Left == (Direction)direction)
        {
            transform.Translate(Vector3.left * Time.deltaTime * Speed);
        }
        else if (Direction.Right == (Direction)direction)
        {
            transform.Translate(Vector3.right * Time.deltaTime * Speed);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
