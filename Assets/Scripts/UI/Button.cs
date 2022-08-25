using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Button : MonoBehaviour,IPointerClickHandler,IPointerEnterHandler,IPointerExitHandler
{
    private Sequence ScaleSquence;

    private void Start()
    {
        ScaleSquence = DOTween.Sequence();
    }
    void OnEnable()
    {
        ScaleSquence.Restart();
    }
    void OnDestroy()
    {
        ScaleSquence.Kill();
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        ScaleSquence.Kill();
        ScaleSquence.Append(transform.DOScale(new Vector3(1, 1, 1), 0.1f));
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