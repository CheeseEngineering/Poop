using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager : MonoBehaviour
{
    public GameObject gameDirectorGo;
    public GameDirector gameDirector;

    public float score;

    void Start()
    {
        gameDirector = gameDirectorGo.GetComponent<GameDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        this.ScoreCheck();
        
        this.IsPlayerDied();
    }
    private void ScoreCheck()
    {
        this.score += Time.deltaTime / 0.001f * 0.01f;
        gameDirector.score = this.score;
    }
    private void IsPlayerDied()
    {
        if (gameDirector.isDied || gameDirector.isGameOver)
        {
            this.enabled = false;
        }
    }
}
