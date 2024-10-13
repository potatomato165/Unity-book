using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  // TextMeshPro

public class GameDirector : MonoBehaviour
{
    GameObject timerText;
    GameObject pointText;
    float time = 30.0f; //�⺻�ð� ���� 
    int point = 0;
    GameObject generator; //��������

    public void GetApple() //����� 100��
    {
        this.point += 100;
    }

    public void GetBomb() //��ź�� ��
    {
        this.point /= 2;
    }


    void Start()
    {
        this.timerText = GameObject.Find("Time"); //������ ��ü ����
        this.pointText = GameObject.Find("Point");
        this.generator = GameObject.Find("ItemGenerator"); 
    }

    void Update() // �ð� ��� ������Ʈ 
    {
        this.time -= Time.deltaTime;
        //�ð���ȭ�� ���� ���̵� ��ȭ
        if (this.time < 0)
        {
            this.time = 0;
            this.generator.GetComponent<ItemGenerator>().SetParameter(10000.0f, 0, 0);
        }
        else if (0 <= this.time && this.time < 4)
        {
            this.generator.GetComponent<ItemGenerator>().SetParameter(0.3f, -0.06f, 0);// �����ӵ�, ���ϼӵ�, ��ź����
        }
        else if (4 <= this.time && this.time < 12)
        {
            this.generator.GetComponent<ItemGenerator>().SetParameter(0.5f, -0.05f, 6);
        }
        else if (12 <= this.time && this.time < 23)
        {
            this.generator.GetComponent<ItemGenerator>().SetParameter(0.8f, -0.04f, 4);
        }
        else if (23 <= this.time && this.time < 30)
        {
            this.generator.GetComponent<ItemGenerator>().SetParameter(1.0f, -0.03f, 2);
        }

        this.timerText.GetComponent<TextMeshProUGUI>().text = this.time.ToString("F1"); //�Ҽ��� �Ʒ� ù°�ڸ�����
        this.pointText.GetComponent<TextMeshProUGUI>().text = this.point.ToString() + "point";
    }
}
