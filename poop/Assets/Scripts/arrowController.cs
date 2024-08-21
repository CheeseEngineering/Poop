using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class arrowController : MonoBehaviour
{
    // 게임 오브젝트 타입 변수 설정
    public GameObject self;
    public GameObject player;
    // 플레이어컨트롤러 형식의 변수 선언
    public playerController playerController;
    // 반경 변수 1만큼 설정하여 선언
    public float radius = 1f;
    // 플레이어와의 거리 x축, y축 기준 변수, 플레이어와 애로우프리펩의 반경합 변수 선언
    public float distanceX;
    public float distanceY;
    public float radiusSum;
    public float downSpeed;

    public float damage;
    void Start()
    {
        // 플레이어 게임 오브젝트 어사인
        player = GameObject.Find("player");
        // 플레이어 컨트롤러 스크립트 받아옴
        playerController = player.GetComponent<playerController>();
    }
    void Update()
    {
        
        // 플레이어와 애로우 프리펩의 거리 x축과 y축으로 측정 (절대값화)
        // 플레이어와 애로우 프리펩의 반경합 측정
        distanceX = Mathf.Abs(player.transform.position.x - this.transform.position.x);
        distanceY = Mathf.Abs(player.transform.position.y - this.transform.position.y);
        radiusSum = this.radius + playerController.radius;
        this.transform.Translate(0, downSpeed, 0);
        // 땅에 닿았을 때 파괴
        if (this.transform.position.y < -4)
        {
            Object.Destroy(self);
        }
        // 플레이어와 충돌했을 때 파괴
        // (x거리와 y거리를 분리해서 예외문 처리할경우 생성하자마자 파괴되는 버그 생김)
        else if (distanceY <= radiusSum && distanceX <=radiusSum)
        {
            playerController.hp -= this.damage;
            Object.Destroy(self);
            Debug.Log("충돌");
            playerController.Damaged();
            
        }
    }
}
