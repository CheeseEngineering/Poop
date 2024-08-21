using System.Collections;
using System.Collections.Generic;
using UnityEditor.TextCore.Text;
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

        IsPlayerDied();
    }

    private void RemainTimeCheck()
    {
        this.remainTime -= Time.deltaTime;
        gameDirector.remainTime = this.remainTime;
    }

    private void ShootingDelayCheck()
    {
        if (isHardModUnlocked==true)
        {
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
    private void IsPlayerDied()
    {
        if (gameDirector.isDied || gameDirector.isGameOver)
        {
            this.enabled = false;
        }
    }
}
