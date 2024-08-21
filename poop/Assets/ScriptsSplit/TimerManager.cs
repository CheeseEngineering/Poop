using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    public GameObject textTimeGo;
    public GameObject textTimeMiniGo;

    public float timer = 30;
    public float score = 0;

    void Start()
    {
        
    }
    void Update()
    {
        textTimeGo.GetComponent<Text>().text = $"{timer:0}";
        textTimeMiniGo.GetComponent<Text>().text = $".{(timer % 1) * 100:0}";
        timer -= Time.deltaTime;
        score += Time.deltaTime / 0.001f * 0.01f;

        if (timer <= 0)
        {
            timer = 0;
            score = 300;
            textTimeGo.GetComponent<Text>().text = $"{timer:0}";
            textTimeMiniGo.GetComponent<Text>().text = $".{(timer % 1) * 100:0}";
        }
    }
}
