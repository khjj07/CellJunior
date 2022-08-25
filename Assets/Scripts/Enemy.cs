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
    public Transform Root;
    // Start is called before the first frame update
    
    public void DestoryAll()
    {
        var allChildren = Root.GetComponentsInChildren<Transform>();
        for (var ac = 0; ac < allChildren.Length; ac++)
        { //var child : Transform in allChildren
            print("Removing old text modules");
            Destroy(allChildren[ac].gameObject);
        }
        Destroy(Root.gameObject);
    }
    public void MoveRoutine()
    {
        var next_point = PointQueue.Dequeue();
        PointQueue.Enqueue(next_point);
        Vector3 direction = Vector3.Normalize(next_point.transform.position - transform.position);

        if (direction.x < 0)
            transform.rotation = Quaternion.Euler(Vector3.zero);
        else
            transform.rotation = Quaternion.Euler(new Vector3(0,180,0));

        transform.DOMoveX(next_point.transform.position.x, Vector3.Distance(next_point.transform.position, transform.position) / Speed)
                .SetAutoKill(true)
                .OnComplete(() => { MoveRoutine(); });

    }

    public void OnDestroy()
    {
        transform.DOKill();
    }
    public virtual void Start()
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
