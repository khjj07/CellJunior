using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletArm : Arm,IAttackable
{
    //����
    public ArmAttackType ArmType = ArmAttackType.RangedAttack;
    public Projectile Bullet;

    public void Attack()
    {

    }
}
