﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadScene(int scene)
    {
        SceneManager.LoadSceneAsync(scene);
    }

    public void Options()
    {

    }

    public void Quit()
    {
        Application.Quit();
    }
}
