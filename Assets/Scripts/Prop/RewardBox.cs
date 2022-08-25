using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RewardBox : MonoBehaviour
{
    public UnityEvent Open;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        Open.Invoke();
    }
    public void Test()
    {
        Debug.Log("test");
    }
}
