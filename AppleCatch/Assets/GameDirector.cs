using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  // TextMeshPro

public class GameDirector : MonoBehaviour
{
    GameObject timerText;
    GameObject pointText;
    float time = 30.0f; //기본시간 설정 
    int point = 0;
    GameObject generator; //변수선언

    public void GetApple() //사과는 100점
    {
        this.point += 100;
    }

    public void GetBomb() //폭탄은 반
    {
        this.point /= 2;
    }


    void Start()
    {
        this.timerText = GameObject.Find("Time"); //변수에 실체 대입
        this.pointText = GameObject.Find("Point");
        this.generator = GameObject.Find("ItemGenerator"); 
    }

    void Update() // 시간 계속 업데이트 
    {
        this.time -= Time.deltaTime;
        //시간변화에 따른 난이도 변화
        if (this.time < 0)
        {
            this.time = 0;
            this.generator.GetComponent<ItemGenerator>().SetParameter(10000.0f, 0, 0);
        }
        else if (0 <= this.time && this.time < 4)
        {
            this.generator.GetComponent<ItemGenerator>().SetParameter(0.3f, -0.06f, 0);// 생성속도, 낙하속도, 폭탄비율
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

        this.timerText.GetComponent<TextMeshProUGUI>().text = this.time.ToString("F1"); //소수점 아래 첫째자리까지
        this.pointText.GetComponent<TextMeshProUGUI>().text = this.point.ToString() + "point";
    }
}
