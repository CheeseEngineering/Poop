using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ArrowGenerator : MonoBehaviour
{
    // ������ �ַο� ������ ���� ����
    public GameObject arrowGo;
    public GameObject arrowMaxGo;
    public GameObject gameDirector;
    private arrowController arrowController;
    public gameDirector gameDirectorScript;
    // �ð��� ������ ���� �� �ð��Ѱ��� 1�� �ֱ� ����
    private float timer;
    private float instantiationThreshold = 1f;
    // �ַο� �������� ������ ��ġ �ִ� �ּҰ� ����
    private float minX = -8.5f;
    private float maxX = 8.5f;

    // �������� �ӵ� ���� ����
    private float downSpeed;

    private int minDamage = 5;
    private int maxDamage = 10;
    // �ַο� ������ �߶��ӵ� �ִ� �ּҰ� ����
    private float minSpeed = -0.06f;
    private float maxSpeed = -0.1f;
    // x�� ��ġ ����
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
            // deltaTime��ŭ ����
            this.timer += Time.deltaTime*2;
        }
        else
        {
            // deltaTime��ŭ ����
            this.timer += Time.deltaTime;
        }

        // �ð��Ѱ������� �ð��� �̸��� �ַο� ������ �����ϰ� Ÿ�̸� 0���� �ʱ�ȭ
        if (this.timer > instantiationThreshold)
        {
            this.damageToInt = Random.Range(minDamage, maxDamage+1);
            this.damage = this.damageToInt/1;
            // �ַο� ������ ���� ��ġ x�� ����
            positionX = Random.Range(minX, maxX);

            // �߶��ӵ� ����
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
