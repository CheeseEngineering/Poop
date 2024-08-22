using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    //ButtonController
    public GameObject LeftButtonGo;
    public GameObject RightButtonGo;
    public ButtonController leftButtonController;
    public ButtonController rightButtonController;
    public bool leftButtononClicked;
    public bool rightButtononClicked;

    // PlayerController
    public GameObject hpGaugeGo;
    public GameObject playerGo;
    public PlayerController playerController;
    public bool isLeftKeyDown;
    public bool isRightKeyDown;
    public float currentHp;
    public float playerPosX;
    public float playerPosY;
    public float playerRadius;
    public bool isDied;
    

    // TimeManager
    public GameObject timerManagerGo;
    public TimerManager timerManager;
    public GameObject textTimeGo;
    public GameObject textTimeMiniGo;
    public float remainTime;
    

    // ScoreManager
    public GameObject textScoreGo;
    public float score;

    // GameManager
    public GameObject textGameOver;
    public bool isGameOver;
    public bool isHardModeUnlocked;

    // ArrowGenerator
    public GameObject arrowGeneratorGo;
    public ArrowGenerator arrowGenerator;
    public bool isReloadCompleted;

    
    void Start()
    {
        playerController = playerGo.GetComponent<PlayerController>();
        arrowGenerator = arrowGeneratorGo.GetComponent<ArrowGenerator>();
        timerManager = timerManagerGo.GetComponent<TimerManager>();
    }
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
        this.playerPosX = playerGo.transform.position.x;
        this.playerPosY = playerGo.transform.position.y;
        this.playerRadius = playerController.radius;
        this.isDied = playerController.isDied;
        if (this.isLeftKeyDown || this.leftButtononClicked)
        {
            playerController.moveAmount = -1;
            this.leftButtononClicked = false;
        }
        else if (this.isRightKeyDown || this.rightButtononClicked)
        {
            playerController.moveAmount = 1;
            this.rightButtononClicked = false;
        }
        hpGaugeGo.GetComponent<Image>().fillAmount = (playerController.hp * 0.01f);

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

        if (this.isHardModeUnlocked == true)
        {
            timerManager.isHardModUnlocked = true;
            arrowGenerator.isHardModeUnlocked = true;
            this.isHardModeUnlocked = false;
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

    public void LeftButtonClick()
    {
        Debug.Log("좌버튼 눌림");
        this.leftButtononClicked = true;
    }

    public void RightButtonClick()
    {
        Debug.Log("우버튼 눌림");
        this.rightButtononClicked = true;
    }
}
