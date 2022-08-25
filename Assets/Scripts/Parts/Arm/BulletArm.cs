using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletArm : Arm,IAttackable
{
    //АјАн
    public Projectile Bullet;
    public override void Start()
    {
        AttackType = ArmAttackType.RangedAttack;
    }
    public override void Attack()
    {

    }
}
