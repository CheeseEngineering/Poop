using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float maxHp = 100;
    public float hp = 100;
    public float radius = 1f;
    public float moveAmount;

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
}
