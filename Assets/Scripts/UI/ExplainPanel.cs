using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx.Triggers;
using UniRx;

public class ExplainPanel : Singleton<ExplainPanel>
{
    public float Offset = 160f;
    // Start is called before the first frame update
    void Start()
    {
        this.UpdateAsObservable()
            .Where(_ =>gameObject.activeSelf)
            .Subscribe(_ =>transform.position=Input.mousePosition-new Vector3(Offset, Offset,0))
            .AddTo(gameObject);
        Hide();
    }
    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
