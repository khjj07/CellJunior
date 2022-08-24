using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardState : MonoBehaviour
{
    private void OnEnable()
    {
        RewardManager.instance.RandomizeReward();
    }
}
