using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BamsongiController : MonoBehaviour
{

    public void Shoot(Vector3 dir)
    {
        GetComponent<Rigidbody>().AddForce(dir); //vector3 로 힘 증가(물리)
    }

    void OnCollisionEnter(Collision other)
    {
        GetComponent<Rigidbody>().isKinematic = true;     //밤송이가 물체에 닿으면 iskinematic이 true 로 변경해서 멈춤.
        GetComponent<ParticleSystem>().Play();
    }
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60; //프레임
        //Shoot(new Vector3(0, 200, 2000)); //Y축으로 힘 200(중력 영향 고려), Z축으로 힘 2000 //밤송이 제너레이터에서 날아감 따라서 주석처리
    }

    
}
