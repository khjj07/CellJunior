using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PartsUI : MonoBehaviour
{
    public Image PlayerArmImage;
    public Image PlayerCoreImage;

    public TextMeshProUGUI PlayerArmText;
    public TextMeshProUGUI PlayerCoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.instance.BothArm)
        {
            PlayerArmText.text = Player.instance.BothArm.AttackKey.ToString();
            PlayerArmImage.sprite = Player.instance.BothArm.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().sprite;
            PlayerArmImage.color = Player.instance.BothArm.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().color;
        }
        else
        {
            PlayerArmImage.sprite = null;
            PlayerArmText.text = "";

        }
           


    }
}
