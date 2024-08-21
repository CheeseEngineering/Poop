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
    
    public bool isReloadCompleted;
    public bool isHardModeUnlocked;

    private int minDamage = 5;
    private int maxDamage = 10;
    private int arrowDamageToInt;
    public float arrowDamage;

    private float minSpeed = -0.06f;
    private float maxSpeed = -0.1f;
    public float arrowSpeed;


    void Start()
    {
        gameDirector = gameDirectorGo.GetComponent<GameDirector>();
        ArrowController = ArrowPrefab.GetComponent<ArrowController>();
    }
    void Update()
    {
        SelectVarietyArrows();

        HardModeChange();

        ShootingArrow();
    }

    private void ShootingArrow()
    {
        if (this.isReloadCompleted == true)
        {
            if (this.arrowDamage == maxDamage)
            {
                Object.Instantiate(ArrowMaxPrefab);
                this.isReloadCompleted = false;
                Debug.Log("발사");
            }
            else
            {
                Object.Instantiate(ArrowPrefab);
                this.isReloadCompleted = false;
                Debug.Log("발사");
            }
            
        }
    }
    private void SelectVarietyArrows()
    {
        this.arrowDamageToInt=Random.Range(minDamage,maxDamage);
        this.arrowDamage = arrowDamageToInt / 1;
        ArrowController.arrowDamage = this.arrowDamage;

        this.arrowSpeed = Random.Range(minSpeed,maxSpeed);
        ArrowController.arrowSpeed = this.arrowSpeed;
    }

    private void HardModeChange()
    {
        if (this.isHardModeUnlocked == true)
        {
            Debug.Log("활 하드모드 언락");
            ArrowController.arrowDamage *= 2;
            ArrowController.arrowSpeed *= 2;
        }
    }
}
