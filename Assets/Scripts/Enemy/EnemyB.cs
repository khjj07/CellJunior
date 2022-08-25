using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyB : Enemy
{
    public int Damage = 1;

    // Start is called before the first frame update


    public override void Start()
    {
        foreach (var point in PointList)
        {
            PointQueue.Enqueue(point);
        }
        MoveRoutine();
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            var direction = Vector3.Normalize(collision.transform.position-transform.position);
            collision.transform.GetComponent<Player>().Stiffness.OnNext((direction+new Vector3(0,1,0))*3f);
            collision.transform.GetComponent<Player>().Hit.OnNext(Damage);
        }
    }

}
