using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PartType
{
    Leg,
    Arm,
    Core
}

public class Part : MonoBehaviour
{
    public PartType Type = PartType.Arm;

    public Part()
    {
      
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
