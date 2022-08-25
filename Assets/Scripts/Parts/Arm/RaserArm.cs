using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaserArm : Arm, IAttackable
{
    public override void Start()
    {
        AttackType = ArmAttackType.RangedAttack;
    }
    public void Attack()
    {

    }
}
