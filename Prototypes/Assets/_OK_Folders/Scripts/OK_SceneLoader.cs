using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OK_SceneLoader : MonoBehaviour {

    public int in_SceneNum;
    
    public void LoadScene()
    {
        SceneManager.LoadScene(in_SceneNum);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
