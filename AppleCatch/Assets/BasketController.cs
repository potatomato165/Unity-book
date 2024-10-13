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
        Application.targetFrameRate = 60; //������ ����
        this.aud = GetComponent<AudioSource>();
        this.director = GameObject.Find("GameDirector");
    }

    void OnTriggerEnter(Collider other) //�ٱ��Ͽ� ������ ������ �´� ����� ���. ���⼭ �������� �ݶ��̴��� �ٱ��� ���� ������ �ݶ��̴�.
    {
        if (other.gameObject.tag == "Apple")
        {
            this.aud.PlayOneShot(this.appleSE);
            this.director.GetComponent<GameDirector>().GetApple(); //��� �ޤ������ٴ��� ��ȣ
        }
        else
        {
            this.aud.PlayOneShot(this.bombSE);
            this.director.GetComponent<GameDirector>().GetBomb(); //��ź �ޤ������ٴ��� ��ȣ
        }
        Destroy(other.gameObject);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // ī�޶� ��ǥ���� ����ȭ�� �������� ���� �߻�
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity)) //������ stage ������Ʈ�� ��Ҵ��� Ȯ��. hit �տ� out --> out�� ��� �޼��� �� ���� ä�� ������ ��ȯ�ش޶�� ��.
            {
                float x = Mathf.RoundToInt(hit.point.x);
                float z = Mathf.RoundToInt(hit.point.z);
                transform.position = new Vector3(x, 0, z);
            }
        }
    }
}
