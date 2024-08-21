using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gameDirectorGo;
    public GameDirector gameDirector;

    public bool isGameOver;
    public bool isHardModeUnlocked;
    void Start()
    {
        gameDirector = gameDirectorGo.GetComponent<GameDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        GameOverCheck();

        HardModCheck();
    }

    private void GameOverCheck()
    {
        if (gameDirector.remainTime <= 0 || gameDirector.currentHp <= 0)
        {
            this.isGameOver = true;
            gameDirector.isGameOver = true;
            Debug.Log("게임 오버");
        }

    }
    private void HardModCheck()
    {
        if(gameDirector.remainTime <= 15 && this.isHardModeUnlocked==false)
        {
            this.isHardModeUnlocked = true;
            gameDirector.isHardModeUnlocked = true;
            Debug.Log("하드모드 언락");
        }
    }
}
