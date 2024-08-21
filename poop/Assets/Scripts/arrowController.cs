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

    // 내려가는 속도 변수 선언
    private float downSpeed;


    // 플레이어와의 거리 x축, y축 기준 변수, 플레이어와 애로우프리펩의 반경합 변수 선언
    public float distanceX;
    public float distanceY;
    public float radiusSum;

    // 애로우 프리팹 추락속도 최대 최소값 지정
    public float minSpeed = -0.06f;
    public float maxSpeed = -0.1f;

    // 애로우 프리팹이 생성될 위치 최대 최소값 지정
    public float minX = -8.5f;
    public float maxX = 8.5f;

    // x축 위치 설정
    private float positionX;


    void Start()
    {
        // 애로우 프리펩 생성 위치 x축 랜덤
        positionX = Random.Range(minX, maxX);
        // 애로우 프리펩 생성 위쪽 에서만 생성되도록 설정
        this.transform.position = new Vector3(positionX, 4.3f, 0);

        // 플레이어 게임 오브젝트 어사인
        player = GameObject.Find("player");
        // 추락속도 랜덤
        downSpeed = Random.Range(minSpeed,maxSpeed);
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

        // 추락속도 기준으로 추락 구현
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
            Object.Destroy(self);
            Debug.Log("충돌");
        }
    }
}
