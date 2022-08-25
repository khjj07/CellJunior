using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    
    bool MeClose = false;


    public void MenuOpen()
    {
        if (MeClose == true)
        {
            this.gameObject.SetActive(true);
            MeClose = false;
        }
        else if (MeClose == false)
        {
            this.gameObject.SetActive(false);
            MeClose = true;
        }

    }

    public void MenuSelect() //스페이스바로 선택 했을때 구현
    {
        if (BackB != null) // 나머지가 비활성화라면
        {

            SceneManager.LoadScene(0); // 뒤로가기

        }
        else if (ReStartB != null)
        {
            return; //게임 다시 시작 기능

        }
        else if (GameExitB != null)
        {

            return ; // 게임 종료 기능

        }

    }

   public void BackB_Act()
    {
        BackB.SetActive(true);
        ReStartB.SetActive(false);
        GameExitB.SetActive(false);
        BackBAct = true;
        ReStartBAct = false;
        GameExitBAct = false;
    }
     
   public void ReStartB_Act()
    {
        BackB.SetActive(false);
        ReStartB.SetActive(true);
        GameExitB.SetActive(false);
        BackBAct = false;
        ReStartBAct = true;
        GameExitBAct = false;
    }

   public void GameExitB_Act()
    {
        BackB.SetActive(false);
        ReStartB.SetActive(false);
        GameExitB.SetActive(true);
        BackBAct = false;
        ReStartBAct = false;
        GameExitBAct = true;
    }

    public void UpArrow() //돌아가기 버튼이 선택중이라면 
    {
        if (BackBAct == true) // 나머지가 비활성화라면
        {
            GameExitB_Act();

        }
        else if (ReStartBAct == true)
        {
            BackB_Act();
        }
        else if (GameExitBAct == true)
        {
            ReStartB_Act();
        }
    }

    public void DownArrow()
    {
        if (BackBAct == true) // 나머지가 비활성화라면
        {
            ReStartB_Act();
        }
        else if (ReStartBAct == true)
        {
            GameExitB_Act();
        }
        else if (GameExitBAct == true)
        {
            BackB_Act();
        }

    }



    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);

        BackB.SetActive(true);
        ReStartB.SetActive(false);
        GameExitB.SetActive(false);
        BackBAct = true;
        ReStartBAct = false;
        GameExitBAct = false;
        
        MeClose = true;


}

    // Update is called once per frame
    void Update()
    {
        
    }
}
