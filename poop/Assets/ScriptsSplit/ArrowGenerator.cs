using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGenerator : MonoBehaviour
{
    public GameObject gameDirectorGo;
    public GameDirector gameDirector;
    
    public GameObject ArrowPrefab;
    public GameObject ArrowMaxPrefab;
    public ArrowController ArrowController; 
    public ArrowController ArrowMaxController; 
    
    public bool isReloadCompleted;
    public bool isHardModeUnlocked;

    private int minDamage = 5;
    private int maxDamage = 10;
    private int arrowDamageToInt;
    public float arrowDamage;

    private float minSpeed = -0.06f;
    private float maxSpeed = -0.1f;
    public float arrowSpeed;

    private float minX = -8.5f;
    private float maxX = 8.5f;
    public float arrowPosX;


    void Start()
    {
        gameDirector = gameDirectorGo.GetComponent<GameDirector>();
        ArrowController = ArrowPrefab.GetComponent<ArrowController>();
        ArrowMaxController = ArrowMaxPrefab.GetComponent<ArrowController>();
    }
    void Update()
    {
        SelectVarietyArrows();

        SelectInstantiateLocation();

        HardModeChange();

        ShootingArrow();

        IsPlayerDied();

    }

    private void ShootingArrow()
    {
        if (this.isReloadCompleted == true)
        {
            if (this.arrowDamage == maxDamage)
            {
                Object.Instantiate(ArrowMaxPrefab);
                this.isReloadCompleted = false;
            }
            else
            {
                Object.Instantiate(ArrowPrefab);
                this.isReloadCompleted = false;
            }
        }
    }
    private void SelectVarietyArrows()
    {
        this.arrowDamageToInt=Random.Range(minDamage,maxDamage+1);
        this.arrowDamage = arrowDamageToInt / 1;
        ArrowController.arrowDamage = this.arrowDamage;
        ArrowMaxController.arrowDamage = this.arrowDamage;

        this.arrowSpeed = Random.Range(minSpeed,maxSpeed);
        ArrowController.arrowSpeed = this.arrowSpeed;
        ArrowMaxController.arrowSpeed = this.arrowSpeed;
    }

    private void SelectInstantiateLocation()
    {
        this.arrowPosX = Random.Range(minX, maxX);
        ArrowController.arrowPosX = this.arrowPosX;
        ArrowMaxController.arrowPosX = this.arrowPosX;
    }

    private void HardModeChange()
    {
        if (this.isHardModeUnlocked == true)
        {
            ArrowController.arrowDamage *= 2;
            ArrowMaxController.arrowDamage *= 2;

            ArrowController.arrowSpeed *= 2;
            ArrowMaxController.arrowSpeed *= 2;
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
