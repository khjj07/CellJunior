using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
//using UnityEngine.GameObject;

public class TitleManager : MonoBehaviour
{

    public void GoGameScene()
    {
        DOTween.KillAll();
        SceneManager.LoadScene(1);   
    }

}
