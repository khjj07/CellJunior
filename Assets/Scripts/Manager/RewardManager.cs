using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
public class RewardManager : Singleton<RewardManager>
{
    public List<Part> PartList = new List<Part>();
    public List<Reward> RewardList = new List<Reward>();
    public List<Part> PartPool;
    // Start is called before the first frame update
    public void RandomizeReward()
    {
        PartPool = new List<Part>();
        foreach (var k in PartList)
        {
            PartPool.Add(k);
        }

        foreach (var k in RewardList)
        {
            int rand = Random.Range(0, PartPool.Count);
            k.RewardPart = PartPool[rand];
            PartPool.RemoveAt(rand);
            k.InteractKey = (KeyCode)Random.Range(97, 122);//영어자판만
        }
    }

}
