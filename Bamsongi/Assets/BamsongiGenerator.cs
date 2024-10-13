using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BamsongiGenerator : MonoBehaviour
{
    public GameObject bamsongiPrefab; //프리팹 대입 위한 public 선언

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //마우스 클릭 인풋
        {
            GameObject bamsongi = Instantiate(bamsongiPrefab); //밤송이 인스턴스 제작

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //탭좌표로 향하는 벡터에 따른 레이 클래스 반환
            Vector3 worldDir = ray.direction; //worldDir 벡터3 값을 ray.direction으로
            bamsongi.GetComponent<BamsongiController>().Shoot(worldDir.normalized * 2000); //밤송이 컨트롤러SHoot함수, 길이가 1인 벡터기 때문에 2000힘 곱해줌
        }
    }
}
