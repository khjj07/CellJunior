using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.GameObject;

public class TitleManager : MonoBehaviour
{

    public void GoGameScene()
    {
        SceneManager.LoadScene(1);   
    }

}
