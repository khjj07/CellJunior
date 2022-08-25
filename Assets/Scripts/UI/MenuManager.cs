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

    public void MenuSelect() //�����̽��ٷ� ���� ������ ����
    {
        if (BackB != null) // �������� ��Ȱ��ȭ���
        {

            SceneManager.LoadScene(0); // �ڷΰ���

        }
        else if (ReStartB != null)
        {
            return; //���� �ٽ� ���� ���

        }
        else if (GameExitB != null)
        {

            return ; // ���� ���� ���

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

    public void UpArrow() //���ư��� ��ư�� �������̶�� 
    {
        if (BackBAct == true) // �������� ��Ȱ��ȭ���
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
        if (BackBAct == true) // �������� ��Ȱ��ȭ���
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
