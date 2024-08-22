using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public GameObject gameDirectorGo;
    public GameDirector gameDirector;
    
    void Start()
    {
        gameDirector = gameDirectorGo.GetComponent<GameDirector>();
        
    }
    void Update()
    {
        
    }

}
