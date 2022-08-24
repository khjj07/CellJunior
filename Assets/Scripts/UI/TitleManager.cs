using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.GameObject;

public class TitleManager : MonoBehaviour
{
    [SerializeField]
    GameObject GameStart;
    [SerializeField]
    GameObject Exit;
    [SerializeField]
    GameObject GameStartSlt;
    [SerializeField]
    GameObject ExitSlt;

   public bool StartBtnActive = false;
   public bool ExitBtnActive = false; 

    public void BtnStart()
    {
        this.gameObject.SetActive(false);
    }

    public void GoGameScene()
    {
        if (StartBtnActive = true)
        SceneManager.LoadScene(1);
        //if(ExitBtnActive = true)
        //GameManager 에서 게임 종료 기능 호출    

    }
    
   

    public void SelectStart()
    {      
        GameStart.SetActive(false);
        GameStartSlt.SetActive(true);

        if(ExitBtnActive = true)
        {
            Exit.SetActive(true);
            ExitSlt.SetActive(false);
        }
       StartBtnActive = true;
        ExitBtnActive = false;

    }

    public void SelectExit()
    {
        Exit.SetActive(false);
        ExitSlt.SetActive(true);
        if (StartBtnActive = true)
        {
            GameStart.SetActive(true);
            GameStartSlt.SetActive(false);
        }
        ExitBtnActive = true;
        StartBtnActive = false;

    }

    public void TitleStart()
    {
       // GameStart.SetActive(true);
        GameStartSlt.SetActive(false);
       // Exit.SetActive(true);
        ExitSlt.SetActive(false);
        
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
