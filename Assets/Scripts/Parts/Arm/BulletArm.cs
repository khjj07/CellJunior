using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class BulletArm : Arm,IAttackable
{
    //АјАн
    public Projectile Bullet;
    public float MaxDistance = 50f;
    public float BulletSpeed = 25f;
    public Transform Muzzle;
    public override void Start()
    {
        AttackType = ArmAttackType.RangedAttack;
    }
    public override void Attack()
    {
        var instance = Instantiate(Bullet.gameObject);
        instance.transform.position = Muzzle.position;
        instance.transform.rotation = Quaternion.FromToRotation(Vector3.right, transform.right);
        instance.transform.DOMove(transform.right * MaxDistance, MaxDistance / BulletSpeed)
            .OnComplete(() => Destroy(instance))
            .SetAutoKill(true);
    }
}
