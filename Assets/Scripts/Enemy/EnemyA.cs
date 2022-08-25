using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyA : Enemy
{
    public int Damage = 1;
    private float Stiffness = 3f;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            var direction = Vector3.Normalize(collision.transform.position-transform.position);
            collision.transform.GetComponent<Player>().Stiffness.OnNext((direction+new Vector3(0,1,0))*Stiffness);
            collision.transform.GetComponent<Player>().Hit.OnNext(Damage);
        }
    }
}
