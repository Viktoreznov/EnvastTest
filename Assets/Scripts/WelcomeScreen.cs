using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WelcomeScreen : MonoBehaviour
{

    public void startButton(){
        SceneManager.LoadScene("GamePlay");
    }


    public void quitApp(){
        Application.Quit();
    }
}
