using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx.Triggers;
using UniRx;
using DG.Tweening;
public class CameraMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.UpdateAsObservable()
            .Subscribe(_ => transform.DOMoveX(Player.instance.transform.position.x, 0.1f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
