using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BamsongiController : MonoBehaviour
{

    public void Shoot(Vector3 dir)
    {
        GetComponent<Rigidbody>().AddForce(dir); //vector3 �� �� ����(����)
    }

    void OnCollisionEnter(Collision other)
    {
        GetComponent<Rigidbody>().isKinematic = true;     //����̰� ��ü�� ������ iskinematic�� true �� �����ؼ� ����.
        GetComponent<ParticleSystem>().Play();
    }
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60; //������
        //Shoot(new Vector3(0, 200, 2000)); //Y������ �� 200(�߷� ���� ���), Z������ �� 2000 //����� ���ʷ����Ϳ��� ���ư� ���� �ּ�ó��
    }

    
}
