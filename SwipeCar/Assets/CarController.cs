using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    float speed = 0;
    Vector2 startPos;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;

    }

    // Update is called once per frame
    void Update()
    {   
        //���������� ���̸� ���Ѵ�
        if (Input.GetMouseButtonDown(0))   //���콺�� Ŭ���ϸ�
        {
            //���콺�� Ŭ���� ��ǥ
            this.startPos = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            //���콺 ��ư���� �հ����� ������ �� ��ǥ
            Vector2 endPos = Input.mousePosition;
            float swipeLength=endPos.x-this.startPos.x;

            //�������� ���̸� ó�� �ӵ��� �����Ѵ�.
            this.speed = swipeLength / 500.0f;

            //ȿ���� ���
            GetComponent<AudioSource>().Play();
        }
        transform.Translate(this.speed, 0, 0);  //�̵�
        this.speed *= 0.98f;   //����
    }
}
