using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using UniRx;
using UnityEngine.Events;
using UniRx.Triggers;
using UnityEditor.Experimental.GraphView;

public class Player : Singleton<Player>, IMovable
{

    //능력치
    public int MaxHP = 5;
    public ReactiveProperty<int> HP;
    public float Speed = 5f;
    public float RollSpeed = 3f;
    private bool Movable = true;
    public float InvincibilityDuration = 0.5f;
    public float StiffnessDuration = 0.2f;
    
    private bool Invincibility = false;
    public Subject<int> Hit;
    public Subject<Vector3> Stiffness;
    //물리
    public float LandFriction = 0.1f;
    public float AirFriction = 0.01f;
    private Vector3 Velocity = Vector3.zero;
    private bool GroundContact = false;
    //파츠
    [SerializeField]
    private GameObject Body;
    public Arm BothArm;
    public Leg BothLeg;
    public Core PlayerCore;
    public void Attack()
    {
        BothArm.Attack();
    }
    public void Equip(Part newPart)
    {
        var instance = Instantiate(newPart.gameObject);
        instance.transform.parent = transform.GetChild(0).transform;
        transform.GetChild(0).transform.rotation = Quaternion.Euler(Vector3.zero);
        //세부조정


         newPart = instance.GetComponent<Part>();
        if (newPart.Type == PartType.Arm )
        {
            instance.transform.localPosition = new Vector3(0.7f, 0, 0);
            BothArm = (Arm)newPart;
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
        else if (BothArm)
            BothArm.TryJump();
    }

    public void Jump(Vector2 direction)
    {
        JumpablePart part = BothLeg ? BothLeg : BothArm ? BothArm : null;
        if(part)
            GetComponent<Rigidbody2D>().AddForce(direction* part.JumpPower, ForceMode2D.Impulse);
    }

    public void Roll(int direction)
    {
        Body.transform.Rotate(new Vector3(0, 0, 1) * 180 * direction * Time.deltaTime*RollSpeed);
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
        if (!BothLeg && BothArm)
            BothArm.Jump.Subscribe(direction => Jump(direction));
        if(BothLeg)
        {
            var JumpEvent = new UnityEvent();
            JumpEvent.AddListener(() => TryJump());
            GetComponent<KeyInputModule>().InputCollection.Add(new KeyEventStruct(BothLeg.JumpKey, InputKind.KeyDown, JumpEvent));
            BothLeg.Jump.Subscribe(direction => Jump(direction));
        }
    }

    public IEnumerator InvincibilityTime()
    {
        Invincibility = true;
        yield return new WaitForSeconds(InvincibilityDuration);
        Invincibility = false;
    }
    public IEnumerator Stiff(Vector3 force)
    {
        Movable = false;
        GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);
        yield return new WaitForSeconds(StiffnessDuration);
        Movable = true;
    }
    public void Damaged(int dmg)
    {
        StartCoroutine(InvincibilityTime());
        HP.Value-=dmg;
        HP.Value = HP.Value > 0 ? HP.Value : 0;
    }
    void Start()
    {
        Initialize();
        HP.Value = MaxHP;
        Hit = new Subject<int>();
        Hit.Where(_ => !(Invincibility))
           .Subscribe(x=>Damaged(x));

        Stiffness = new Subject<Vector3>();
        Stiffness.Where(_ => !(Invincibility))
            .Subscribe(x => StartCoroutine(Stiff(x)));
        //movement

        this.UpdateAsObservable()
            .Where(_ => Velocity.magnitude > 0 && Movable)
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
