using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UniRx;

public class Reward : MonoBehaviour
{
    public Part RewardPart;
    public KeyCode InteractKey;

    public void Equip()
    {
        Player.instance.Equip(RewardPart);

    }
}
