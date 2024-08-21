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

    void Start()
    {
        gameDirector = gameDirectorGo.GetComponent<GameDirector>();
    }
    void Update()
    {
        remainTime -= Time.deltaTime;
        gameDirector.remainTime = remainTime;
    }
}
