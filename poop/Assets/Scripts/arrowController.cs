using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class arrowController : MonoBehaviour
{
    // ���� ������Ʈ Ÿ�� ���� ����
    public GameObject self;
    public GameObject player;
    // �÷��̾���Ʈ�ѷ� ������ ���� ����
    public playerController playerController;
    // �ݰ� ���� 1��ŭ �����Ͽ� ����
    public float radius = 1f;
    // �÷��̾���� �Ÿ� x��, y�� ���� ����, �÷��̾�� �ַο��������� �ݰ��� ���� ����
    public float distanceX;
    public float distanceY;
    public float radiusSum;
    public float downSpeed;

    public float damage;
    void Start()
    {
        // �÷��̾� ���� ������Ʈ �����
        player = GameObject.Find("player");
        // �÷��̾� ��Ʈ�ѷ� ��ũ��Ʈ �޾ƿ�
        playerController = player.GetComponent<playerController>();
    }
    void Update()
    {
        
        // �÷��̾�� �ַο� �������� �Ÿ� x��� y������ ���� (���밪ȭ)
        // �÷��̾�� �ַο� �������� �ݰ��� ����
        distanceX = Mathf.Abs(player.transform.position.x - this.transform.position.x);
        distanceY = Mathf.Abs(player.transform.position.y - this.transform.position.y);
        radiusSum = this.radius + playerController.radius;
        this.transform.Translate(0, downSpeed, 0);
        // ���� ����� �� �ı�
        if (this.transform.position.y < -4)
        {
            Object.Destroy(self);
        }
        // �÷��̾�� �浹���� �� �ı�
        // (x�Ÿ��� y�Ÿ��� �и��ؼ� ���ܹ� ó���Ұ�� �������ڸ��� �ı��Ǵ� ���� ����)
        else if (distanceY <= radiusSum && distanceX <=radiusSum)
        {
            playerController.hp -= this.damage;
            Object.Destroy(self);
            Debug.Log("�浹");
            playerController.Damaged();
            
        }
    }
}
