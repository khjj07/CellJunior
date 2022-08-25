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
    protected ArmAttackType AttackType;
    private bool Out = false;

    public virtual void Attack()
    {

    }
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
        
        RaycastHit2D[] hit = Physics2D.RaycastAll(transform.position, transform.right, 2f);
        foreach (var i in hit)
        {
            if (i.collider.tag == "Ground")
            {
                var dir = Vector3.Normalize(i.normal - new Vector2(transform.right.x, transform.right.y));
                Jump.OnNext(dir);
                break;
            }
                
        }
    }
    public virtual void Start()
    {
        Type = PartType.Arm;
    }
}
