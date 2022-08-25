using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public enum ArmAttackType
{
    MeleeAttack,
    RangedAttack
}

public class Arm : JumpablePart
{
    //มกวม
    [SerializeField]
    private float ArmOutSec=1;
    [SerializeField]
    private float ArmOutAnimateDuration = 0.3f;
    public float ArmOutRange = 0.5f;

    private bool Out = false;

    public void ArmIn()
    {
        Out = false;
        transform.DOLocalMoveX(transform.localPosition.x-ArmOutRange, ArmOutAnimateDuration);
    }

    public void ArmOut()
    {
        Out = true;
        transform.DOLocalMoveX(transform.localPosition.x + ArmOutRange, ArmOutAnimateDuration)
            .OnComplete(() => { ArmIn(); });
    }

    public void TryJump()
    {
        ArmOut();
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 1f);
        if (hit)
        {
            Debug.DrawRay(transform.position, transform.up * hit.distance, Color.red);
            if (hit.collider.tag == "Ground")
            {
                Jump.OnNext(-hit.normal);
            }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.up * 1000f, Color.red);
        }


    }
    public void Start()
    {
        Type = PartType.Arm;
    }
    public void Update()
    {
        RaycastHit2D hit= Physics2D.Raycast(transform.position, transform.up, 1f);
        if (hit)
        {
            if (hit.collider.tag == "Ground")
            {
                Debug.Log("Jumpable");
            }
            Debug.DrawRay(transform.position, transform.up * hit.distance, Color.red);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.up * 1000f, Color.red);
        }
    }

  
}
