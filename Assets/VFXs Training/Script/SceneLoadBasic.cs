using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadBasic : MonoBehaviour
{
    public WhichMekanik mekanikMode; // Add this line to specify the mode
    public enum WhichMekanik
    {
        Base,
        Additive
    }

    public string WhatScene = "YOUR SCENE HERE";
    
    public void LoadScene()
    {
        if (WhatScene != null)
        {
            switch (mekanikMode)
            {
                case WhichMekanik.Base:
                    SceneManager.LoadScene(WhatScene);
                    break;
                case WhichMekanik.Additive:
                    SceneManager.LoadScene(WhatScene, LoadSceneMode.Additive);
                    break;
            }
        }
        else
        {
            Debug.LogError("Scene name is not specified!");
        }
    }
}
