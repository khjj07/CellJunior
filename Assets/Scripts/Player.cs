using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using UniRx;
using UnityEngine.Events;
using UniRx.Triggers;

public class Player : Singleton<Player>, IMovable
{

    //능력치
    public float MaxHP = 100f;
    public float Speed = 1f;
    //물리
    public float LandFriction = 0.1f;
    public float AirFriction = 0.01f;
    private Vector3 Velocity = Vector3.zero;
    private bool GroundContact = false;
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
        instance.transform.parent = transform.GetChild(0).transform;
        transform.GetChild(0).transform.rotation = Quaternion.Euler(Vector3.zero);
        //세부조정


         newPart = instance.GetComponent<Part>();
        if (newPart.Type == PartType.Arm && LeftArm)
        {
            instance.transform.localPosition = new Vector3(0.7f, 0, 0);
            RightArm = (Arm)newPart;
        }
        else if (newPart.Type == PartType.Arm)
        {
            instance.transform.rotation = Quaternion.Euler(new Vector3(0,0,90));
            instance.transform.localPosition = new Vector3(0.7f, 0, 0);
            LeftArm = (Arm)newPart;
        }
        else if (newPart.Type == PartType.Leg)
        {
            transform.Translate(new Vector3(0, 1, 0));
            instance.transform.localPosition = new Vector3(0, -0.6f, 0);
            instance.transform.rotation = Quaternion.Euler(Vector3.zero);
            BothLeg = (Leg)newPart;
        }
        else if (newPart.Type == PartType.Core)
        {
            instance.transform.localPosition = new Vector3(0, 0, 0);
            PlayerCore = (Core)newPart;
        }
        Initialize();

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
       if(!BothLeg && GroundContact)
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
        if (Direction.Left == (Direction)direction && GroundContact)
            Velocity = Vector3.left * Time.deltaTime * Speed;
        else if (Direction.Right == (Direction)direction && GroundContact)
            Velocity = Vector3.right * Time.deltaTime * Speed;
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
        //movement
        this.UpdateAsObservable()
            .Where(_ => Velocity.magnitude > 0)
            .Subscribe(_ => transform.Translate(Velocity));

        this.UpdateAsObservable()
            .Where(_ => Velocity.magnitude > 0 && GroundContact)
            .Subscribe(_ => Velocity=Velocity-LandFriction*Velocity);

        this.UpdateAsObservable()
            .Where(_ => Velocity.magnitude > 0 && !GroundContact)
            .Subscribe(_ => Velocity = Velocity - AirFriction * Velocity);


    }

    
    // Update is called once per frame
    void Update()
    {
        float length = BothLeg ? 1f + BothLeg.LegLength : 1f;
        RaycastHit2D[] hit = Physics2D.RaycastAll(transform.position, Vector2.down, length);
        if (hit[0])
        {
            foreach (var h in hit)
            {
                if (h.collider.tag == "Ground")
                {
                    GroundContact = true;
                    break;
                }
                else
                {
                    GroundContact = false;
                }
            }
        }
        else
        {
            GroundContact = false;
        }
    }
}
