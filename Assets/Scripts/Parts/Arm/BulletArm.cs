using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletArm : Arm,IAttackable
{
    //����
    public Projectile Bullet;
    public override void Start()
    {
        AttackType = ArmAttackType.RangedAttack;
    }
    public override void Attack()
    {

    }
}
