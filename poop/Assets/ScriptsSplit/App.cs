using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class App : MonoBehaviour
{
    public GameObject gameLauncherGo;
    private GameLauncher gameLauncher;
    void Start()
    {
        gameLauncher = gameLauncherGo.GetComponent<GameLauncher>();
    }

}
