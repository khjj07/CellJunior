using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{

    public void BtnStart()
    {
        this.gameObject.SetActive(false);
    }

    public void GoGameScene()
    {
        SceneManager.LoadScene(1);
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
