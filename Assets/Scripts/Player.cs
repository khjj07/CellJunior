using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using UniRx;
using UnityEngine.Events;

public class Player : Singleton<Player>, IMovable
{

    //능력치
    public float MaxHP = 100f;
    public float Speed = 1f;

    //파츠
    [SerializeField]
    private GameObject Body;
    public Arm LeftArm;
    public Arm RightArm;
    public Leg BothLeg;
    public Core PlayerCore;

    public void Equip(Part newPart)
    {
        var instance = Instantiate(newPart.gameObject);
        instance.transform.parent = transform;
        //세부조정

        newPart = instance.GetComponent<Part>();
        if (newPart.Type == PartType.Arm && LeftArm)
            RightArm = (Arm)newPart;
        else if (newPart.Type == PartType.Arm)
            LeftArm = (Arm)newPart;
        else if (newPart.Type == PartType.Leg)
            BothLeg = (Leg)newPart;
        else if (newPart.Type == PartType.Core)
            PlayerCore = (Core)newPart;

    }

    public void TryJump()
    {
        if (BothLeg)
            BothLeg.TryJump();
        else if (LeftArm)
            LeftArm.TryJump();
    }

    public void Jump(Vector2 direction)
    {
        JumpablePart part = BothLeg ? BothLeg : LeftArm ? LeftArm : null;
        if(part)
            GetComponent<Rigidbody2D>().AddForce(direction* part.JumpPower, ForceMode2D.Impulse);
        Debug.Log(direction);
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
            }
            else if (Direction.Right == (Direction)direction)
            {
                Roll(-1);
            }
        }
       else
       {

       }
        if (Direction.Left == (Direction)direction)
        {
            transform.Translate(Vector3.left * Time.deltaTime * Speed);
        }
        else if (Direction.Right == (Direction)direction)
        {
            transform.Translate(Vector3.right * Time.deltaTime * Speed);
        }
    }

    public void Move(Direction direction)
    {
        Move((int)direction);
    }

    // Start is called before the first frame update
    public void Initialize()
    {
        if (!BothLeg && LeftArm)
            LeftArm.Jump.Subscribe(direction => Jump(direction));
        if(BothLeg)
        {
            var JumpEvent = new UnityEvent();
            JumpEvent.AddListener(() => TryJump());
            GetComponent<KeyInputModule>().InputCollection.Add(new KeyEventStruct(BothLeg.JumpKey, InputKind.KeyDown, JumpEvent));
            BothLeg.Jump.Subscribe(direction => Jump(direction));
        }
            
            
    }
    void Start()
    {
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
