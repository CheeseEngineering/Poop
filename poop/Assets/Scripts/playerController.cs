using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class playerController : MonoBehaviour
{
    // 플레이어 반경 변수 1설정하여 선언
    public float radius = 1f;
    public float hp = 100;
    public float maxHp = 100;
    void Start()
    {
        Debug.Log($"현재 체력 : {this.hp}/{this.maxHp}");
    }
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
            LimitPosition();
        }
        // 오른쪽 화살표를 누르면 x축 1만큼 이동
        else if (isRightArrowDown)
        {
            this.transform.Translate(1, 0, 0);
            Debug.Log("우측화살표 누름");
            LimitPosition();
        }

        
    }
    public void Damaged()
    {
        Debug.Log($"현재 체력 : {this.hp}/{this.maxHp}");
    }

    private void LimitPosition()
    {
        if (this.transform.position.x > 7.78f || this.transform.position.x < -7.78f)
        {
            this.transform.position= new Vector3 (Mathf.Clamp(this.transform.position.x, -7.78f, 7.78f), this.transform.position.y, this.transform.position.z);
        }
    }
}
