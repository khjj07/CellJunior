using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class JumpablePart : Part
{
 
    public float JumpPower = 5f;
    public KeyCode JumpKey = KeyCode.Space;
    public Subject<Vector2> Jump = new Subject<Vector2>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
