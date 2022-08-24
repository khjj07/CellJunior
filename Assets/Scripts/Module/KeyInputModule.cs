using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UniRx;
using UniRx.Triggers;
using System;

public enum InputKind
{
    KeyDown,
    KeyUp,
    Key
}


[Serializable]
public class KeyEventStruct
{
    public KeyCode Key;
    public InputKind Kind;
    public UnityEvent InputEvent;
    public KeyEventStruct(KeyCode new_key,InputKind new_kind, UnityEvent new_unityEvent)
    {
        Key=new_key;
        Kind=new_kind;
        InputEvent=new_unityEvent;
        
    }
}
public class KeyInputModule : MonoBehaviour
{
    public List<KeyEventStruct> InputList = new List<KeyEventStruct>();
    public ReactiveCollection<KeyEventStruct> InputCollection = new ReactiveCollection<KeyEventStruct>();
    // Start is called before the first frame update
    void Start()
    {
        InputCollection.ObserveAdd().Subscribe(x => CreateInputStream(x.Value));

        foreach (var k in InputList)
            CreateInputStream(k);
    }
    private void CreateInputStream(KeyEventStruct structure)
    {
        if(structure.Kind==InputKind.KeyDown)
        {
            this.UpdateAsObservable()
               .Where(_ => Input.GetKeyDown(structure.Key))
               .Subscribe(_ => structure.InputEvent.Invoke())
               .AddTo(gameObject);
        }
        else if(structure.Kind == InputKind.KeyUp)
        {
            this.UpdateAsObservable()
              .Where(_ => Input.GetKeyUp(structure.Key))
              .Subscribe(_ => structure.InputEvent.Invoke())
              .AddTo(gameObject);
        }
        else
        {
            this.UpdateAsObservable()
              .Where(_ => Input.GetKey(structure.Key))
              .Subscribe(_ => structure.InputEvent.Invoke())
              .AddTo(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
