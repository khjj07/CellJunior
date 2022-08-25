using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class RewardSkip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Sequence ScaleSquence;
  
    private void Start()
    {
       ScaleSquence = DOTween.Sequence();
    }
    void OnEnable()
    {
        ScaleSquence.Restart();
    }

    
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        ScaleSquence.Kill();
        ScaleSquence.Append(transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.1f));
    }

    //Detect when Cursor leaves the GameObject
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        ScaleSquence.Kill();
        ScaleSquence.Append(transform.DOScale(new Vector3(1, 1, 1), 0.1f));
    }   
}
