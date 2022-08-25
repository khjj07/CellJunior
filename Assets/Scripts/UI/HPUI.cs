using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UIElements;
public class HPUI : MonoBehaviour
{
    public List<HPTick> HP = new List<HPTick>(); 
    public void UpdateHP(int hp)
    {
        for(int i = 0;  i< HP.Count; i++)
        {
            if (i < hp)
                HP[i].gameObject.SetActive(true);
            else
                HP[i].gameObject.SetActive(false);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Player.instance.HP.Subscribe(_ => UpdateHP(_));
    }
}
