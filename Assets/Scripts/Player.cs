using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using UniRx;

public class Player : MonoBehaviour, IMovable, IJumpable
{
    [SerializeField]
    private float Speed = 1f;
    [SerializeField]
    private GameObject Body;
    public Arm LeftArm;
    public Arm RightArm;
    public Leg BothLeg;
    public Core PlayerCore;
    public void Jump(Vector2 direction)
    {
        GetComponent<Rigidbody2D>().AddForce(direction*LeftArm.JumpPower,ForceMode2D.Impulse);
        Debug.Log("Jump111");
    }
    public void Roll(int direction)
    {
        Body.transform.Rotate(new Vector3(0, 0, 1) * 180 * direction * Time.deltaTime*Speed);
    }
    public void Move(int direction)
    {
       if(!BothLeg)
       {
            if (Direction.Left == (Direction)direction)
            {
                Roll(1);
                transform.Translate(Vector3.left * Time.deltaTime * Speed);
            }
            else if (Direction.Right == (Direction)direction)
            {
                Roll(-1);
                transform.Translate(Vector3.right * Time.deltaTime * Speed);
            }
        }
       
    }
    public void Move(Direction direction)
    {
        if (Direction.Left == (Direction)direction)
            transform.Translate(Vector3.left * Time.deltaTime * Speed);
        else if (Direction.Right == (Direction)direction)
            transform.Translate(Vector3.right * Time.deltaTime * Speed);
    }

    // Start is called before the first frame update
    void Start()
    {
        if(!BothLeg && LeftArm)
            LeftArm.Contact.Subscribe(direction => Jump(direction));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
