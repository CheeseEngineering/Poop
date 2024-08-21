using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float maxHp = 100;
    public float hp = 100;
    public float radius = 1f;
    public bool isLeftKeyDown;
    public bool isRightKeyDown;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log($"현재 체력 : {this.hp}/{this.maxHp}");
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isLeftKeyDown)
        {
            this.transform.Translate(-1, 0, 0);
            LimitPosition();
        }
        else if (this.isRightKeyDown)
        {
            this.transform.Translate(1, 0, 0);
            LimitPosition();
        }
    }
    private void LimitPosition()
    {
        if (this.transform.position.x > 7.78f || this.transform.position.x < -7.78f)
        {
            this.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, -7.78f, 7.78f), this.transform.position.y, this.transform.position.z);
        }
    }
}
