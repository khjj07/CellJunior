using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StingArm : Arm, IAttackable
{
    private Animator AnimatorController;
    public string AttackAnimation;
    public override void Start()
    {
        AnimatorController = GetComponent<Animator>();
        this.AttackType = ArmAttackType.MeleeAttack;
    }
    public override void Attack()
    {
        AnimatorController.SetBool("Attack", true);
    }
}
