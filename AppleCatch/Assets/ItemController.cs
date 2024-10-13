using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public float dropSpeed = -0.03f; //�������� �ӵ� ����

    void Update()
    {
        transform.Translate(0, this.dropSpeed, 0); //transform y��ǥ �Ʒ���
        if (transform.position.y < -1.0f)   //-1.0 ���� �Ʒ��� ���� �����
        {
            Destroy(gameObject);
        }
    }
}