using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    public void QuitGame() {
        Application.Quit();
    }
    public void StartGame() {
        SceneManager.LoadScene("InGame");
    }
}