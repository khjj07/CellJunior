using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UniRx;
using UnityEngine.UI;

public class Reward : MonoBehaviour
{
    public Part RewardPart;
    public KeyCode InteractKey;
    public Image Weapon;
    private Sequence ScaleSquence;

    public void Start()
    {
        Weapon.sprite = RewardPart.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().sprite;
        Weapon.transform.DOLocalMoveY(Weapon.transform.localPosition.y+20f,1f).SetEase(Ease.Linear)
                     .SetLoops(-1,LoopType.Yoyo);
    }

    public void Equip()
    {
        Player.instance.Equip(RewardPart);
    }
}
