using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class playerController : MonoBehaviour
{
    // �÷��̾� �ݰ� ���� 1�����Ͽ� ����
    public float radius = 1f;
    public float hp = 100;
    public float maxHp = 100;
    void Start()
    {
        Debug.Log($"���� ü�� : {this.hp}/{this.maxHp}");
    }
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
            LimitPosition();
        }
        // ������ ȭ��ǥ�� ������ x�� 1��ŭ �̵�
        else if (isRightArrowDown)
        {
            this.transform.Translate(1, 0, 0);
            Debug.Log("����ȭ��ǥ ����");
            LimitPosition();
        }

        
    }
    public void Damaged()
    {
        Debug.Log($"���� ü�� : {this.hp}/{this.maxHp}");
    }

    private void LimitPosition()
    {
        if (this.transform.position.x > 7.78f || this.transform.position.x < -7.78f)
        {
            this.transform.position= new Vector3 (Mathf.Clamp(this.transform.position.x, -7.78f, 7.78f), this.transform.position.y, this.transform.position.z);
        }
    }
}
