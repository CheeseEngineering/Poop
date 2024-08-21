using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    public GameObject gameDirectorGo;
    public GameDirector gameDirector;
    public float remainTime = 30;
    public float shootingDelay = 0;
    void Start()
    {
        gameDirector = gameDirectorGo.GetComponent<GameDirector>();
    }
    void Update()
    {
        RemainTimeCheck();

        ShootingDelayCheck();
        
    }

    private void RemainTimeCheck()
    {
        remainTime -= Time.deltaTime;
        gameDirector.remainTime = remainTime;
    }

    private void ShootingDelayCheck()
    {
        shootingDelay += Time.deltaTime;
        if(shootingDelay > 1f)
        {
            gameDirector.isReloadCompleted = true;
            shootingDelay = 0;
        }

    }
}
