using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class playerController : MonoBehaviour
{
    // ���ӿ�����Ʈ Ÿ�� �¿� ��ư �ʵ弱��
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
        // bool Ÿ�� �¿� ȭ��ǥ���� ���� ����
        bool isLeftArrowDown = Input.GetKeyDown(KeyCode.LeftArrow);
        bool isRightArrowDown = Input.GetKeyDown(KeyCode.RightArrow);
        
        // ���� ȭ��ǥ�� ������ x�� -1��ŭ �̵�
        if (isLeftArrowDown)
        {
            this.transform.Translate(-1, 0, 0);
            Debug.Log("����ȭ��ǥ ����");
        }
        // ������ ȭ��ǥ�� ������ x�� 1��ŭ �̵�
        else if (isRightArrowDown)
        {
            this.transform.Translate(1, 0, 0);
            Debug.Log("����ȭ��ǥ ����");
        }
    }
}
