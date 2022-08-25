using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Experimental.GlobalIllumination;

public class Enemy : MonoBehaviour
{
    public float Speed=3f;
    public List<Point> PointList = new List<Point>();
    public Queue<Point> PointQueue=new Queue<Point>();
    // Start is called before the first frame update
    
    public void MoveRoutine()
    {
        var next_point = PointQueue.Dequeue();
        PointQueue.Enqueue(next_point);
        Vector3 direction = Vector3.Normalize(next_point.transform.position - transform.position);

        if (direction.x < 0)
            transform.rotation = Quaternion.Euler(Vector3.zero);
        else
            transform.rotation = Quaternion.Euler(new Vector3(0,180,0));

        transform.DOMove(next_point.transform.position, Vector3.Distance(next_point.transform.position, transform.position) / Speed)
                .OnComplete(() => { MoveRoutine(); });

    }
    void Start()
    {
        foreach (var point in PointList)
        {
            PointQueue.Enqueue(point);
        }
        MoveRoutine();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
