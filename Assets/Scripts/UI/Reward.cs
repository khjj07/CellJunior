using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UniRx;
using UnityEngine.UI;

public class Reward : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
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

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        ScaleSquence.Kill();
        ScaleSquence.Append(ExplainPanel.instance.transform.DOScale(new Vector3(1f, 1f, 1f), 0.01f));
    }
    public void OnPointerDown(PointerEventData pointerEventData)
    {
        ScaleSquence.Kill();
        ScaleSquence.Append(ExplainPanel.instance.transform.DOScale(Vector3.zero, 0.01f));
    }

    //Detect when Cursor leaves the GameObject
    public void OnPointerExit(PointerEventData pointerEventData)
    {

        ScaleSquence.Kill();
        ScaleSquence.Append(ExplainPanel.instance.transform.DOScale(Vector3.zero, 0.1f));
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
