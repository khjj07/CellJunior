using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System.Threading;
using System.Threading.Tasks;
using DG.Tweening;
using System;

using UniRx.Triggers;

public class Arm : MonoBehaviour
{
    [SerializeField]
    private float ArmOutSec=1;
    private float ArmOutRange = 0.5f;
    private float ArmOutAnimateDuration = 0.3f;
    public float JumpPower = 5f;
    public Vector3 Direction = Vector3.up;
    public Subject<Vector3> Contact = new Subject<Vector3>();
    private bool Out = false;


   
    public void ArmIn()
    {
        Out = false;
        
        transform.DOLocalMoveX(transform.localPosition.x-ArmOutRange, ArmOutAnimateDuration);
    }
    public void ArmOut()
    {
        Out = true;
        transform.DOLocalMoveX(transform.localPosition.x+ArmOutRange, ArmOutAnimateDuration)
            .OnComplete(() => { ArmIn(); });

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 1f);
        if (hit)
        {
            Debug.DrawRay(transform.position, transform.up * hit.distance, Color.red);
            if (hit.collider.tag == "Ground")
            {
                Contact.OnNext(-hit.normal);
            }
                
        }
        else
        {
            Debug.DrawRay(transform.position, transform.up * 1000f, Color.red);
        }


    }
    public void Update()
    {
        RaycastHit2D hit= Physics2D.Raycast(transform.position, transform.up, 1f);
        if (hit)
        {
            Debug.Log("Jumpable");
            Debug.DrawRay(transform.position, transform.up * hit.distance, Color.red);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.up * 1000f, Color.red);
        }
    }

  
}
