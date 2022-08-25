using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyA : Enemy
{
    public int Damage = 1;
    private bool Look = true;
    public float NoLookDuration = 2f;
    public float LookDuration = 4f;
    public Animator Controller;
    public GameObject Sight;
    // Start is called before the first frame update

    IEnumerator Twinkling()
    {
        while(true)
        {
            Look = true;
            Sight.SetActive(true);
            Controller.SetBool("Look", true);
            yield return new WaitForSeconds(LookDuration);
            Look = false;
            Sight.SetActive(false);
            Controller.SetBool("Look", false);
            yield return new WaitForSeconds(NoLookDuration);
        }
    }

    public override void Start()
    {
        foreach (var point in PointList)
        {
            PointQueue.Enqueue(point);
        }
        MoveRoutine();
        StartCoroutine(Twinkling());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag("Player") && Look)
        {
            var direction = Vector3.Normalize(collision.transform.position-transform.position);
            collision.transform.GetComponent<Player>().Stiffness.OnNext((direction+new Vector3(0,1,0))*3f);
            collision.transform.GetComponent<Player>().Hit.OnNext(Damage);
        }
        
    }
   
}
