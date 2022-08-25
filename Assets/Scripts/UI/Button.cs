using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Button : MonoBehaviour,IPointerDownHandler,IPointerEnterHandler,IPointerExitHandler
{
    private Sequence ScaleSquence;
    public UnityEvent ClickEvent;
    public UnityEvent EnterEvent;
    public UnityEvent ExitEvent;

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

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        ScaleSquence.Kill();
        ScaleSquence.Append(transform.DOScale(new Vector3(1, 1, 1), 0.1f).OnComplete(() => ClickEvent.Invoke()));
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        EnterEvent.Invoke();
        ScaleSquence.Kill();
        ScaleSquence.Append(transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.1f));
    }

    //Detect when Cursor leaves the GameObject
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        ExitEvent.Invoke();
        ScaleSquence.Kill();
        ScaleSquence.Append(transform.DOScale(new Vector3(1, 1, 1), 0.1f));
    }
}