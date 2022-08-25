using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.Events;
public class Leg : JumpablePart
{
    public float LegLength = 0.6f;

    public void TryJump()
    {
        RaycastHit2D[] hit = Physics2D.RaycastAll(transform.position, Vector2.down, LegLength);

        if(hit[0])
        {
            foreach (var h in hit)
            {
                if (h.collider.tag == "Ground")
                {
                    Jump.OnNext(h.normal);
                    break;
                }
            }
            Debug.DrawRay(transform.position, Vector2.down * LegLength, Color.blue);
        }
        else
        {
            Debug.DrawRay(transform.position, Vector2.down * LegLength, Color.red);
        }
    }


    // Start is called before the first frame update
    public void Start()
    {
        Type = PartType.Leg;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, LegLength);
        /*if (hit)
        {
            Debug.DrawRay(transform.position, Vector2.down * hit.distance, Color.red);
        }
        else*/
        {
            Debug.DrawRay(transform.position, Vector2.down * LegLength, Color.red);
        }
    }
}
