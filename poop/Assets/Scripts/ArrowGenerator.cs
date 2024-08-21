using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ArrowGenerator : MonoBehaviour
{
    // 생성할 애로우 프리펩 변수 선언
    public GameObject arrowPrefab;

    // 시간을 측정할 변수 및 시간한계점 선언
    public float timer;
    public float instantiationThreshold = 1f;



    void Start()
    {

    }

    void Update()
    {
        // deltaTime만큼 증가
        timer += Time.deltaTime/1f;

        // 시간한계점까지 시간이 이르면 애로우 프리펩 생성하고 타이머 0으로 초기화
        if (timer >= instantiationThreshold)
        {
            Object.Instantiate(arrowPrefab);
            timer = 0;
        }
    }
}
