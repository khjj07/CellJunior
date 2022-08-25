using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UniRx;
using UnityEngine.UI;

public class Reward : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Part RewardPart;
    public KeyCode InteractKey;
    public Image Weapon;
    private Sequence ScaleSquence;
    public void Start()
    {
        Weapon.transform.DOLocalMoveY(Weapon.transform.localPosition.y + 20f, 1f).SetEase(Ease.Linear)
                    .SetLoops(-1, LoopType.Yoyo);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ExplainPanel.instance.Show();
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        ExplainPanel.instance.Hide();
    }

    public void Update()
    {
        Weapon.sprite = RewardPart.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().sprite;
        Weapon.color = RewardPart.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().color;
        Debug.Log(Weapon.color.ToString() + " " + Weapon.sprite.ToString());
    }

    public void Equip()
    {
        Player.instance.Equip(RewardPart, InteractKey);
    }
}
