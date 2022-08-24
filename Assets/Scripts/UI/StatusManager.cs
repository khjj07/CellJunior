using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusManager : MonoBehaviour
{

    bool isDead = false;
    int maxHp = 5;
    int currenHp = 5;

    [SerializeField]
    Image[] hpImage = null;

     public void DecreaseHp(int p_num)
    {
        currenHp -= p_num;

        if(currenHp <= 0)
        {
            Debug.Log("Á×À½");
        }

        SettingHp();

    }

    public void SettingHp()
    {
        for(int i =0; i < hpImage.Length; i++)
        {
            if (i < currenHp)
                hpImage[i].gameObject.SetActive(true);
            else
                hpImage[i].gameObject.SetActive(false); 
        }
    }
    
    public bool IsDead()
    {
        return isDead;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
