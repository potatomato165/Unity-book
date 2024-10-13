using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public GameObject applePrefab; //프리팹변수들 선언
    public GameObject bombPrefab;
    float span = 1.0f;
    float delta = 0;
    int ratio = 2;
    float speed = -0.03f;


    public void SetParameter(float span, float speed, int ratio) //난이도 조절 위한 변수들 설정
    {
        this.span = span;
        this.speed = speed;
        this.ratio = ratio;
    }

    void Update()
    {
        this.delta += Time.deltaTime; //프레임 간 시간차 더함. 합계 1초 이상이면 인스턴스 생성. x, z 좌표 랜덤설정
        if (this.delta > this.span)
        {
            this.delta = 0;
            GameObject item;
            int dice = Random.Range(1, 11); //랜덤으로 사과, 폭탄 스폰되게 2이하면 폭탄, 2 초과면 사과
            if (dice<=this.ratio)
            {
                item = Instantiate(bombPrefab);
            }
            else
            {
                item = Instantiate(applePrefab);
            }
            float x = Random.Range(-1, 2);
            float z = Random.Range(-1, 2);
            item.transform.position = new Vector3(x, 4, z);
            item.GetComponent<ItemController>().dropSpeed = this.speed; // 아이템 컨트롤러에 드랍스피드 변경
        }
    }
}
