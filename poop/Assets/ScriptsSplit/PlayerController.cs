using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float maxHp = 100;
    public float hp = 100;
    public float radius = 1f;
    public float moveAmount;
    public bool isDamaged=false;
    public bool isDied = false;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log($"현재 체력 : {this.hp}/{this.maxHp}");
    }

    // Update is called once per frame
    void Update()
    {
        this.Move();

        this.LimitPosition();

        this.IsDamaged();

        this.IsDied();
    }
    private void LimitPosition()
    {
        if (this.transform.position.x > 7.78f || this.transform.position.x < -7.78f)
        {
            this.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, -7.78f, 7.78f), this.transform.position.y, this.transform.position.z);
        }
    }
    private void Move()
    {
        this.transform.Translate(moveAmount, 0, 0);
        moveAmount = 0;
    }

    private void IsDamaged()
    {
        if (this.isDamaged == true)
        {
            Debug.Log($"현재 체력 : {this.hp}/{this.maxHp}");
            this.isDamaged = false;
        }
    }

    private void IsDied()
    {
        if(this.hp <= 0)
        {
            this.hp = 0;
            Debug.Log("사망하였습니다.");
            this.isDied = true;
            this.enabled = false;
        }
    }
}
