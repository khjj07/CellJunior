using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    GameObject Back;
    [SerializeField]
    GameObject BackB;
    [SerializeField]
    GameObject ReStart;
    [SerializeField]
    GameObject ReStartB;
    [SerializeField]
    GameObject GameExit;
    [SerializeField]
    GameObject GameExitB;

    public bool BackBAct = false;
    public bool ReStartBAct = false;
    public bool GameExitBAct = false;


    public void MenuSelect()
    {

    }

    public void UpArrow() //돌아가기 버튼이 선택중이라면 
    {
        //if (ReStartBAct = false  GameExitBAct = false) // 나머지가 비활성화라면
        //{



        //}
    }

    public void DownArrow()
    {

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
