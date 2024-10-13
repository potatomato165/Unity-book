using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BamsongiGenerator : MonoBehaviour
{
    public GameObject bamsongiPrefab; //������ ���� ���� public ����

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //���콺 Ŭ�� ��ǲ
        {
            GameObject bamsongi = Instantiate(bamsongiPrefab); //����� �ν��Ͻ� ����

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //����ǥ�� ���ϴ� ���Ϳ� ���� ���� Ŭ���� ��ȯ
            Vector3 worldDir = ray.direction; //worldDir ����3 ���� ray.direction����
            bamsongi.GetComponent<BamsongiController>().Shoot(worldDir.normalized * 2000); //����� ��Ʈ�ѷ�SHoot�Լ�, ���̰� 1�� ���ͱ� ������ 2000�� ������
        }
    }
}
