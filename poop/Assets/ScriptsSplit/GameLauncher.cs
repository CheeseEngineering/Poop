using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLauncher : MonoBehaviour
{
    public GameObject inputManagerGo;
    private InputManager InputManager;
    void Start()
    {
        InputManager = GetComponent<InputManager>();
    }
    void Update()
    {
        
    }
}
