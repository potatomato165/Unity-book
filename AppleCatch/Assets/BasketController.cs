using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketController : MonoBehaviour
{
    public AudioClip appleSE;
    public AudioClip bombSE;
    AudioSource aud;
    GameObject director;


    void Start()
    {
        Application.targetFrameRate = 60; //프레임 조절
        this.aud = GetComponent<AudioSource>();
        this.director = GameObject.Find("GameDirector");
    }

    void OnTriggerEnter(Collider other) //바구니에 아이템 닿으면 맞는 오디오 출력. 여기서 전해지는 콜라이더는 바구니 말고 아이템 콜라이더.
    {
        if (other.gameObject.tag == "Apple")
        {
            this.aud.PlayOneShot(this.appleSE);
            this.director.GetComponent<GameDirector>().GetApple(); //사고ㅏ 받ㅇㅏㅆ다느ㄴ 신호
        }
        else
        {
            this.aud.PlayOneShot(this.bombSE);
            this.director.GetComponent<GameDirector>().GetBomb(); //폭탄 받ㅇㅏㅆ다느ㄴ 신호
        }
        Destroy(other.gameObject);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // 카메라 좌표에서 게임화면 안쪽으로 광선 발사
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity)) //광선이 stage 오브젝트에 닿았는지 확인. hit 앞에 out --> out에 계속 메서드 내 값을 채워 변수로 변환해달라는 뜻.
            {
                float x = Mathf.RoundToInt(hit.point.x);
                float z = Mathf.RoundToInt(hit.point.z);
                transform.position = new Vector3(x, 0, z);
            }
        }
    }
}
