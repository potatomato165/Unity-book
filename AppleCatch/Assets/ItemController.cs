using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public float dropSpeed = -0.03f; //떨어지는 속도 설정

    void Update()
    {
        transform.Translate(0, this.dropSpeed, 0); //transform y좌표 아래로
        if (transform.position.y < -1.0f)   //-1.0 보다 아래로 가면 사라짐
        {
            Destroy(gameObject);
        }
    }
}