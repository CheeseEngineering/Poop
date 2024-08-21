using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameDirector : MonoBehaviour
{
    public GameObject player;
    public GameObject self;
    public GameObject textGameOverGo;
    public GameObject textTimeGo;
    public GameObject textTimeMiniGo;
    public GameObject textScore;
    public GameObject hpGaugeFront;
    public playerController playerController;
    public ArrowGenerator arrowGenerator;
    public float timer = 30;
    public float score = 0;
    void Start()
    {
        playerController = player.GetComponent<playerController>();
        arrowGenerator = self.GetComponent<ArrowGenerator>();
    }
    void Update()
    {
        hpGaugeFront.GetComponent<Image>().fillAmount = playerController.hp * 0.01f;
        textTimeGo.GetComponent<Text>().text = $"{timer:0}";
        textTimeMiniGo.GetComponent<Text>().text = $".{(timer%1)*100:0}";
        textScore.GetComponent<Text>().text = $"점수 : {score:0.00}";
        timer -= Time.deltaTime;
        score += Time.deltaTime / 0.001f *  0.01f;
        if (playerController.hp <= 0 || timer<=0)
        {
            if (timer<=0)
            {
                timer = 0;
                score = 300;
                textTimeGo.GetComponent<Text>().text = $"{timer:0}";
                textTimeMiniGo.GetComponent<Text>().text = $".{(timer % 1) * 100:0}";
                textScore.GetComponent<Text>().text = $"점수 : {score:0.00}";
            }


            textGameOverGo.GetComponent<Text>().text = $"Game Over";
            playerController.enabled = false;
            arrowGenerator.enabled = false;
            this.enabled = false;
        }

    }
}
