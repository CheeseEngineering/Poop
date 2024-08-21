using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    // PlayerController
    public GameObject playerGo;
    public PlayerController playerController;
    public bool isLeftKeyDown;
    public bool isRightKeyDown;
    public float currentHp;

    // TimeManager
    public GameObject textTimeGo;
    public GameObject textTimeMiniGo;
    public float remainTime;

    // ScoreManager
    public GameObject textScoreGo;
    public float score;

    // GameManager
    public GameObject textGameOver;
    public bool isGameOver;

    // ArrowGenerator
    public GameObject arrowGeneratorGo;
    public ArrowGenerator arrowGenerator;
    public bool isReloadCompleted;

    void Start()
    {
       playerController = playerGo.GetComponent<PlayerController>();
       arrowGenerator = arrowGeneratorGo.GetComponent<ArrowGenerator>();
    }

    // Update is called once per frame
    void Update()
    {

        PlayerControllerDirecting();

        TimeManagerDirecting();

        ScoreManagerDirecting();

        GameManagerDirecting();

        ArrowGeneratorDirecting();
    }
    private void PlayerControllerDirecting()
    {
        this.currentHp = playerController.hp;
        if (isLeftKeyDown)
        {
            playerController.moveAmount = -1;
        }
        else if (isRightKeyDown)
        {
            playerController.moveAmount = 1;
        }
    }
    private void TimeManagerDirecting()
    {
        textTimeGo.GetComponent<Text>().text = $"{this.remainTime:0}";
        textTimeMiniGo.GetComponent<Text>().text = $".{(this.remainTime % 1) * 100:0}";
        if (this.remainTime <= 0)
        {
            this.remainTime = 0;
            textTimeGo.GetComponent<Text>().text = $"{this.remainTime:0}";
            textTimeMiniGo.GetComponent<Text>().text = $".{(this.remainTime % 1) * 100:0}";
        }
    }
    private void ScoreManagerDirecting()
    {
        textScoreGo.GetComponent<Text>().text = $"점수 : {score:0.00}";
        if (this.remainTime <= 0)
        {
            this.score = 300;
            textScoreGo.GetComponent<Text>().text = $"점수 : {score:0.00}";
        }
    }

    private void GameManagerDirecting()
    {
        if (isGameOver==true)
        {
            textGameOver.GetComponent<Text>().text = $"Game Over!!";
        }
    }

    private void ArrowGeneratorDirecting()
    {
        if (this.isReloadCompleted == true)
        {
            arrowGenerator.isReloadCompleted = true;
            this.isReloadCompleted = false;
        }
    }
}
