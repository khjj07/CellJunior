using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletArm : Arm,IAttackable
{
    //АјАн
    public ArmAttackType ArmType = ArmAttackType.RangedAttack;
    public Projectile Bullet;

    public void Attack()
    {

    }
}
