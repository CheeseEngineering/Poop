using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ArrowGenerator : MonoBehaviour
{
    // ������ �ַο� ������ ���� ����
    public GameObject arrowPrefab;

    // �ð��� ������ ���� �� �ð��Ѱ��� ����
    public float timer;
    public float instantiationThreshold = 1f;



    void Start()
    {

    }

    void Update()
    {
        // deltaTime��ŭ ����
        timer += Time.deltaTime/1f;

        // �ð��Ѱ������� �ð��� �̸��� �ַο� ������ �����ϰ� Ÿ�̸� 0���� �ʱ�ȭ
        if (timer >= instantiationThreshold)
        {
            Object.Instantiate(arrowPrefab);
            timer = 0;
        }
    }
}
