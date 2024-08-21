using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public GameObject gameDirectorGo;
    public GameDirector gameDirector;
    void Start()
    {
        gameDirector = gameDirectorGo.GetComponent<GameDirector>();
    }
    void Update()
    {
        gameDirector.isLeftKeyDown= Input.GetKeyDown(KeyCode.LeftArrow);
        gameDirector.isRightKeyDown = Input.GetKeyDown(KeyCode.RightArrow);
    }
}
