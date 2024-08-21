using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gameDirectorGo;
    public GameDirector gameDirector;
    public bool isGameOver;
    void Start()
    {
        gameDirector = gameDirectorGo.GetComponent<GameDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        GameOverCheck();
    }

    private void GameOverCheck()
    {
        if (gameDirector.remainTime <= 0 || gameDirector.currentHp <= 0)
        {
            this.isGameOver = true;
            gameDirector.isGameOver = true;
        }

    }
}
