using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IJumpable
{
    void Jump(Vector3 direction, float force);
}
