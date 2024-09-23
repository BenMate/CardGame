using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Menu : MonoBehaviour
{
    public GameObject menu;
    public GameObject pickaGameScreen;

    void Start()
    {
        menu.gameObject.SetActive(true);
        pickaGameScreen.SetActive(false);
    }

    public void ChangeSceneViaPath(string scenePath)
    {
        SceneManager.LoadScene(scenePath);
    }
}
