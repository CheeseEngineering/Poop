using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public GameObject selfGo;
    public GameObject gameDirectorGo;
    public GameObject playerGo;
    public PlayerController playerController;
    public GameDirector gameDirector;

    private float selfScore = 10;
    public float arrowDamage;
    public float arrowSpeed;
    public float arrowPosX;
    public float radius = 1;
    void Start()
    {
        playerGo = GameObject.Find("player");
        gameDirectorGo = GameObject.Find("GameDirector");
        playerController = playerGo.GetComponent<PlayerController>();
        gameDirector = gameDirectorGo.GetComponent<GameDirector>();
        this.transform.position = new Vector3(arrowPosX, 4.5f, 0f);
    }
    void Update()
    {
        Move();

        Collide();

        FallGround();

        IsPlayerDied();
    }
    private void Move()
    {
        this.transform.Translate(0, this.arrowSpeed, 0);
    }

    private void FallGround()
    {
        if(this.transform.position.y <= -3.5)
        {
           Object.Destroy(selfGo);
        }
    }
    private void Collide()
    {
        if(Mathf.Abs(this.transform.position.x - playerGo.transform.position.x)<(playerController.radius + this.radius) &&
            Mathf.Abs(this.transform.position.y - playerGo.transform.position.y) < (this.playerController.radius + this.radius))
        {
            playerController.hp -= this.arrowDamage;
            playerController.isDamaged = true;
            Debug.Log("충돌");
            Object.Destroy(selfGo);
        }
    }

    private void IsPlayerDied()
    {
        if (gameDirector.isDied || gameDirector.isGameOver)
        {
            gameDirector.score += this.selfScore;
            Debug.Log($"화살 수거 점수 : {this.selfScore}");
            Object.Destroy(selfGo);
            this.enabled = false;
        }
    }
}
