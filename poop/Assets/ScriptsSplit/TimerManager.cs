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

    public bool isHardModUnlocked;
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
        this.remainTime -= Time.deltaTime;
        gameDirector.remainTime = remainTime;
    }

    private void ShootingDelayCheck()
    {
        if (isHardModUnlocked==true)
        {
            Debug.Log("속사 하드모드 언락");
            this.shootingDelay += Time.deltaTime*2;
            if (this.shootingDelay > 1f)
            {
                gameDirector.isReloadCompleted = true;
                this.shootingDelay = 0;
            }
        }
        else
        {
            this.shootingDelay += Time.deltaTime;
            if (this.shootingDelay > 1f)
            {
                gameDirector.isReloadCompleted = true;
                this.shootingDelay = 0;
            }
        }
    }
}
