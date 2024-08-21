using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ArrowGenerator : MonoBehaviour
{
    // 생성할 애로우 프리펩 변수 선언
    public GameObject arrowGo;
    public GameObject arrowMaxGo;
    public GameObject gameDirector;
    private arrowController arrowController;
    public gameDirector gameDirectorScript;
    // 시간을 측정할 변수 및 시간한계점 1초 주기 선언
    private float timer;
    private float instantiationThreshold = 1f;
    // 애로우 프리팹이 생성될 위치 최대 최소값 지정
    private float minX = -8.5f;
    private float maxX = 8.5f;

    // 내려가는 속도 변수 선언
    private float downSpeed;

    private int minDamage = 5;
    private int maxDamage = 10;
    // 애로우 프리팹 추락속도 최대 최소값 지정
    private float minSpeed = -0.06f;
    private float maxSpeed = -0.1f;
    // x축 위치 설정
    private float positionX;
    public float damage;
    public int damageToInt;
    void Start()
    {
        arrowController = arrowGo.GetComponent<arrowController>();
        gameDirectorScript = gameDirector.GetComponent<gameDirector>();
    }
    void Update()
    {
        if (gameDirectorScript.timer <= 15f)
        {
            // deltaTime만큼 증가
            this.timer += Time.deltaTime*2;
        }
        else
        {
            // deltaTime만큼 증가
            this.timer += Time.deltaTime;
        }

        // 시간한계점까지 시간이 이르면 애로우 프리팹 생성하고 타이머 0으로 초기화
        if (this.timer > instantiationThreshold)
        {
            this.damageToInt = Random.Range(minDamage, maxDamage+1);
            this.damage = this.damageToInt/1;
            // 애로우 프리펩 생성 위치 x축 랜덤
            positionX = Random.Range(minX, maxX);

            // 추락속도 랜덤
            downSpeed = Random.Range(minSpeed, maxSpeed);

            if (this.damage == maxDamage)
            {
                if (gameDirectorScript.timer <= 15f)
                {
                    arrowController.damage = this.damage * 2;
                    arrowController.downSpeed = downSpeed * 2;
                }
                else
                {
                    arrowController.damage = this.damage;
                    arrowController.downSpeed = downSpeed;
                }

                arrowMaxGo.transform.position = new Vector3(positionX, 4.3f, 0);
                Object.Instantiate(arrowMaxGo);
            }

            else
            {
                if (gameDirectorScript.timer <= 15f)
                {
                    arrowController.damage = this.damage * 2;
                    arrowController.downSpeed = downSpeed * 2;
                }
                else
                {
                    arrowController.damage = this.damage;
                    arrowController.downSpeed = downSpeed;
                }
                arrowGo.transform.position = new Vector3(positionX, 4.3f, 0);
                Object.Instantiate(arrowGo);
            }
            timer = 0;
        }
    }
}
