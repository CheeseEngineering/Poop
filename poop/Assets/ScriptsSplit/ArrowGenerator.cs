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

    void Start()
    {
        gameDirector = gameDirectorGo.GetComponent<GameDirector>();
        ArrowController = ArrowPrefab.GetComponent<ArrowController>();
    }
    void Update()
    {
        ShootingArrow();
    }

    private void ShootingArrow()
    {
        if (this.isReloadCompleted == true)
        {
            Object.Instantiate(ArrowPrefab);
            Debug.Log("น฿ป็");
            this.isReloadCompleted = false;
        }
    }
}
