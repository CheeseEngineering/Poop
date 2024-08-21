using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public GameObject player;
    private PlayerController playerController;
    void Start()
    {
        player = GameObject.Find("player");
        playerController = player.GetComponent<PlayerController>();
    }
    void Update()
    {
        playerController.isLeftKeyDown = Input.GetKeyDown(KeyCode.LeftArrow);
        playerController.isRightKeyDown = Input.GetKeyDown(KeyCode.RightArrow);
    }
}
