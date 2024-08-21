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

    // �������� �ӵ� ���� ����
    private float downSpeed;


    // �÷��̾���� �Ÿ� x��, y�� ���� ����, �÷��̾�� �ַο��������� �ݰ��� ���� ����
    public float distanceX;
    public float distanceY;
    public float radiusSum;

    // �ַο� ������ �߶��ӵ� �ִ� �ּҰ� ����
    public float minSpeed = -0.06f;
    public float maxSpeed = -0.1f;

    // �ַο� �������� ������ ��ġ �ִ� �ּҰ� ����
    public float minX = -8.5f;
    public float maxX = 8.5f;

    // x�� ��ġ ����
    private float positionX;


    void Start()
    {
        // �ַο� ������ ���� ��ġ x�� ����
        positionX = Random.Range(minX, maxX);
        // �ַο� ������ ���� ���� ������ �����ǵ��� ����
        this.transform.position = new Vector3(positionX, 4.3f, 0);

        // �÷��̾� ���� ������Ʈ �����
        player = GameObject.Find("player");
        // �߶��ӵ� ����
        downSpeed = Random.Range(minSpeed,maxSpeed);
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

        // �߶��ӵ� �������� �߶� ����
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
            Object.Destroy(self);
            Debug.Log("�浹");
        }
    }
}
