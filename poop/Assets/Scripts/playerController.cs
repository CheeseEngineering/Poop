using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class playerController : MonoBehaviour
{
    // 게임오브젝트 타입 좌우 버튼 필드선언
    public GameObject leftButton;
    public GameObject rightButton;
    public float radius = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // bool 타입 좌우 화살표눌림 변수 선언
        bool isLeftArrowDown = Input.GetKeyDown(KeyCode.LeftArrow);
        bool isRightArrowDown = Input.GetKeyDown(KeyCode.RightArrow);
        
        // 왼쪽 화살표를 누르면 x축 -1만큼 이동
        if (isLeftArrowDown)
        {
            this.transform.Translate(-1, 0, 0);
            Debug.Log("좌측화살표 누름");
        }
        // 오른쪽 화살표를 누르면 x축 1만큼 이동
        else if (isRightArrowDown)
        {
            this.transform.Translate(1, 0, 0);
            Debug.Log("우측화살표 누름");
        }
    }
}
